using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    interface myIFace
    {
    }

    class PropertyIsInterface : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsInterface : ");
            Console.WriteLine("\tpublic bool IsInterface { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是一个接口；即，不是类或值类型;");
        }

        public override void Run()
        {
            base.Run();
            try
            {
                // Get the IsInterface attribute for myIFace.
                bool myBool1 = typeof(myIFace).IsInterface;
                //Display the IsInterface attribute for myIFace.
                Console.WriteLine("\t\t{0} Is the specified type an interface? {1}.", typeof(myIFace), myBool1);
                // Get the attribute IsInterface for MyIsInterface.
                bool myBool2 = typeof(PropertyIsInterface).IsInterface;
                //Display the IsInterface attribute for MyIsInterface.
                Console.WriteLine("\t\t{0} Is the specified type an interface? {1}.", typeof(PropertyIsInterface), myBool2);
            }
            catch (Exception e)
            {
                Console.WriteLine("\t\tAn exception occurred: {0}.", e.Message);
            }
        }
    }
}
