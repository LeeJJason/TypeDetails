using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Field
{
    class FieldEmptyTypes : TypeFieldRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("Type.EmptyTypes : ");
            Console.WriteLine("\tpublic static readonly Type[] EmptyTypes;");
            Console.WriteLine("\t表示一个Type类型的空数组;");
            Console.WriteLine(string.Format("\tLength : {0};", Type.EmptyTypes.Length));
        }
    }
}
