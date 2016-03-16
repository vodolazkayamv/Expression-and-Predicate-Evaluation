using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class empty_operator : operation
    {
        public empty_operator()
        {
            //
        }

        public override string ToString()
        {
            return "";
        }

        public override int dimension
        {
            get { return 0; }
        }
    }
}
