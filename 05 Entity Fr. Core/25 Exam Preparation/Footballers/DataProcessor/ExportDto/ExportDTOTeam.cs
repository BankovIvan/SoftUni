namespace Footballers.DataProcessor.ExportDto
{
    using Footballers.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTOTeam
    {
        public ExportDTOTeam()
        {
            this.Footballers = new List<ExportDTOTeamFootballer>();

        }


        public string Name { get; set; } = null!;

        public List<ExportDTOTeamFootballer> Footballers { get; set; } 

    }
}
