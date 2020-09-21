using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails.BindingFlagsModel
{
    class BindingFlagsModelRunner : ModelRunner
    {
        public override void Run()
        {
            Run<BindingFlagsRunner>();
        }
    }
}
