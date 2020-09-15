using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    public class InternalOnly
    {
        public class Nested { }
    }

    class PropertyIsVisible : TypePropertyRunner
    {
        public class Nested { }

        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsVisible : ");
            Console.WriteLine("\tpublic virtual bool IsVisible { get; }");
            Console.WriteLine("\t获取一个指示 Type 是否可由程序集之外的代码访问的值;");
        }
        public override void Run()
        {
            base.Run();

            Type t = typeof(InternalOnly.Nested);
            Console.WriteLine(
                "Is the {0} class visible outside the assembly? {1}",
                t.FullName,
                t.IsVisible
            );

            t = typeof(PropertyIsVisible.Nested);
            Console.WriteLine(
                "Is the {0} class visible outside the assembly? {1}",
                t.FullName,
                t.IsVisible
            );
        }
    }
}
