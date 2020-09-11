using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Field
{
    class FieldFilterAttribute : TypeFieldRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("Type.FilterAttribute : ");
            Console.WriteLine("\tpublic static readonly System.Reflection.MemberFilter FilterAttribute;");
            Console.WriteLine("\t表示用于属性的成员过滤器;");
        }

        public override void Run()
        {
            base.Run();
            try
            {
                MemberFilter myFilter = Type.FilterAttribute;
                Type myType = typeof(System.String);
                MemberInfo[] myMemberInfoArray = myType.FindMembers(MemberTypes.Constructor | MemberTypes.Method, 
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, OnFilterAttribute, MethodAttributes.SpecialName);
                foreach (MemberInfo myMemberinfo in myMemberInfoArray)
                {
                    Console.WriteLine(string.Format("\t{0} is a {1}", myMemberinfo.Name, myMemberinfo.MemberType.ToString()));
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException : " + e.Message);
            }
            catch (SecurityException e)
            {
                Console.WriteLine("SecurityException : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
        }

        private bool OnFilterAttribute(MemberInfo m, object filterCriteria)
        {
            bool flag = Type.FilterAttribute(m, filterCriteria);
            MethodAttributes a = (MethodAttributes)filterCriteria;
            Console.WriteLine("\t\t" + m.Name + " => " + filterCriteria.GetType().Name + "  " + filterCriteria + " : " + flag);
            MethodBase mb = m as MethodInfo;
            if (mb != null)
            {
                Console.WriteLine("\t\t\t" + (m as MethodInfo).Attributes);
            }

            return flag;
        }
    }
}
