using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    [StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi)]
    public class MySystemTime
    {
        [FieldOffset(0)] public ushort wYear;
        [FieldOffset(2)] public ushort wMonth;
        [FieldOffset(4)] public ushort wDayOfWeek;
        [FieldOffset(6)] public ushort wDay;
        [FieldOffset(8)] public ushort wHour;
        [FieldOffset(10)] public ushort wMinute;
        [FieldOffset(12)] public ushort wSecond;
        [FieldOffset(14)] public ushort wMilliseconds;
    }

    class PropertyIsExplicitLayout : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsExplicitLayout : ");
            Console.WriteLine("\tpublic bool IsExplicitLayout { get; }");
            Console.WriteLine("\t获取指示当前类型的字段是否放置在显式指定的偏移量处的值;");
        }

        public override void Run()
        {
            base.Run();

            // Create an instance of the type using the GetType method.
            Type t = typeof(MySystemTime);
            // Get and display the IsExplicitLayout property.
            Console.WriteLine("\n{0}IsExplicitLayout for MySystemTime is {1}.", t, t.IsExplicitLayout);
            t = typeof(PropertyIsExplicitLayout);
            // Get and display the IsExplicitLayout property.
            Console.WriteLine("\n{0}IsExplicitLayout for MySystemTime is {1}.", t, t.IsExplicitLayout);
        }
    }
}
