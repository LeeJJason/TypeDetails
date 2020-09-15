using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyTypeHandle : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.TypeHandle : ");
            Console.WriteLine("\tpublic virtual RuntimeTypeHandle TypeHandle { get; }");
            Console.WriteLine("\t获取当前 Type 的句柄;");
        }

        public override void Run()
        {
            base.Run();

            try
            {
                MyClass myClass = new MyClass();

                // Get the type of MyClass.
                Type myClassType = myClass.GetType();

                // Get the runtime handle of MyClass.
                RuntimeTypeHandle myClassHandle = myClassType.TypeHandle;

                DisplayTypeHandle(myClassHandle);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }

        public static void DisplayTypeHandle(RuntimeTypeHandle myTypeHandle)
        {
            // Get the type from the handle.
            Type myType = Type.GetTypeFromHandle(myTypeHandle);
            // Display the type.
            Console.WriteLine("\t\tDisplaying the type from the handle:");
            Console.WriteLine("\t\t\tThe type is {0}.", myType.ToString());
        }
    }
}
