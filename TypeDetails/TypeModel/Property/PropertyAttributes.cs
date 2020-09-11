using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    internal struct S
    {
        public int X;
    }


    class PropertyAttributes : TypePropertyRunner
    {
        protected sealed class NestedClass { }

        public interface INested { }


        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.Attributes : ");
            Console.WriteLine("\tpublic System.Reflection.TypeAttributes Attributes { get; }");
            Console.WriteLine("\t表示 TypeAttributes 的属性集的 Type 对象，除非 Type 表示泛型类型形参，在此情况下该值未指定;");
        }

        public override void Run()
        {
            base.Run();


            Type[] types = { typeof(PropertyAttributes), typeof(NestedClass),
                         typeof(INested), typeof(S) };

            foreach (var t in types)
            {
                Console.WriteLine("\t\tAttributes for type {0}:", t.Name);

                TypeAttributes attr = t.Attributes;

                // To test for visibility attributes, you must use the visibility mask.
                TypeAttributes visibility = attr & TypeAttributes.VisibilityMask;
                switch (visibility)
                {
                    case TypeAttributes.NotPublic:
                        Console.WriteLine("\t\t\t...is not public");
                        break;
                    case TypeAttributes.Public:
                        Console.WriteLine("\t\t\t...is public");
                        break;
                    case TypeAttributes.NestedPublic:
                        Console.WriteLine("\t\t\t...is nested and public");
                        break;
                    case TypeAttributes.NestedPrivate:
                        Console.WriteLine("\t\t\t...is nested and private");
                        break;
                    case TypeAttributes.NestedFamANDAssem:
                        Console.WriteLine("\t\t\t...is nested, and inheritable only within the assembly" +
                           "\n         (cannot be declared in C#)");
                        break;
                    case TypeAttributes.NestedAssembly:
                        Console.WriteLine("\t\t\t...is nested and internal");
                        break;
                    case TypeAttributes.NestedFamily:
                        Console.WriteLine("\t\t\t...is nested and protected");
                        break;
                    case TypeAttributes.NestedFamORAssem:
                        Console.WriteLine("\t\t\t...is nested and protected internal");
                        break;
                }

                // Use the layout mask to test for layout attributes.
                TypeAttributes layout = attr & TypeAttributes.LayoutMask;
                switch (layout)
                {
                    case TypeAttributes.AutoLayout:
                        Console.WriteLine("\t\t\t...is AutoLayout");
                        break;
                    case TypeAttributes.SequentialLayout:
                        Console.WriteLine("\t\t\t...is SequentialLayout");
                        break;
                    case TypeAttributes.ExplicitLayout:
                        Console.WriteLine("\t\t\t...is ExplicitLayout");
                        break;
                }

                // Use the class semantics mask to test for class semantics attributes.
                TypeAttributes classSemantics = attr & TypeAttributes.ClassSemanticsMask;
                switch (classSemantics)
                {
                    case TypeAttributes.Class:
                        if (t.IsValueType)
                        {
                            Console.WriteLine("\t\t\t...is a value type");
                        }
                        else
                        {
                            Console.WriteLine("\t\t\t...is a class");
                        }
                        break;
                    case TypeAttributes.Interface:
                        Console.WriteLine("\t\t\t...is an interface");
                        break;
                }

                if ((attr & TypeAttributes.Abstract) != 0)
                {
                    Console.WriteLine("\t\t\t...is abstract");
                }

                if ((attr & TypeAttributes.Sealed) != 0)
                {
                    Console.WriteLine("\t\t\t...is sealed");
                }

                Console.WriteLine();
            }
        }
    }
}
