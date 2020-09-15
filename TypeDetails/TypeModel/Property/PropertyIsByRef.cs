using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    public class MyTypeDelegator : TypeDelegator
    {
        public string myElementType = null;
        private Type myType = null;
        public MyTypeDelegator(Type myType) : base(myType)
        {
            this.myType = myType;
        }
        // Override Type.HasElementTypeImpl().
        protected override bool HasElementTypeImpl()
        {
            // Determine whether the type is an array.
            if (myType.IsArray)
            {
                myElementType = "array";
                return true;
            }
            // Determine whether the type is a reference.
            if (myType.IsByRef)
            {
                myElementType = "reference";
                return true;
            }
            // Determine whether the type is a pointer.
            if (myType.IsPointer)
            {
                myElementType = "pointer";
                return true;
            }
            // Return false if the type is not a reference, array, or pointer type.
            return false;
        }
    }

    class PropertyIsByRef : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsByRef : ");
            Console.WriteLine("\tpublic bool IsByRef { get; }");
            Console.WriteLine("\t获取一个值，该值指示 Type 是否由引用传递;");

            Console.WriteLine("\tType.IsPointer : ");
            Console.WriteLine("\tpublic bool IsPointer { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否为指针;");
        }

        public override void Run()
        {
            base.Run();


            try
            {
                int myInt = 0;
                int[] myArray = new int[5];
                ShowInfo(myArray.GetType());
                ShowInfo(myInt.GetType());

                MethodInfo mi = typeof(PropertyHasElementType).GetMethod("Test");
                ParameterInfo[] parms = mi.GetParameters();
                for (int i = 0; i < parms.Length; ++i)
                {
                    ShowInfo(parms[i].ParameterType);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }

        private void ShowInfo(Type t)
        {
            MyTypeDelegator myType = new MyTypeDelegator(t);
            Console.WriteLine("\t\t\t" + t + " > ");
            // Determine whether myType is an array, pointer, reference type.
            Console.WriteLine("\t\t\t\tDetermine whether a variable is an array, pointer, or reference type.");
            if (myType.HasElementType)
                Console.WriteLine("\t\t\t\tThe type of myArray is {0}.", myType.myElementType);
            else
                Console.WriteLine("\t\t\t\tmyArray is not an array, pointer, or reference type.");
        }
    }
}
