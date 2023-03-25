namespace Footballers.DataProcessor.ExportDto
{
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTOTeamFootballer
    {
        public string FootballerName { get; set; } = null!;

        public string ContractStartDate { get; set; } = null!;

        public string ContractEndDate { get; set; } = null!;

        public string BestSkillType { get; set; } = null!;

        public string PositionType { get; set; } = null!;

    }
}
