using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypeDetails.TypeModel.Field;
using TypeDetails.TypeModel.Property;

namespace TypeDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            new TypeModel.TypeModelRunner().Run();
        }
    }
}
