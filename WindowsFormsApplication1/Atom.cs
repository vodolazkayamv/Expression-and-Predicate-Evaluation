using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Atom : formula_member
    {
        private string _name;
        public Atom(string n)
        {
            _name = n;
        }


        public string get_name
        {       get
            {
                return _name;    
            }
            set { }
        }


        public override string ToString()
        {
            return this.get_name;
        }


    }
}
