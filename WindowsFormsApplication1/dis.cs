using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class dis : operation
    {
        public dis() { }
        public override int dimension
        {
            get { return 2; }
        }
        public override string ToString()
        {
            return Properties.Settings.Default.disjunct;
        }
    }
}
