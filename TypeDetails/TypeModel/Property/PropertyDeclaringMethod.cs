using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyDeclaringMethod : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsGenericParameter : ");
            Console.WriteLine("\tpublic virtual bool IsGenericParameter { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前 Type 是否表示泛型类型或方法的定义中的类型参数。");

            Console.WriteLine("\tType.DeclaringMethod : ");
            Console.WriteLine("\tpublic virtual System.Reflection.MethodBase DeclaringMethod { get; }");
            Console.WriteLine("\t如果当前 Type 是一个泛型函数的类型参数，返回该声明的函数。");

            Console.WriteLine("\tType.GenericParameterPosition : ");
            Console.WriteLine("\tpublic virtual int GenericParameterPosition { get; }");
            Console.WriteLine("\t当 Type 对象表示泛型类型或泛型方法的类型参数时，获取类型参数在声明它的泛型类型或方法的类型参数列表中的位置。");
        }

        public override void Run()
        {
            base.Run();

            // Create a Type object representing class Example, and
            // get a MethodInfo representing the generic method.
            //
            Type ex = typeof(PropertyDeclaringMethod);
            MethodInfo mi = ex.GetMethod("Generic");

            DisplayGenericMethodInfo(mi);

            // Assign the int type to the type parameter of the Example
            // method.
            //
            MethodInfo miConstructed = mi.MakeGenericMethod(typeof(int));

            DisplayGenericMethodInfo(miConstructed);

            // Invoke the method.
            object[] args = { 42 };
            miConstructed.Invoke(null, args);

            // Invoke the method normally.
            PropertyDeclaringMethod.Generic<int>(42);

            // Get the generic type definition from the closed method,
            // and show it's the same as the original definition.
            //
            MethodInfo miDef = miConstructed.GetGenericMethodDefinition();
            Console.WriteLine("\t\tThe definition is the same: {0}",
                miDef == mi);
        }

        public static void Generic<T>(T toDisplay)
        {
            Console.WriteLine("\t\tHere it is: {0}", toDisplay);
        }

        private static void DisplayGenericMethodInfo(MethodInfo mi)
        {
            Console.WriteLine("\t\t{0}", mi);

            Console.WriteLine("\t\t\tIs this a generic method definition? {0}",
                mi.IsGenericMethodDefinition);

            Console.WriteLine("\t\t\tIs it a generic method? {0}",
                mi.IsGenericMethod);

            Console.WriteLine("\t\t\tDoes it have unassigned generic parameters? {0}",
                mi.ContainsGenericParameters);

            // If this is a generic method, display its type arguments.
            //
            if (mi.IsGenericMethod)
            {
                Type[] typeArguments = mi.GetGenericArguments();

                Console.WriteLine("\t\t\tList type arguments ({0}):",
                    typeArguments.Length);

                foreach (Type tParam in typeArguments)
                {
                    // IsGenericParameter is true only for generic type parameters.
                    if (tParam.IsGenericParameter)
                    {
                        Console.WriteLine("\t\t\t\t{0}  parameter position {1}" +
                            "\n\t\t\t\t   declaring method: {2}",
                            tParam,
                            tParam.GenericParameterPosition,
                            tParam.DeclaringMethod);
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t{0}", tParam);
                    }
                }
            }
        }
    }
}
/*
Void Generic[T](T)
        Is this a generic method definition? True
        Is it a generic method? True
        Does it have unassigned generic parameters? True
        List type arguments (1):
                T  parameter position 0
                    declaring method: Void Generic[T](T)
Void Generic[Int32](Int32)
        Is this a generic method definition? False
        Is it a generic method? True
        Does it have unassigned generic parameters? False
        List type arguments (1):
                System.Int32
Here it is: 42
Here it is: 42
The definition is the same: True 
*/
