using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class MyTypeSequential1
    {
    }
    [StructLayoutAttribute(LayoutKind.Sequential)]
    class MyTypeSequential2
    {
    }

    
    class PropertyIsLayoutSequential : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsLayoutSequential : ");
            Console.WriteLine("\tpublic bool IsLayoutSequential { get; }");
            Console.WriteLine("\t获取指示当前类型的字段是否按顺序（定义顺序或发送到元数据的顺序）放置的值;");
        }

        public override void Run()
        {
            base.Run();

            try
            {
                // Create an instance of myTypeSeq1.
                MyTypeSequential1 myObj1 = new MyTypeSequential1();
                Type myTypeObj1 = myObj1.GetType();
                // Check for and display the SequentialLayout attribute.
                Console.WriteLine("\t\tThe object myObj1 has IsLayoutSequential: {0}.", myObj1.GetType().IsLayoutSequential);
                // Create an instance of 'myTypeSeq2' class.
                MyTypeSequential2 myObj2 = new MyTypeSequential2();
                Type myTypeObj2 = myObj2.GetType();
                // Check for and display the SequentialLayout attribute.
                Console.WriteLine("\t\tThe object myObj2 has IsLayoutSequential: {0}.", myObj2.GetType().IsLayoutSequential);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn exception occurred: {0}\n{1}", e.Message, e.StackTrace);
            }
        }
    }
}
