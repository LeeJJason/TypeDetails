using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyIsImport : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsImport : ");
            Console.WriteLine("\tpublic bool IsImport { get; }");
            Console.WriteLine("\t获取一个值，该值指示 Type 是否应用了 ComImportAttribute 属性，如果应用了该属性，则表示它是从 COM 类型库导入的;");
        }
    }
}
