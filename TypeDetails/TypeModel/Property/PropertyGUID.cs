using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyGUID : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.GUID : ");
            Console.WriteLine("\tpublic abstract Guid GUID { get; }");
            Console.WriteLine("\t获取与 Type 关联的 GUID;");
        }

        public override void Run()
        {
            base.Run();
            Type myType = typeof(PropertyGUID);
            Guid myGuid = (Guid)myType.GUID;
            Console.WriteLine("The name of the class is " + myType.ToString());
            Console.WriteLine("The ClassId of MyClass is " + myType.GUID);
        }
    }
}
