using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyModule : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.Module : ");
            Console.WriteLine("\tpublic virtual bool Module { get; }");
            Console.WriteLine("\t获取在其中定义当前 Type 的模块 (DLL);");

            Console.WriteLine("\tType.Namespace : ");
            Console.WriteLine("\tpublic virtual bool Namespace { get; }");
            Console.WriteLine("\t获取 Type 的命名空间;");
        }

        public override void Run()
        {
            base.Run();

            Type myType = typeof(PropertyModule);
            Console.WriteLine("\t\tDisplaying information about {0}:", myType);
            // Get the namespace of the myClass class.
            Console.WriteLine("\t\tNamespace: {0}.", myType.Namespace);
            // Get the name of the module.
            Console.WriteLine("\t\tModule: {0}.", myType.Module);
            // Get the fully qualified type name.
            Console.WriteLine("\t\tFully qualified name: {0}.", myType.ToString());
        }
    }
}
