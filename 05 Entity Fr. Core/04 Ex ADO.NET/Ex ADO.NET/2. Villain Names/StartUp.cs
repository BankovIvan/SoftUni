﻿namespace _02_Villain_Names
{
    using Microsoft.Data.SqlClient;
    using System.Data;
    using System.Reflection.PortableExecutable;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        static async Task Main(string[] args)
        {

            using SqlConnection connection = new SqlConnection(Config.ConnectionString);

            await connection.OpenAsync();

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(connection.ServerVersion);
            Console.ResetColor();

            //2. Villain Names
            /*
            Console.WriteLine("2. Villain Names");
            Console.WriteLine("----------");
            string ret02 = await _02_GetAllVillainNamesAsync(connection);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret02);
            Console.ResetColor();
            */

            //3. Minion Names
            /*
            Console.WriteLine("3. Minion Names");
            Console.WriteLine("----------");
            int nVilanId = int.Parse(Console.ReadLine());
            string ret03 = await _03_GetVillainAllMinionNamesAsync(connection, nVilanId);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret03);
            Console.ResetColor();
            */

            //4. Add Minion
            Console.WriteLine("4. Add Minion");
            Console.WriteLine("----------");

            string[] arrMinion = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] arrVillain = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string ret04 = await _04_AddMinionAsync(connection, arrMinion, arrVillain);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret04);
            Console.ResetColor();

            connection.Close();
        }

        /// <summary>
        ///     2. Villain Names
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        private static async Task<string> _02_GetAllVillainNamesAsync(SqlConnection connection)
        {
            using SqlCommand command = new SqlCommand(SqlQueries._02_Select, connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            StringBuilder ret = new StringBuilder();

            while (reader.Read())
            {
                //string? sName = reader.GetString(0);
                //int? nCount = reader.GetInt32(1);
                string? sName = (string)reader["Name"];
                int? nCount = (int)reader["MinionsCount"];

                ret.AppendLine(String.Format("{0} - {1}", sName, nCount));

            }

            reader.Close();

            return ret.ToString().Trim();

        }

        /// <summary>
        ///     3. Minion Names
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        private static async Task<string> _03_GetVillainAllMinionNamesAsync(SqlConnection connection, int nVillainId)
        {
            using SqlCommand commandVilan = new SqlCommand(SqlQueries._03_SelectVillanName, connection);

            commandVilan.Parameters.Add(new SqlParameter("@Id", nVillainId));

            string? sVilanName = (string?)await commandVilan.ExecuteScalarAsync();

            StringBuilder ret = new StringBuilder();

            if(sVilanName == null) 
            {
                ret.AppendLine(String.Format("No villain with ID {0} exists in the database.", nVillainId));
                return ret.ToString().Trim();
            }

            ret.AppendLine(String.Format("Villain: {0}", sVilanName));

            using SqlCommand commandMinions = new SqlCommand(SqlQueries._03_SelectVillanMinionNames, connection);
            commandMinions.Parameters.Add(new SqlParameter("@Id", nVillainId));
            using SqlDataReader readerMinions = await commandMinions.ExecuteReaderAsync();

            if(readerMinions == null || readerMinions.HasRows == false) 
            {
                ret.AppendLine("(no minions)");
                return ret.ToString().Trim();
            }

            while (readerMinions.Read())
            {
                //string? sName = reader.GetString(0);
                //int? nCount = reader.GetInt32(1);
                long? nRow = (long)readerMinions["RowNum"];
                string? sName = (string)readerMinions["Name"];
                int? nAge = (int)readerMinions["Age"];

                ret.AppendLine(String.Format("{0}. {1} {2}", nRow, sName, nAge));

            }

            readerMinions.Close();

            return ret.ToString().Trim();

        }

        /// <summary>
        ///     4. Add Minion
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        private static async Task<string> _04_AddMinionAsync(SqlConnection connection, string[] arrMinion, string[] arrVillian)
        {
            StringBuilder ret = new StringBuilder();

            string sMinionName = arrMinion[1];
            int nMinionAge = int.Parse(arrMinion[2]);
            string sTownName = arrMinion[3];
            string sVillainName = arrVillian[1];

            int? nTownId;
            int? nVillainId;
            int? nMinionId;

            //BEGIN TRANSACTION:
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Check the town:
                SqlCommand commandGetTownId = connection.CreateCommand();
                commandGetTownId.Connection = connection;
                commandGetTownId.Transaction = transaction;
                commandGetTownId.CommandText = SqlQueries._04_SelectTownId;
                commandGetTownId.Parameters.AddWithValue("@townName", sTownName);

                nTownId = (int?) await commandGetTownId.ExecuteScalarAsync();

                if(nTownId == null)
                {
                    SqlCommand commandAddNewTown = new SqlCommand(SqlQueries._04_InsertIntoTowns, connection);
                    commandAddNewTown.Transaction = transaction;
                    commandAddNewTown.Parameters.AddWithValue("@townName", sTownName);
                    await commandAddNewTown.ExecuteNonQueryAsync();
                    ret.AppendLine(String.Format("Town {0} was added to the database.", sTownName));

                    nTownId = (int?)await commandGetTownId.ExecuteScalarAsync();
                }

                // Check the villain:
                SqlCommand commandGetVillainId = connection.CreateCommand();
                commandGetVillainId.Connection = connection;
                commandGetVillainId.Transaction = transaction;
                commandGetVillainId.CommandText = SqlQueries._04_SelectVillanId;
                commandGetVillainId.Parameters.AddWithValue("@Name", sVillainName);

                nVillainId = (int?)await commandGetVillainId.ExecuteScalarAsync();

                if (nVillainId == null)
                {
                    SqlCommand commandAddNewVillain = new SqlCommand(SqlQueries._04_InsertIntoVillains, connection);
                    commandAddNewVillain.Parameters.AddWithValue("@villainName", sVillainName);
                    commandAddNewVillain.Transaction = transaction;
                    await commandAddNewVillain.ExecuteNonQueryAsync();
                    ret.AppendLine(String.Format("Villain {0} was added to the database.", sVillainName));

                    nVillainId = (int?)await commandGetVillainId.ExecuteScalarAsync();
                }

                // Add Minion
                SqlCommand commandAddNewMinion = new SqlCommand(SqlQueries._04_InsertIntoMinions, connection);
                commandAddNewMinion.Parameters.AddWithValue("@name", sMinionName);
                commandAddNewMinion.Parameters.AddWithValue("@age", nMinionAge);
                commandAddNewMinion.Parameters.AddWithValue("@townId", nTownId);
                commandAddNewMinion.Transaction = transaction;
                await commandAddNewMinion.ExecuteNonQueryAsync();

                SqlCommand commandGetMinionId = connection.CreateCommand();
                commandGetMinionId.Connection = connection;
                commandGetMinionId.Transaction = transaction;
                commandGetMinionId.CommandText = SqlQueries._04_SelectMinionId;
                commandGetMinionId.Parameters.AddWithValue("@Name", sMinionName);

                nMinionId = (int?)await commandGetMinionId.ExecuteScalarAsync();

                SqlCommand commandAssignMinionVillain = new SqlCommand(SqlQueries._04_InsertIntoMinionsVillains, connection);
                commandAssignMinionVillain.Parameters.AddWithValue("@minionId", nMinionId);
                commandAssignMinionVillain.Parameters.AddWithValue("@villainId", nVillainId);
                commandAssignMinionVillain.Transaction = transaction;   
                await commandAssignMinionVillain.ExecuteNonQueryAsync();

                ret.AppendLine(String.Format("Successfully added {0} to be minion of {1}.", sMinionName, sVillainName));

                await transaction.CommitAsync();

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();

            }

            return ret.ToString().Trim();

        }
    }
}