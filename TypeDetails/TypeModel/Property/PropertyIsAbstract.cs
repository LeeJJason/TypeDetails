using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    public abstract class AbstractClass
    { }

    public class DerivedClass : AbstractClass
    { }

    public sealed class SingleClass
    { }

    public interface ITypeInfo
    {
        string GetName();
    }

    public class ImplementingClass : ITypeInfo
    {
        public string GetName()
        {
            return this.GetType().FullName;
        }
    }

    delegate string InputOutput(string inp);

    class PropertyIsAbstract : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsAbstract : ");
            Console.WriteLine("\tpublic bool IsAbstract { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否为抽象的并且必须被重写;");
        }

        public override void Run()
        {
            base.Run();

            Type[] types = { typeof(AbstractClass),
                      typeof(DerivedClass),
                      typeof(ITypeInfo),
                      typeof(SingleClass),
                      typeof(ImplementingClass),
                      typeof(InputOutput) };
            foreach (var type in types)
                Console.WriteLine("\t\t{0} is abstract: {1}",
                                  type.Name, type.IsAbstract);
        }
    }
}
