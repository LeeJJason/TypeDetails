using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    public class MyClass
    {
        protected string myField = "A sample protected field.";
    }

    class PropertyIsAnsiClass : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsAnsiClass : ");
            Console.WriteLine("\tpublic bool IsAnsiClass { get; }");
            Console.WriteLine("\t获取一个值，该值指示是否为 AnsiClass 选择了字符串格式属性 Type;");

            Console.WriteLine("\tType.IsAutoClass : ");
            Console.WriteLine("\tpublic bool IsAutoClass { get; }");
            Console.WriteLine("\t获取一个值，该值指示是否为 AutoClass 选择了字符串格式属性 Type;");
        }

        public override void Run()
        {
            base.Run();

            try
            {
                MyClass myObject = new MyClass();
                // Get the type of the 'MyClass'.
                Type myType = typeof(MyClass);
                // Get the field information and the attributes associated with MyClass.
                FieldInfo myFieldInfo = myType.GetField("myField", BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine("\n\t\tChecking for the AnsiClass attribute for a field.\n");
                // Get and display the name, field, and the AnsiClass attribute.
                Console.WriteLine("\t\tName of Class: {0} \n\t\tValue of Field: {1} \n\t\tIsAnsiClass = {2}\n\t\tIsAutoClass = {3}", myType.FullName, myFieldInfo.GetValue(myObject), myType.IsAnsiClass, myType.IsAutoClass);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }
    }
}
