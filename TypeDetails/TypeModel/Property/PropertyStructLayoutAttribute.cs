using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyStructLayoutAttribute : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.StructLayoutAttribute : ");
            Console.WriteLine("\tpublic virtual System.Runtime.InteropServices.StructLayoutAttribute StructLayoutAttribute { get; }");
            Console.WriteLine("\t获取一个描述当前类型的布局的 StructLayoutAttribute;");
        }

        public override void Run()
        {
            base.Run();

            DisplayLayoutAttribute(typeof(PropertyStructLayoutAttribute));
            DisplayLayoutAttribute(typeof(Test1));
            DisplayLayoutAttribute(typeof(Test2));
        }

        private static void DisplayLayoutAttribute(Type t)
        {
            var sla = t.StructLayoutAttribute;
            Console.WriteLine("\t\t" + t);
            Console.WriteLine("\t\t\tCharSet : " + sla.CharSet.ToString());
            Console.WriteLine("\t\t\tPack : " + sla.Pack.ToString());
            Console.WriteLine("\t\t\tSize : " + sla.Size.ToString());
            Console.WriteLine("\t\t\tValue : " + sla.Value.ToString());
        }
    }

    public struct Test1
    {
        public byte B1;
        public short S;
        public byte B2;
    }
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct Test2
    {
        [FieldOffset(0)] public byte B1;
        [FieldOffset(1)] public short S;
        [FieldOffset(3)] public byte B2;
    }
}
