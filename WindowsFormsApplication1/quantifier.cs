using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class quantifier : operation
    {
        private string _quant;
        private string _var;

        public quantifier()
        {
            _quant = Properties.Settings.Default.All;
        }


        public quantifier(string got_quant)
        {
            _quant = got_quant;
        }

        public quantifier(string got_quant, string got_variable)
        {
            _quant = got_quant;
            _var = got_variable;
        }

        //конструктор копирования:
        public quantifier(quantifier copy)
        {
            _quant = copy._quant;
            _var = copy._var;
        }

        public string variable
        {
            get
            { return _var; }
            set
            { _var = value; }
        }


        public bool is_universality
        {
            get
            {
                return (_quant == Properties.Settings.Default.All);
            }
        }

        public bool is_existance
        {
            get
            {
                return (_quant == Properties.Settings.Default.Exists);
            }
        }

        public void change_quant()
        {
            if (_quant == Properties.Settings.Default.Exists)
                _quant = Properties.Settings.Default.All;
            else
                _quant = Properties.Settings.Default.Exists;
        }

        public override string ToString()
        {
            if (_quant == Properties.Settings.Default.All)
                return Properties.Settings.Default.All + " " + _var + " ";
            else if (_quant == Properties.Settings.Default.Exists)
                return Properties.Settings.Default.Exists + " " + _var + " ";
            else
            {
                throw new Exception("Неверный квантор");
            }
        }

        public override int dimension
        {
            get { return 1; }
        }

    }
}
