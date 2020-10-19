using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Method
{
    class MethodFindMembers : TypeMethodRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.FindMembers : ");
            Console.WriteLine("\tpublic virtual System.Reflection.MemberInfo[] FindMembers (System.Reflection.MemberTypes memberType, System.Reflection.BindingFlags bindingAttr, System.Reflection.MemberFilter filter, object filterCriteria);");
            Console.WriteLine("\t返回指定成员类型的 MemberInfo 对象的筛选数组;");
        }

        public override void Run()
        {
            base.Run();

            Object objTest = new Object();
            Type objType = typeof(string);
            MemberInfo[] arrayMemberInfo;
            try
            {
                //Find all static or public methods in the Object class that match the specified name.
                arrayMemberInfo = objType.FindMembers(MemberTypes.All, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance,
                    new MemberFilter(DelegateToSearchCriteria),
                    "ReferenceEquals");

                for (int index = 0; index < arrayMemberInfo.Length; index++)
                    Console.WriteLine("\t\t{0} => {1}", arrayMemberInfo[index].ToString(), arrayMemberInfo[index].MemberType, arrayMemberInfo[index].CustomAttributes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.ToString());
            }
        }

        public static bool DelegateToSearchCriteria(MemberInfo objMemberInfo, Object objSearch)
        {
            if (objMemberInfo.Name.ToString() == objSearch.ToString())
                return true;
            else
                return false;
        }
    }
}
