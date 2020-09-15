using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class A
{
    public class B { }
    private class C { }

    public void Log()
    {
        Console.WriteLine("\n\t\t|public A|  |public A + public B|  |public A + private C|\n");
        string format = "\t\t{0, -15}\t{1, -15}\t{2, -15}\t{3, -15}\t{4, -15}";
        Console.WriteLine(format, "Class", "IsNotPublic", "IsPublic", "IsNestedPublic", "IsNestedPrivate");
        Type[] ts = { typeof(A), typeof(A.B), typeof(A.C) };
        for (int i = 0; i < ts.Length; ++i)
        {
            Console.WriteLine(format, ts[i], ts[i].IsNotPublic, ts[i].IsPublic, ts[i].IsNestedPublic, ts[i].IsNestedPrivate);
        }
    }
}
/*
Class   IsNotPublic     IsPublic    IsNestedPublic      IsNestedPrivate
A       FALSE           TRUE        FALSE               FALSE
B       FALSE           FALSE       TRUE                FALSE
C       FALSE           FALSE       FALSE               TRUE
*/
namespace TypeDetails.TypeModel.Property
{
    /// <summary>
    ///  Public Class<IsPublic>: True
    /// </summary>
    public class OuterClass
    {
        /// <summary>
        /// Nested Class<IsNested>: True
        /// Nested Private Class<IsNestedPrivate>: True
        /// </summary>
        private class PrivateClass
        { }
        /// <summary>
        /// Nested Class<IsNested>: True
        /// Nested Protected Class<IsNestedFamily>: True
        /// </summary>
        protected class ProtectedClass
        { }
        /// <summary>
        /// Nested Class<IsNested>: True
        /// Nested Internal Class<IsNestedAssembly>: True
        /// </summary>
        internal class InternalClass
        { }
        /// <summary>
        /// Nested Class<IsNested>: True
        /// Nested Family Or Assembly Class<IsNestedFamORAssem>: True
        /// </summary>
        protected internal class ProtectedInternalClass
        { }
        /// <summary>
        /// Nested Class<IsNested>: True
        /// Nested Public Class<IsNestedPublic>: True
        /// </summary>
        public class PublicClass
        { }

        public void Log()
        {
            // Create an array of Type objects for all the classes.
            Type[] types = { typeof(OuterClass),
                         typeof(OuterClass.PublicClass),
                         typeof(OuterClass.PrivateClass),
                         typeof(OuterClass.ProtectedClass),
                         typeof(OuterClass.InternalClass),
                         typeof(OuterClass.ProtectedInternalClass) };

            foreach (var type in types)
            {
                Console.WriteLine("\t\t{0} property values:", type.Name);
                Console.WriteLine("\t\t\tPublic Class: {0}", type.IsPublic);
                Console.WriteLine("\t\t\tNot a Public Class: {0}", type.IsNotPublic);
                Console.WriteLine("\t\t\tNested Class: {0}", type.IsNested);
                Console.WriteLine("\t\t\tNested Private Class: {0}", type.IsNestedPrivate);
                Console.WriteLine("\t\t\tNested Internal Class: {0}", type.IsNestedAssembly);
                Console.WriteLine("\t\t\tNested Protected Class: {0}", type.IsNestedFamily);
                Console.WriteLine("\t\t\tNested Family Or Assembly Class: {0}", type.IsNestedFamORAssem);
                Console.WriteLine("\t\t\tNested Family And Assembly Class: {0}", type.IsNestedFamANDAssem);
                Console.WriteLine("\t\t\tNested Public Class: {0}", type.IsNestedPublic);
            }
        }
    }

    class PropertyIsNested : TypePropertyRunner
    {

        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsNested : ");
            Console.WriteLine("\tpublic bool IsNested { get; }");
            Console.WriteLine("\t获取一个指示当前 Type 对象是否表示其定义嵌套在另一个类型的定义之内的类型的值;");

            Console.WriteLine("\tType.IsPublic : ");
            Console.WriteLine("\tpublic bool IsPublic { get; }");
            Console.WriteLine("\t获取一个值，该值指示 Type 是否声明为公共类型;");

            Console.WriteLine("\tType.IsNestedPublic : ");
            Console.WriteLine("\tpublic bool IsNestedPublic { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示类是否是嵌套的并且声明为公共的;");

            Console.WriteLine("\tType.IsNestedPrivate : ");
            Console.WriteLine("\tpublic bool IsNestedPrivate { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是嵌套的并声明为私有;");

            Console.WriteLine("\tType.IsNestedPrivate : ");
            Console.WriteLine("\tpublic bool IsNestedPrivate { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是嵌套的并声明为私有;");

            Console.WriteLine("\tType.IsNestedAssembly : ");
            Console.WriteLine("\tpublic bool IsNestedAssembly { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是嵌套的并且只能在它自己的程序集内可见;");

            Console.WriteLine("\tType.IsNestedFamily : ");
            Console.WriteLine("\tpublic bool IsNestedFamily { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是嵌套的并且只能在它自己的家族内可见;");

            Console.WriteLine("\tType.IsNestedFamORAssem : ");
            Console.WriteLine("\tpublic bool IsNestedFamORAssem { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是嵌套的并且只对属于它自己的家族或属于它自己的程序集的类可见;");

            Console.WriteLine("\tType.IsNestedFamANDAssem : ");
            Console.WriteLine("\tpublic bool IsNestedFamANDAssem { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否是嵌套的并且只对同时属于自己家族和自己程序集的类可见;");
        }

        public override void Run()
        {
            base.Run();

            new OuterClass().Log();
            new A().Log();
        }
    }
}
