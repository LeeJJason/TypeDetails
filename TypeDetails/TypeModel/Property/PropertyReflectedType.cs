using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyReflectedType : TypePropertyRunner
    {
        public abstract class MyClassB
        {
        }

        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.ReflectedType : ");
            Console.WriteLine("\tpublic virtual bool ReflectedType { get; }");
            Console.WriteLine("\t获取用于获取该成员的类对象;");
        }

        public override void Run()
        {
            base.Run();

            Console.WriteLine("\t\tReflected type of MyClassB is {0}",
            typeof(MyClassB).ReflectedType); //outputs MyClassA, the enclosing class
        }
    }
}
