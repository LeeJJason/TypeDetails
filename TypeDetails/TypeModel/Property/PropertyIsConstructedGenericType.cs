using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyIsConstructedGenericType : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsConstructedGenericType : ");
            Console.WriteLine("\tpublic virtual bool IsConstructedGenericType { get; }");
            Console.WriteLine("\t获取指示此对象是否表示构造的泛型类型的值。 你可以创建构造型泛型类型的实例;");
        }

        public override void Run()
        {
            base.Run();

            Type t = typeof(List<>);
            Console.WriteLine("\t\t{0} IsConstructedGenericType : {1}", t, t.IsConstructedGenericType);
            t = typeof(List<int>);
            Console.WriteLine("\t\t{0} IsConstructedGenericType : {1}", t, t.IsConstructedGenericType);
            t = typeof(PropertyIsConstructedGenericType);
            Console.WriteLine("\t\t{0} IsConstructedGenericType : {1}", t, t.IsConstructedGenericType);
        }
    }
}
