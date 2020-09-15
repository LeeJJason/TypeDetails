using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyGenericTypeArguments : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.GenericTypeArguments : ");
            Console.WriteLine("\tpublic virtual Type[] GenericTypeArguments { get; }");
            Console.WriteLine("\t此类型的泛型类型参数的数组。");
        }

        public override void Run()
        {
            base.Run();
            ShowType(this.GetType());
            ShowType(typeof(List<>));
            ShowType(typeof(List<int>));
            Type t = typeof(Derived<int>);
            ShowType(t);
            ShowType(t.BaseType);
            t = typeof(Derived<>);
            ShowType(t);
            ShowType(t.BaseType);
        }

        public void ShowType(Type t)
        {
            Type[] ts = t.GenericTypeArguments;
            Console.WriteLine("\t\tType : " + t + " => " + ts.Length);
            for (int i = 0; i < ts.Length; ++i)
            {
                Console.WriteLine("\t\t\t" + i + " : " + ts[i] + " => " + ts[i].IsGenericParameter);
            }

            TypeInfo ti = t.GetTypeInfo();
            ts = ti.GenericTypeArguments;
            Console.WriteLine("\t\tTypeInfo : " + t + " => " + ts.Length);
            for (int i = 0; i < ts.Length; ++i)
            {
                Console.WriteLine("\t\t\t" + i + " : " + ts[i] + " => " + ts[i].IsGenericParameter);
            }
        }
    }
}
