using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    public class function
    {
        private string _name;
        private ArrayList _arguments;

        public function()
        {
            _name = "";
            _arguments = new ArrayList();
        }

        public function(string n)
        {
            _name = n;
            _arguments = new ArrayList();
        }

        public function (string name, ArrayList args)
        {
            _name = name;
            _arguments = args;
        }

        public function(function copy)
        {
            _name = copy.name;
            _arguments = new ArrayList(copy.arguments);
        }

        public ArrayList arguments
        {
            get
            {
                return _arguments;
            }
            set
            {
                _arguments = new ArrayList(value);
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public bool Contains(string variable)
        {
            if (_arguments.Contains(variable))
                return true;
            else return false;
        }

        public function rename_variable(string this_one, string to_that)
        {
            ArrayList old_args = new ArrayList(_arguments);
            ArrayList new_args = new ArrayList();

            while (old_args.Count > 0)
            {
                if (old_args[0] is function)
                {
                    function fun = new function((function)old_args[0]);
                    old_args[0] = fun.rename_variable(this_one, to_that);
                }
                
                else if ((string)old_args[0] == this_one)
                    new_args.Add(to_that);
                else
                    new_args.Add(old_args[0]);
                
                old_args.RemoveAt(0);
            } 

            function f = new function(name, new_args);
            return f;
        }

        public override string ToString()
        {
            string str;
            ArrayList args = new ArrayList(_arguments);

            str = _name + '(';

            while (args.Count > 0)
            {
                    str += args[0];
                    if (args.Count > 1)
                        str += ", ";
                    args.RemoveAt(0);             
            }

            str += ')';

            return str;
        }

        internal object change_variable(string this_one, function to_this)
        {
            ArrayList old_args = new ArrayList(_arguments);
            ArrayList new_args = new ArrayList();

            while (old_args.Count > 0)
            {
                if (old_args[0] is function)
                {
                    function fun = new function((function)old_args[0]);
                    old_args[0] = fun.change_variable(this_one, to_this);
                }

                else if ((string)old_args[0] == this_one)
                    new_args.Add(to_this);
                else
                    new_args.Add(old_args[0]);

                old_args.RemoveAt(0);
            }

            function f = new function(name, new_args);
            return f;
        }
    }
}
