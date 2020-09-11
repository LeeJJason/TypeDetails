using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.TypeModel.Property
{
    class PropertyAssembly : TypePropertyRunner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tType.Assembly : ");
            Console.WriteLine("\tpublic abstract System.Reflection.Assembly Assembly { get; }");
            Console.WriteLine("\t获取在其中声明该类型的 Assembly。 对于泛型类型，则获取在其中定义该泛型类型的 Assembly;");

            Console.WriteLine("\tType.AssemblyQualifiedName : ");
            Console.WriteLine("\tpublic abstract string AssemblyQualifiedName { get; }");
            Console.WriteLine("\tType 的程序集限定名，其中包括从中加载 Type 的程序集的名称；或者为 null（如果当前实例表示泛型类型参数）;");
        }

        public override void Run()
        {
            base.Run();

            Type objType = typeof(Array);

            // Print the assembly full name.
            Console.WriteLine("\t\tArray Assembly full name: " + objType.Assembly.FullName);

            // Print the assembly qualified name.
            Console.WriteLine("\t\tArray Assembly qualified name : " + objType.AssemblyQualifiedName);

            objType = typeof(List<int>);
            // Print the assembly full name.
            Console.WriteLine("\t\tList<int> Assembly full name: " + objType.Assembly.FullName);
            // Print the assembly qualified name.
            Console.WriteLine("\t\tList<int> Assembly qualified name : " + objType.AssemblyQualifiedName);

            Run<PropertyAssembly>();
        }

        public void Run<T>()
        {
            Type objType = typeof(T);
            // Print the assembly full name.
            Console.WriteLine("\t\tT Assembly full name: " + objType.Assembly.FullName);
            // Print the assembly qualified name.
            Console.WriteLine("\t\tT Assembly qualified name : " + objType.AssemblyQualifiedName);
        }
    }
}
