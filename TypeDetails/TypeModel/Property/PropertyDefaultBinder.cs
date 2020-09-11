using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyDefaultBinder : TypePropertyRunner
    {
        /// <summary>
        /// 参考 http://m.myexception.cn/c-sharp/1947909.html
        /// </summary>
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.DefaultBinder : ");
            Console.WriteLine("\tpublic static System.Reflection.Binder DefaultBinder { get; }");
            Console.WriteLine("\t获取默认联编程序的引用，该程序实现的内部规则用于选择由 InvokeMember(String, BindingFlags, Binder, Object, Object[], ParameterModifier[], CultureInfo, String[]) 调用的合适成员。");
        }

        public override void Run()
        {
            base.Run();
            try
            {
                Binder defaultBinder = Type.DefaultBinder;
                // Invoke the HelloWorld method of MyClass.
                this.GetType().InvokeMember("HelloWorld", BindingFlags.InvokeMethod,
                    defaultBinder, this, new object[] { });
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
        }

        public void HelloWorld()
        {
            Console.WriteLine("\t\tHello World");
        }
    }
}
