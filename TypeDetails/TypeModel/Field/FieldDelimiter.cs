using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Field
{
    class FieldDelimiter : TypeFieldRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("Type.Delimite : ");
            Console.WriteLine("\tpublic static readonly char Delimiter;");
            Console.WriteLine("\t用于分割类型命名空间的符号;");
            Console.WriteLine("\t" + Type.Delimiter);
            Console.WriteLine("\t" + typeof(FieldDelimiter).FullName);
        }

    }
}
