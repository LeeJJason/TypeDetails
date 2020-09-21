using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypeDetails.TypeModel.Method;
using TypeDetails.TypeModel.Property;

namespace TypeDetails.TypeModel
{
    class TypeModelRunner : ModelRunner
    {
        public override void Run()
        {
            /*
            // Field
            var frs = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where IsSubClassOf(t, typeof(TypeFieldRunner))
                        select t;
            foreach (var type in frs)
            {
                var obj = Activator.CreateInstance(type, true) as TypeFieldRunner;
                obj.Run();
            }
            */
            /*
            // Property
            var frs = from t in Assembly.GetExecutingAssembly().GetTypes()
                      where IsSubClassOf(t, typeof(TypePropertyRunner))
                      select t;
            foreach (var type in frs)
            {
                var obj = Activator.CreateInstance(type, true) as TypePropertyRunner;
                obj.Run();
            }
            */

            /*
            // Method
            var frs = from t in Assembly.GetExecutingAssembly().GetTypes()
                      where IsSubClassOf(t, typeof(TypeMethodRunner))
                      select t;
            foreach (var type in frs)
            {
                var obj = Activator.CreateInstance(type, true) as TypeMethodRunner;
                obj.Run();
            }
            */
            Run<MethodFindMembers>();
        }
    }
}
