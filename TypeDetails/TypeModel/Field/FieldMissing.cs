using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Field
{
    class FieldMissing : TypeFieldRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.Missing   : ");
            Console.WriteLine("\tpublic static readonly object Missing;");
            Console.WriteLine("\t表示 Type 信息中的缺少值;");
        }

        public override void Run()
        {
            base.Run();
            object[] ps = {10, Type.Missing };
            typeof(FieldMissing).GetMethod("Test").Invoke(null, ps);
        }

        public static void Test(int a, int b = 10)
        {
            Console.WriteLine(a + b);
        }
    }
}
