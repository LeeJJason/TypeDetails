using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Field
{
    class FieldFilterName : TypeFieldRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("Type.FilterName  : ");
            Console.WriteLine("\tpublic static readonly System.Reflection.MemberFilter FilterName;");
            Console.WriteLine("\t表示用于名称的区分大小写的成员过滤器;");
            Console.WriteLine("Type.FilterNameIgnoreCase   : ");
            Console.WriteLine("\tpublic static readonly System.Reflection.MemberFilter FilterNameIgnoreCase;");
            Console.WriteLine("\t表示用于名称的不区分大小写的成员筛选器;");

        }

        public override void Run()
        {
            base.Run();
            MemberInfo[] mi = typeof(string).FindMembers(MemberTypes.Constructor | MemberTypes.Method,
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly,
                    OnFilterName, "*");
            foreach (MemberInfo myMemberinfo in mi)
            {
                Console.WriteLine(string.Format("\t{0} is a {1}", myMemberinfo.Name, myMemberinfo.MemberType.ToString()));
            }
        }

        private bool OnFilterName(MemberInfo m, object filterCriteria)
        {
            bool flag = Type.FilterName(m, filterCriteria);
            Console.WriteLine("\t\t" + m.Name + " => " + filterCriteria.GetType().Name + "  " + filterCriteria + " : " + flag);

            return flag;
        }
    }
}
