using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyIsCOMObject : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsCOMObject : ");
            Console.WriteLine("\tpublic bool IsCOMObject { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否为 COM 对象;");
        }
    }
}
