using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyIsSecurityCritical : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsSecurityCritical : ");
            Console.WriteLine("\tpublic bool IsSecurityCritical { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前的类型在当前信任级别上是安全关键的还是安全可靠关键的，并因此可以执行关键操作;");

            Console.WriteLine("\tType.IsSecuritySafeCritical : ");
            Console.WriteLine("\tpublic bool IsSecuritySafeCritical { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前类型在当前信任级别上是否是安全可靠关键的；即它是否可以执行关键操作并可以由透明代码访问;");

            Console.WriteLine("\tType.IsSecurityTransparent : ");
            Console.WriteLine("\tpublic bool IsSecurityTransparent { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前类型在当前信任级别上是否是透明的而无法执行关键操作;");
        }

        public override void Run()
        {
            base.Run();
            string formate = "\t\t{0,-20}\t{1,-20}\t{2,-20}\t{3,-20}";
            Console.WriteLine(formate, "Security level",  "IsSecurityCritical",  "IsSecuritySafeCritical", "IsSecurityTransparent");
            Console.WriteLine(formate, "Critical", "true", "false", "false");
            Console.WriteLine(formate, "Safe critical", "true", "true", "false");
            Console.WriteLine(formate, "Transparent", "false", "false", "true");

        }
    }
}
