using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyDeclaringType : TypePropertyRunner
    {
        public abstract class MyClassA
        {
            public abstract int m();
        }

        public abstract class MyClassB : MyClassA
        {
            public abstract int n();
        }

        public class MyClassC<T>
        {

        }

        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.DeclaringType : ");
            Console.WriteLine("\tpublic override Type DeclaringType { get; }");
            Console.WriteLine("\t获取用来声明当前的嵌套类型或泛型类型参数的类型。");
        }

        public override void Run()
        {
            base.Run();
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(PropertyDeclaringType).DeclaringType == null);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(PropertyDeclaringType).GetMethod("Run").DeclaringType);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(PropertyDeclaringType).GetMethod("Generic").GetGenericArguments()[0].DeclaringMethod);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(PropertyDeclaringType).GetMethod("Generic").GetGenericArguments()[0].DeclaringMethod);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(MyClassA).DeclaringType);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(MyClassB).GetMethod("m").DeclaringType);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(MyClassB).GetMethod("n").DeclaringType);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(MyClassC<>).GetGenericArguments()[0].DeclaringType);
            Console.WriteLine("\t\tThe declaring type of m is {0}.", typeof(MyClassC<int>).GetGenericArguments()[0].DeclaringType == null);
        }

        public void Generic<T>()
        {

        }
    }
}
