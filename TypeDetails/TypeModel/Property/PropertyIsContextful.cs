using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    public class ContextBoundClass : ContextBoundObject
    {
        public string Value = "The Value property.";
    }
    /*
        protected virtual bool IsContextfulImpl()
        {
            return typeof(ContextBoundObject).IsAssignableFrom(this);
        }

        原来内部是调用了Type.IsAssignableFrom(Type c)这个方法。
        我们来看IsAssignableFrom方法的解释:如果满足下列任一条件，则为 true：
            c 和当前 Type 表示同一类型；当前 Type 位于 c 的继承层次结构中；
            当前 Type 是 c 实现的接口；
            c 是泛型类型参数且当前 Type 表示 c 的约束之一。 
            如果不满足上述任何一个条件或者 c 为 null，则为 false。 
        终上所述，我们可以知道，Type.IsContextful是用于判断类型是否是上下文绑定对象。即类型是否继承于:ContextBoundObject
     */
    class PropertyIsContextful : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsConstructedGenericType : ");
            Console.WriteLine("\tpublic virtual bool IsConstructedGenericType { get; }");
            Console.WriteLine("\t获取指示此对象是否表示构造的泛型类型的值。 你可以创建构造型泛型类型的实例;");

            Console.WriteLine("\tType.IsMarshalByRef : ");
            Console.WriteLine("\tpublic bool IsMarshalByRef { get; }");
            Console.WriteLine("\t获取一个值，该值指示 Type 是否按引用进行封送;");

            Console.WriteLine("\tType.IsPrimitive : ");
            Console.WriteLine("\tpublic bool IsPrimitive { get; }");
            Console.WriteLine("\t获取一个值，通过该值指示 Type 是否为基元类型之一;");
        }

        public override void Run()
        {
            base.Run();
            // Determine whether the types can be hosted in a Context.
            Console.WriteLine("\t\tThe IsContextful property for the {0} type is {1}.", typeof(PropertyIsContextful).Name, typeof(PropertyIsContextful).IsContextful);
            Console.WriteLine("\t\tThe IsContextful property for the {0} type is {1}.", typeof(ContextBoundClass).Name, typeof(ContextBoundClass).IsContextful);

            // Determine whether the types are marshalled by reference.
            Console.WriteLine("\t\tThe IsMarshalByRef property of {0} is {1}.", typeof(PropertyIsContextful).Name, typeof(PropertyIsContextful).IsMarshalByRef);
            Console.WriteLine("\t\tThe IsMarshalByRef property of {0} is {1}.", typeof(ContextBoundClass).Name, typeof(ContextBoundClass).IsMarshalByRef);

            // Determine whether the types are primitive datatypes.
            Console.WriteLine("\t\t{0} is a primitive data type: {1}.", typeof(int).Name, typeof(int).IsPrimitive);
            Console.WriteLine("\t\t{0} is a primitive data type: {1}.", typeof(string).Name, typeof(string).IsPrimitive);
        }
    }
}
