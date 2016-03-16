using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class imp : operation
    {
        public imp()
        {
            
        }
    
        public override string ToString()
        {
            return Properties.Settings.Default.implication;
        }

        public override int dimension
        {
            get { return 2; }
        }
    }
}
