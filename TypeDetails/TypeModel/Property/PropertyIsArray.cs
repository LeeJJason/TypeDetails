using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyIsArray : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsArray : ");
            Console.WriteLine("\tpublic bool IsArray { get; }");
            Console.WriteLine("\t获取一个值，该值指示是否为 AnsiClass 选择了字符串格式属性 Type;");
        }

        public override void Run()
        {
            base.Run();

            Type[] types = { typeof(String), typeof(int[]),
                       typeof(ArrayList), typeof(Array),
                       typeof(List<String>),
                       typeof(IEnumerable<Char>) };
            foreach (var t in types)
                Console.WriteLine("{0,-15} IsArray = {1}", t.Name + ":",
                                  t.IsArray);
        }
    }
}
