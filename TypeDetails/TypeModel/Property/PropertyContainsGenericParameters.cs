using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    // Define a base class with two type parameters.
    public class Base<T, U> { }

    // Define a derived class. The derived class inherits from a constructed
    // class that meets the following criteria:
    //   (1) Its generic type definition is Base<T, U>.
    //   (2) It specifies int for the first type parameter.
    //   (3) For the second type parameter, it uses the same type that is used
    //       for the type parameter of the derived class.
    // Thus, the derived class is a generic type with one type parameter, but
    // its base class is an open constructed type with one type argument and
    // one type parameter.
    public class Derived<V> : Base<int, V> { }

    class PropertyContainsGenericParameters : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.ContainsGenericParameters : ");
            Console.WriteLine("\tpublic virtual bool ContainsGenericParameters { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前 Type 对象是否具有尚未被特定类型替代的类型参数;");

            Console.WriteLine("\tType.IsGenericTypeDefinition : ");
            Console.WriteLine("\tpublic virtual bool IsGenericTypeDefinition { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前 Type 是否表示可以用来构造其他泛型类型的泛型类型定义;");

            Console.WriteLine("\tType.IsGenericType : ");
            Console.WriteLine("\tpublic virtual bool IsGenericType { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前类型是否是泛型类型;");

            Console.WriteLine("\tType.IsGenericParameter : ");
            Console.WriteLine("\tpublic virtual bool IsGenericParameter { get; }");
            Console.WriteLine("\t获取一个值，该值指示当前 Type 是否表示泛型类型或方法的定义中的类型参数;");
        }

        public override void Run()
        {
            base.Run();

            Console.WriteLine("\t\t--- Display a generic type and the open constructed");
            Console.WriteLine("\t\ttype from which it is derived.");

            // Create a Type object representing the generic type definition 
            // for the Derived type, by omitting the type argument. (For
            // types with multiple type parameters, supply the commas but
            // omit the type arguments.) 
            //
            Type derivedType = typeof(Derived<>);
            DisplayGenericTypeInfo(derivedType);

            // Display its open constructed base type.
            DisplayGenericTypeInfo(derivedType.BaseType);

            DisplayGenericTypeInfo(typeof(Base<,>));
        }

        private static void DisplayGenericTypeInfo(Type t)
        {
            Console.WriteLine("\t\t\t{0}", t);

            Console.WriteLine("\t\t\t\tIs this a generic type definition? {0}",
                t.IsGenericTypeDefinition);

            Console.WriteLine("\t\t\t\tIs it a generic type? {0}",
                t.IsGenericType);

            Console.WriteLine("\t\t\t\tDoes it have unassigned generic parameters? {0}",
                t.ContainsGenericParameters);

            if (t.IsGenericType)
            {
                // If this is a generic type, display the type arguments.
                Type[] typeArguments = t.GetGenericArguments();

                Console.WriteLine("\t\t\t\tList type arguments ({0}):",
                    typeArguments.Length);

                foreach (Type tParam in typeArguments)
                {
                    // IsGenericParameter is true only for generic type parameters.
                    if (tParam.IsGenericParameter)
                    {
                        Console.WriteLine(
                            "\t\t\t\t\t{0}  (unassigned - parameter position {1})",
                            tParam,
                            tParam.GenericParameterPosition);
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t\t{0}", tParam);
                    }
                }
            }
        }
    }
    /*
TypeDetails.TypeModel.Property.Derived`1[V]
    Is this a generic type definition? True
    Is it a generic type? True
    Does it have unassigned generic parameters? True
    List type arguments (1):
         V  (unassigned - parameter position 0)
TypeDetails.TypeModel.Property.Base`2[System.Int32,V]
    Is this a generic type definition? False
    Is it a generic type? True
    Does it have unassigned generic parameters? True
    List type arguments (2):
        System.Int32
        V  (unassigned - parameter position 0)
TypeDetails.TypeModel.Property.Base`2[T,U]
    Is this a generic type definition? True
    Is it a generic type? True
    Does it have unassigned generic parameters? True
    List type arguments (2):
        T  (unassigned - parameter position 0)
        U  (unassigned - parameter position 1)
     * */
}
