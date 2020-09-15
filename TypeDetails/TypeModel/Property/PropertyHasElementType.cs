using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyHasElementType : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.HasElementType : ");
            Console.WriteLine("\tpublic bool HasElementType { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示当前 Type 是包含还是引用另一类型，即当前 Type 是数组、指针还是通过引用传递;");
        }

        public override void Run()
        {
            base.Run();

            // Define an array, get its type, and display HasElementType.
            int[] nums = { 1, 1, 2, 3, 5, 8, 13 };
            Type t = nums.GetType();
            Console.WriteLine("\t\tHasElementType is '{0}' for array types.", t.HasElementType);

            // Test an array type without defining an array.
            t = typeof(PropertyHasElementType[]);
            Console.WriteLine("\t\tHasElementType is '{0}' for array types.", t.HasElementType);

            // When you use Reflection Emit to emit dynamic methods and
            // assemblies, you can create array types using MakeArrayType.
            // The following creates the type 'array of Example'.
            t = typeof(PropertyHasElementType).MakeArrayType();
            Console.WriteLine("\t\tHasElementType is '{0}' for array types.", t.HasElementType);

            // When you reflect over methods, HasElementType is true for
            // ref, out, and pointer parameter types. The following
            // gets the Test method, defined above, and examines its
            // parameters.
            MethodInfo mi = typeof(PropertyHasElementType).GetMethod("Test");
            ParameterInfo[] parms = mi.GetParameters();
            t = parms[0].ParameterType;
            Console.WriteLine("\t\tHasElementType is '{0}' for ref parameter types.", t.HasElementType);
            t = parms[1].ParameterType;
            Console.WriteLine("\t\tHasElementType is '{0}' for out parameter types.", t.HasElementType); 
            t = parms[2].ParameterType;
            Console.WriteLine("\t\tHasElementType is '{0}' for pointer parameter types.", t.HasElementType);
            t = parms[3].ParameterType;
            Console.WriteLine("\t\tHasElementType is '{0}' for normal parameter types.", t.HasElementType);

            // When you use Reflection Emit to emit dynamic methods and
            // assemblies, you can create pointer and ByRef types to use
            // when you define method parameters.
            t = typeof(PropertyHasElementType).MakePointerType();
            Console.WriteLine("\t\tHasElementType is '{0}' for pointer types.", t.HasElementType);
            t = typeof(PropertyHasElementType).MakeByRefType();
            Console.WriteLine("\t\tHasElementType is '{0}' for ByRef types.", t.HasElementType);

        }

        // This method is for demonstration purposes.
        unsafe public void Test(ref int x, out int y, int* z, int w)
        {
            *z = x = y = 0;
        }
    }
}
