using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class neg : operation
    {
        public neg()
        {
        //
        }
        
        
        public override int dimension
        {
            get { return 1; }
        }
        
        
        public override string ToString()
        {
            return Properties.Settings.Default.negation;
        }
    }
}
