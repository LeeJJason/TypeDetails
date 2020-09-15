using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyIsClass : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsClass : ");
            Console.WriteLine("\tpublic bool IsClass { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是一个类或委托；即，不是值类型或接口;");
        }

        public override void Run()
        {
            base.Run();
            try
            {
                Type myType = typeof(PropertyIsClass);
                // Get and display the 'IsClass' property of the 'MyDemoClass' instance.
                Console.WriteLine("\t\t{0} Is the specified type a class? {1}.", myType, myType.IsClass);
                myType = typeof(int);
                Console.WriteLine("\t\t{0} Is the specified type a class? {1}.", myType, myType.IsClass);
                myType = typeof(DateTime);
                Console.WriteLine("\t\t{0} Is the specified type a class? {1}.", myType, myType.IsClass);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn exception occurred: {0}.", e.Message);
            }
        }
    }
}
