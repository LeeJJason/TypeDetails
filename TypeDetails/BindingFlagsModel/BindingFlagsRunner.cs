using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.BindingFlagsModel
{
    /*
     字段
        CreateInstance	512 
            指定反射应创建指定类型的实例。 
            调用与给定参数匹配的构造函数。 
            忽略提供的成员名称。 
            如果未指定查找的类型，则应用“（实例 | 公共）”。 不能调用类型初始值设定项。
            此标志会传递给 InvokeMember 方法以调用构造函数。
        DeclaredOnly	2	
            指定只应考虑在所提供类型的层次结构级别上声明的成员。 不考虑继承的成员。
        Default	0	
            指定未定义任何绑定标志。
        ExactBinding	65536	
            指定提供的参数的类型必须与对应形参的类型完全匹配。 
            如果调用方提供非 null Binder 对象，则反射会引发异常，因为这意味着调用方在提供将选取适当方法的 BindToXXX 实现。 
            当自定义绑定器可实现此标志的语义时，默认绑定器会忽略此标志。
        FlattenHierarchy	64	
            指定应返回层次结构往上的公共成员和受保护静态成员。 
            不返回继承类中的私有静态成员。 静态成员包括字段、方法、事件和属性。 不支持嵌套类型。
        GetField	1024	
            指定应返回指定字段的值。
            此标志会传递给 InvokeMember 方法以获取字段值。
        GetProperty	4096	
            指定应返回指定属性的值。
            此标志会传递给 InvokeMember 方法以调用属性 getter。
        IgnoreCase	1	
            指定在绑定时不应考虑成员名称的大小写。
        IgnoreReturn	16777216	
            在 COM 互操作中用于指定可以忽略成员的返回值。
        Instance	4	
            指定实例成员要包括在搜索中。
        InvokeMethod	256	
            指定要调用的方法。 这不必是构造函数或类型初始值设定项。
            此标志会传递给 InvokeMember 方法以调用方法。
        NonPublic	32	
            指定非公共成员要包括在搜索中。
        OptionalParamBinding	262144	
            返回其参数计数与提供的参数数量匹配的成员集。 
            此绑定标志用于参数具有默认值的方法和使用变量参数 (varargs) 的方法。 
            此标志只应与 InvokeMember(String, BindingFlags, Binder, Object, Object[], ParameterModifier[], CultureInfo, String[]) 结合使用。
            使用默认值的参数仅在省略了尾随参数的调用中使用。 它们必须是位于最后面的参数。
        Public	16	
            指定公共成员要包括在搜索中。
        PutDispProperty	16384	
            指定应调用 COM 对象上的 PROPPUT 成员。 PROPPUT 指定使用值的属性设置函数。 
            如果属性同时具有 PROPPUT 和 PROPPUTREF 并且你需要区分调用哪一个，请使用 PutDispProperty。
        PutRefDispProperty	32768	
            指定应调用 COM 对象上的 PROPPUTREF 成员。 PROPPUTREF 指定使用引用而不是值的属性设置函数。 
            如果属性同时具有 PROPPUT 和 PROPPUTREF 并且你需要区分调用哪一个，请使用 PutRefDispProperty。
        SetField	2048	
            指定应设置指定字段的值。
            此标志会传递给 InvokeMember 方法以设置字段值。
        SetProperty	8192	
            指定应设置指定属性的值。 对于 COM 属性，指定此绑定标志等效于指定 PutDispProperty 和 PutRefDispProperty。
            此标志会传递给 InvokeMember 方法以调用属性 setter。
        Static	8	
            指定静态成员要包括在搜索中。
        SuppressChangeType	131072	
            未实现。
     */
    class BindingFlagsRunner : Runner
    {
        protected override void HeaderOut()
        {
            Console.WriteLine("\tBindingFlags : ");
            Console.WriteLine("\t指定控制绑定以及通过反射执行成员和类型搜索的方式的标记;");
        }

        public override void Run()
        {
            base.Run();

            // BindingFlags.InvokeMethod
            // Call a static method.
            Type t = typeof(TestClass);

            Console.WriteLine();
            Console.WriteLine("\t\tInvoking a static method.");
            Console.WriteLine("\t\t-------------------------");
            t.InvokeMember("SayHello", BindingFlags.InvokeMethod | BindingFlags.Public |
                BindingFlags.Static, null, null, new object[] { });

            // BindingFlags.InvokeMethod
            // Call an instance method.
            TestClass c = new TestClass();
            Console.WriteLine();
            Console.WriteLine("\t\tInvoking an instance method.");
            Console.WriteLine("\t\t----------------------------");
            c.GetType().InvokeMember("AddUp", BindingFlags.InvokeMethod, null, c, new object[] { });
            c.GetType().InvokeMember("AddUp", BindingFlags.InvokeMethod, null, c, new object[] { });

            // BindingFlags.InvokeMethod
            // Call a method with parameters.
            object[] args = new object[] { 100.09, 184.45 };
            object result;
            Console.WriteLine();
            Console.WriteLine("\t\tInvoking a method with parameters.");
            Console.WriteLine("\t\t---------------------------------");
            result = t.InvokeMember("ComputeSum", BindingFlags.InvokeMethod, null, null, args);
            Console.WriteLine("\t\t{0} + {1} = {2}", args[0], args[1], result);

            // BindingFlags.GetField, SetField
            Console.WriteLine();
            Console.WriteLine("\t\tInvoking a field (getting and setting.)");
            Console.WriteLine("\t\t--------------------------------------");
            // Get a field value.
            result = t.InvokeMember("Name", BindingFlags.GetField, null, c, new object[] { });
            Console.WriteLine("\t\tName == {0}", result);
            // Set a field.
            t.InvokeMember("Name", BindingFlags.SetField, null, c, new object[] { "NewName" });
            result = t.InvokeMember("Name", BindingFlags.GetField, null, c, new object[] { });
            Console.WriteLine("\t\tName == {0}", result);

            Console.WriteLine();
            Console.WriteLine("\t\tInvoking an indexed property (getting and setting.)");
            Console.WriteLine("\t\t--------------------------------------------------");
            // BindingFlags.GetProperty
            // Get an indexed property value.
            int index = 3;
            result = t.InvokeMember("Item", BindingFlags.GetProperty, null, c, new object[] { index });
            Console.WriteLine("\t\tItem[{0}] == {1}", index, result);
            // BindingFlags.SetProperty
            // Set an indexed property value.
            index = 3;
            t.InvokeMember("Item", BindingFlags.SetProperty, null, c, new object[] { index, "NewValue" });
            result = t.InvokeMember("Item", BindingFlags.GetProperty, null, c, new object[] { index });
            Console.WriteLine("\t\tItem[{0}] == {1}", index, result);

            Console.WriteLine();
            Console.WriteLine("\t\tGetting a field or property.");
            Console.WriteLine("\t\t----------------------------");
            // BindingFlags.GetField
            // Get a field or property.
            result = t.InvokeMember("Name", BindingFlags.GetField | BindingFlags.GetProperty, null, c,
                new object[] { });
            Console.WriteLine("\t\tName == {0}", result);
            // BindingFlags.GetProperty
            result = t.InvokeMember("Value", BindingFlags.GetField | BindingFlags.GetProperty, null, c,
                new object[] { });
            Console.WriteLine("\t\tValue == {0}", result);

            Console.WriteLine();
            Console.WriteLine("\t\tInvoking a method with named parameters.");
            Console.WriteLine("\t\t---------------------------------------");
            // BindingFlags.InvokeMethod
            // Call a method using named parameters.
            object[] argValues = new object[] { "Mouse", "Micky" };
            String[] argNames = new String[] { "lastName", "firstName" };
            t.InvokeMember("PrintName", BindingFlags.InvokeMethod, null, null, argValues, null, null,
                argNames);

            Console.WriteLine();
            Console.WriteLine("\t\tInvoking a default member of a type.");
            Console.WriteLine("\t\t------------------------------------");
            // BindingFlags.Default
            // Call the default member of a type.
            Type t3 = typeof(TestClass2);
            t3.InvokeMember("", BindingFlags.InvokeMethod | BindingFlags.Default, null, new TestClass2(),
                new object[] { });

            // BindingFlags.Static, NonPublic, and Public
            // Invoking a member with ref parameters.
            Console.WriteLine();
            Console.WriteLine("\t\tInvoking a method with ref parameters.");
            Console.WriteLine("\t\t--------------------------------------");
            MethodInfo m = t.GetMethod("Swap");
            args = new object[2];
            args[0] = 1;
            args[1] = 2;
            m.Invoke(new TestClass(), args);
            Console.WriteLine("\t\t{0}, {1}", args[0], args[1]);

            // BindingFlags.CreateInstance
            // Creating an instance with a parameterless constructor.
            Console.WriteLine();
            Console.WriteLine("\t\tCreating an instance with a parameterless constructor.");
            Console.WriteLine("\t\t------------------------------------------------------");
            object cobj = t.InvokeMember("TestClass", BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.CreateInstance,
                null, null, new object[] { });
            Console.WriteLine("\t\tInstance of {0} created.", cobj.GetType().Name);

            // Creating an instance with a constructor that has parameters.
            Console.WriteLine();
            Console.WriteLine("\t\tCreating an instance with a constructor that has parameters.");
            Console.WriteLine("\t\t------------------------------------------------------------");
            cobj = t.InvokeMember("TestClass", BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.CreateInstance,
                null, null, new object[] { "Hello, World!" });
            Console.WriteLine("\t\tInstance of {0} created with initial value '{1}'.", cobj.GetType().Name,
                cobj.GetType().InvokeMember("Name", BindingFlags.GetField, null, cobj, null));

            // BindingFlags.DeclaredOnly
            Console.WriteLine();
            Console.WriteLine("\t\tDeclaredOnly instance members.");
            Console.WriteLine("\t\t------------------------------");
            System.Reflection.MemberInfo[] memInfo =
                t.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                BindingFlags.Public);
            for (int i = 0; i < memInfo.Length; i++)
            {
                Console.WriteLine("\t\t" + memInfo[i].Name);
            }

            // BindingFlags.IgnoreCase
            Console.WriteLine();
            Console.WriteLine("\t\tUsing IgnoreCase and invoking the PrintName method.");
            Console.WriteLine("\t\t---------------------------------------------------");
            t.InvokeMember("printname", BindingFlags.IgnoreCase | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.InvokeMethod, null, null, new object[]
                {"Brad","Smith"});

            // BindingFlags.FlattenHierarchy
            Console.WriteLine();
            Console.WriteLine("\t\tUsing FlattenHierarchy to get inherited static protected and public members.");
            Console.WriteLine("\t\t----------------------------------------------------------------------------");
            FieldInfo[] finfos = typeof(MostDerived).GetFields(BindingFlags.NonPublic | BindingFlags.Public |
                  BindingFlags.Static | BindingFlags.FlattenHierarchy);
            foreach (FieldInfo finfo in finfos)
            {
                Console.WriteLine("\t\t{0} defined in {1}.", finfo.Name, finfo.DeclaringType.Name);
            }

            Console.WriteLine();
            Console.WriteLine("\t\tWithout FlattenHierarchy.");
            Console.WriteLine("\t\t-------------------------");
            finfos = typeof(MostDerived).GetFields(BindingFlags.NonPublic | BindingFlags.Public |
                  BindingFlags.Static);
            foreach (FieldInfo finfo in finfos)
            {
                Console.WriteLine("\t\t{0} defined in {1}.", finfo.Name, finfo.DeclaringType.Name);
            }
        }
    }
}

public class TestClass
{
    public String Name;
    private Object[] values = new Object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public Object this[int index]
    {
        get
        {
            return values[index];
        }
        set
        {
            values[index] = value;
        }
    }

    public Object Value
    {
        get
        {
            return "the value";
        }
    }

    public TestClass() : this("initialName") { }
    public TestClass(string initName)
    {
        Name = initName;
    }

    int methodCalled = 0;

    public static void SayHello()
    {
        Console.WriteLine("\t\tHello");
    }

    public void AddUp()
    {
        methodCalled++;
        Console.WriteLine("\t\tAddUp Called {0} times", methodCalled);
    }

    public static double ComputeSum(double d1, double d2)
    {
        return d1 + d2;
    }

    public static void PrintName(String firstName, String lastName)
    {
        Console.WriteLine("\t\t{0},{1}", lastName, firstName);
    }

    public void PrintTime()
    {
        Console.WriteLine(DateTime.Now);
    }

    public void Swap(ref int a, ref int b)
    {
        int x = a;
        a = b;
        b = x;
    }
}

[DefaultMemberAttribute("PrintTime")]
public class TestClass2
{
    public void PrintTime()
    {
        Console.WriteLine("\t\t" + DateTime.Now);
    }

    public void Print()
    {
        Console.WriteLine("\t\t Print");
    }
}

public class Base
{
    static int BaseOnlyPrivate = 0;
    protected static int BaseOnly = 0;
}
public class Derived : Base
{
    public static int DerivedOnly = 0;
}
public class MostDerived : Derived { }
