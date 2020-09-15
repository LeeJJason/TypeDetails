using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Method
{
    class MethodEquals : TypeMethodRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.Equals : ");
            Console.WriteLine("\tpublic virtual bool Equals (Type o);");
            Console.WriteLine("\tpublic override bool Equals (object o);");
            Console.WriteLine("\t确定当前 Type 的基础系统类型是否与指定 Object 或 Type 的基础系统类型相同;");
        }

        public override void Run()
        {
            base.Run();

            Type a = typeof(System.String);
            Type b = typeof(System.Int32);
            Console.WriteLine("\t\tEquals (Type o)");
            Console.WriteLine("\t\t\t{0} == {1}: {2}", a, b, a.Equals(b));

            // The Type objects in a and b are not equal,
            // because they represent different types.

            a = typeof(MethodEquals);
            b = new MethodEquals().GetType();

            Console.WriteLine("\t\t\t{0} is equal to {1}: {2}", a, b, a.Equals(b));

            // The Type objects in a and b are equal,
            // because they both represent type Example.

            b = typeof(Type);

            Console.WriteLine("\t\t\ttypeof({0}).Equals(typeof({1})): {2}", a, b, a.Equals(b));

            Console.WriteLine("\t\tEquals (object o)");
            Type t = typeof(int);
            Object obj1 = typeof(int).GetTypeInfo();
            IsEqualTo(t, obj1);

            Object obj2 = typeof(String);
            IsEqualTo(t, obj2);

            t = typeof(Object);
            Object obj3 = typeof(Object);
            IsEqualTo(t, obj3);

            t = typeof(List<>);
            Object obj4 = (new List<String>()).GetType();
            IsEqualTo(t, obj4);

            t = typeof(Type);
            Object obj5 = null;
            IsEqualTo(t, obj5);
        }

        private static void IsEqualTo(Type t, Object inst)
        {
            Type t2 = inst as Type;
            if (t2 != null)
                Console.WriteLine("\t\t\t{0} = {1}: {2}", t.Name, t2.Name, t.Equals(inst));
            else
                Console.WriteLine("\t\t\tCannot cast the argument to a type.");
        }
    }
}
