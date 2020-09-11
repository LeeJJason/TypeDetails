using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyFullName : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.FullName : ");
            Console.WriteLine("\tpublic abstract string FullName { get; }");
            Console.WriteLine("\t获取该类型的完全限定名称，包括其命名空间，但不包括程序集。");
        }

        public override void Run()
        {
            base.Run();

            Type t = typeof(String);
            ShowTypeInfo(t);

            t = typeof(List<>);
            ShowTypeInfo(t);

            var list = new List<String>();
            t = list.GetType();
            ShowTypeInfo(t);

            Object v = 12;
            t = v.GetType();
            ShowTypeInfo(t);

            t = typeof(IFormatProvider);
            ShowTypeInfo(t);

            IFormatProvider ifmt = NumberFormatInfo.CurrentInfo;
            t = ifmt.GetType();
            ShowTypeInfo(t);
        }

        private static void ShowTypeInfo(Type t)
        {
            Console.WriteLine($"Name: {t.Name}");
            Console.WriteLine($"Full Name: {t.FullName}");
            Console.WriteLine($"ToString:  {t}");
            Console.WriteLine($"Assembly Qualified Name: {t.AssemblyQualifiedName}");
            Console.WriteLine();
        }
    }
}
