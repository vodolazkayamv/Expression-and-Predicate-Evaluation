using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    public class Predicate : formula_member
    {                
        private string _name;
        private ArrayList _arguments;

        public Predicate()
        {
            _name = "";
           _arguments = new ArrayList();
        }


        public Predicate (ArrayList args, string Name)
        {
            _name = Name;
            _arguments = new ArrayList();
            _arguments.AddRange(args);
        }

        public Predicate(Predicate copy)
        {
            _name = copy.name;
            _arguments = new ArrayList(copy.arguments);
        }


        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public ArrayList arguments
        {
            get { return _arguments; }
            set
            {
                _arguments = value;
            }
        }

        public bool Contains(string variable)
        {
            if (_arguments.Contains(variable))
                return true;
            else return false;
        }

        public override string ToString()
        {
            string str;
            ArrayList args = new ArrayList(_arguments);

            str = _name + '(';
            
            while (args.Count > 0)
            {
                if (args[0] is function)
                {
                    str += args[0].ToString();
                    if (args.Count > 1)
                        str += ", ";
                    args.RemoveAt(0);
                }
                else
                {
                    str += args[0];
                    if (args.Count > 1)
                        str += ", ";
                    args.RemoveAt(0);
                }
            }
            
            str += ')';
                        
            return str;
        }
    }
}
