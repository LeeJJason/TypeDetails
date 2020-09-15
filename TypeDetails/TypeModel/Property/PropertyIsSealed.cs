using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    // Declare InnerClass as sealed.
    sealed public class InnerClass
    {
    }

    class PropertyIsSealed : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.IsSealed : ");
            Console.WriteLine("\tpublic bool IsSealed { get; }");
            Console.WriteLine("\t获取一个值，该值指示 Type 是否声明为密封的;");
        }

        public override void Run()
        {
            base.Run();

            InnerClass inner = new InnerClass();
            // Get the type of InnerClass.
            Type t = inner.GetType();
            // Get the IsSealed property of  innerClass.
            Console.WriteLine("\t\t{0} is sealed: {1}.", t.FullName, t.IsSealed);
            t = this.GetType();
            // Get the IsSealed property of  innerClass.
            Console.WriteLine("\t\t{0} is sealed: {1}.", t.FullName, t.IsSealed);
        }
    }
}
