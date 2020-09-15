using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyMemberType : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.MemberType : ");
            Console.WriteLine("\tpublic virtual bool MemberType { get; }");
            Console.WriteLine("\t获取一个指示此成员是类型还是嵌套类型的 MemberTypes 值;");
        }

        public override void Run()
        {
            base.Run();
            // Get the type of a chosen class.
            Type t = typeof(ReflectionTypeLoadException);

            // Get the MemberInfo array.
            MemberInfo[] members = t.GetMembers();

            // Get and display the name and the MemberType for each member.
            Console.WriteLine("\t\tMembers of {0}", t.Name);
            foreach (var member in members)
            {
                MemberTypes memberType = member.MemberType;
                Console.WriteLine("\t\t\t{0}: {1}", member.Name, memberType);
            }
        }
    }
}
