using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    enum Number//定义一个数字枚举
    {
        one, two, three, four
    }

    public class Name_Name { }

    class PropertyIsSpecialName : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsSpecialName : ");
            Console.WriteLine("\tpublic bool IsSpecialName { get; }");
            Console.WriteLine("\t获取一个值，该值指示该类型是否具有需要特殊处理的名称;");
        }

        public override void Run()
        {
            base.Run();

            
            Type t = typeof(Name_Name);
            Console.WriteLine("\t\t{0} => {1}", t, t.IsSpecialName);
            var infos = typeof(List<int>).GetMethods();
            for (int i = 0; i < infos.Length; ++i)
            {
                Console.WriteLine("\t\t{0} => {1}", infos[i], infos[i].IsSpecialName);
            }
        }
    }
}
