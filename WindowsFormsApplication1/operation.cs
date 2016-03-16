using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public abstract class operation : formula_member
    {
        public abstract override string ToString();
        public abstract int dimension { get; }
    }
}
