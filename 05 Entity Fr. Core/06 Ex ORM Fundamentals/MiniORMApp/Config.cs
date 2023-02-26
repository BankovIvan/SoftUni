namespace MiniORMApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Config
    {
        public const string ConnectionString =
            @"Server=.;Database=MiniORM;MultipleActiveResultSets=true;Integrated Security=true;TrustServerCertificate=True";
    }
}
