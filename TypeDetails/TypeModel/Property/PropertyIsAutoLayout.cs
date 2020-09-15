using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyIsAutoLayout : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsAutoLayout : ");
            Console.WriteLine("\tpublic bool IsAutoLayout { get; }");
            Console.WriteLine("\t获取指示当前类型的字段是否由公共语言运行时自动放置的值;");
        }

        public override void Run()
        {
            base.Run();

            // Create an instance of the Type class using the GetType method.
            Type myType = typeof(PropertyIsAutoLayout);
            // Get and display the IsAutoLayout property of the
            // Demoinstance.
            Console.WriteLine("\t\tThe AutoLayout property for the Demo class is {0}.",
                myType.IsAutoLayout);
        }
    }
}
