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
            Type objType = objTest.GetType();
            MemberInfo[] arrayMemberInfo;
            try
            {
                //Find all static or public methods in the Object class that match the specified name.
                arrayMemberInfo = objType.FindMembers(MemberTypes.Method, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance,
                    new MemberFilter(DelegateToSearchCriteria),
                    "ReferenceEquals");

                for (int index = 0; index < arrayMemberInfo.Length; index++)
                    Console.WriteLine("Result of FindMembers -\t" + arrayMemberInfo[index].ToString() + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.ToString());
            }
        }

        public static bool DelegateToSearchCriteria(MemberInfo objMemberInfo, Object objSearch)
        {
            // Compare the name of the member function with the filter criteria.
            if (objMemberInfo.Name.ToString() == objSearch.ToString())
                return true;
            else
                return false;
        }
    }
}
