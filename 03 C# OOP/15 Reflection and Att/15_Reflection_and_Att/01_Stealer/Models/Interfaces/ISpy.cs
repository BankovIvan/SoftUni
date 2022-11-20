namespace Stealer.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISpy
    {
        string StealFieldInfo(string className, string[] fieldNames);

        string AnalyzeAccessModifiers(string className);

        string RevealPrivateMethods(string className);

        string CollectGettersAndSetters(string className);

    }
}
