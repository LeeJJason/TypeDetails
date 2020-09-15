using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    // Declare a public class with the [Serializable] attribute.
    [Serializable]
    public class MyTestClass
    {
    }

    class PropertyIsSerializable : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsSerializable : ");
            Console.WriteLine("\tpublic bool IsSerializable { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否为可序列化的;");
        }

        public override void Run()
        {
            base.Run();

            try
            {
                bool myBool = false;
                MyTestClass myTestClassInstance = new MyTestClass();
                // Get the type of myTestClassInstance.
                Type myType = myTestClassInstance.GetType();
                // Get the IsSerializable property of myTestClassInstance.
                myBool = myType.IsSerializable;
                Console.WriteLine("\t\tIs {0} serializable? {1}.", myType.FullName, myBool.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("\t\tAn exception occurred: {0}", e.Message);
            }
        }
    }
}
