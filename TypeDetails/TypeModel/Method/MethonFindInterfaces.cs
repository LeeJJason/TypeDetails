using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TypeDetails.TypeModel.Method
{
    class MethonFindInterfaces : TypeMethodRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.FindInterfaces : ");
            Console.WriteLine("\tpublic virtual Type[] FindInterfaces (System.Reflection.TypeFilter filter, object filterCriteria);");
            Console.WriteLine("\t返回表示接口（由当前 Type 所实现或继承）的筛选列表的 Type 对象数组;");
        }

        public override void Run()
        {
            base.Run();

            try
            {
                XmlDocument myXMLDoc = new XmlDocument();
                myXMLDoc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                    "<title>Pride And Prejudice</title>" + "</book>");
                Type myType = myXMLDoc.GetType();

                // Specify the TypeFilter delegate that compares the
                // interfaces against filter criteria.
                TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);
                String[] myInterfaceList = new String[2]
                    {"System.Collections.IEnumerable",
                "System.Collections.ICollection"};
                for (int index = 0; index < myInterfaceList.Length; index++)
                {
                    Type[] myInterfaces = myType.FindInterfaces(myFilter,
                        myInterfaceList[index]);
                    if (myInterfaces.Length > 0)
                    {
                        Console.WriteLine("\n\t\t{0} implements the interface {1}.",
                            myType, myInterfaceList[index]);
                        for (int j = 0; j < myInterfaces.Length; j++)
                            Console.WriteLine("\t\t\tInterfaces supported: {0}.",
                                myInterfaces[j].ToString());
                    }
                    else
                        Console.WriteLine(
                            "\n\t\t{0} does not implement the interface {1}.",
                            myType, myInterfaceList[index]);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: " + e.Message);
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine("TargetInvocationException: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static bool MyInterfaceFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;
            else
                return false;
        }
    }
}
