using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyBaseType : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.BaseType : ");
            Console.WriteLine("\tpublic abstract Type BaseType { get; }");
            Console.WriteLine("\t当前 Type 直接从中继承的 Type；或者如果当前 null 表示 Type 类或一个接口，则为 Object;");
        }

        public override void Run()
        {
            base.Run();
            Type t = typeof(PropertyBaseType);
            TypeInfo(t);

        }

        private void TypeInfo(Type t)
        {
            Console.WriteLine("\t\t" + t.FullName);
            if (t.BaseType != null)
            {
                TypeInfo(t.BaseType);
            }
        }
    }
}
