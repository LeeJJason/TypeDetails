using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeDetails
{
    public abstract class Runner
    {
        protected abstract void HeaderOut();

        public virtual void Run()
        {
            Console.WriteLine("\r\n---------------------------------------------------------------------------------------------");
            Console.WriteLine(this.GetType());
            HeaderOut();
        }
    }
}
