namespace P01_HospitalDatabase.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DbConfig
    {
        public const string ConnectionString =
            @"Server=.;Database=HospitalDatabase;MultipleActiveResultSets=true;Integrated Security=true;TrustServerCertificate=True";
    }
}
