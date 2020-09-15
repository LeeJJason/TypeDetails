using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    public enum Color
    { Red, Blue, Green }

    class PropertyIsEnum : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsEnum : ");
            Console.WriteLine("\tpublic virtual bool IsEnum { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前的 Type 是否表示枚举;");

            Console.WriteLine("\tType.IsValueType : ");
            Console.WriteLine("\tpublic virtual bool IsValueType { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否为值类型;");
        }

        public override void Run()
        {
            base.Run();

            Type colorType = typeof(Color);
            Type enumType = typeof(Enum);
            Console.WriteLine("\t\tIs Color an enum? {0}.", colorType.IsEnum);
            Console.WriteLine("\t\tIs Color a value type? {0}.", colorType.IsValueType);
            Console.WriteLine("\t\tIs Enum an enum Type? {0}.", enumType.IsEnum);
            Console.WriteLine("\t\tIs Enum a value type? {0}.", enumType.IsValueType);
        }
    }
}
