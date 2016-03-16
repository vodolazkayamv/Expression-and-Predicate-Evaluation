using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class string_helper
    {

        public static operation oper_factory(string s)
        {
            if (s == Properties.Settings.Default.conjunct)         return new kon();
            else if (s == Properties.Settings.Default.disjunct)    return new dis();
            else if (s == Properties.Settings.Default.negation)    return new neg();
            else if (s == Properties.Settings.Default.implication) return new imp();
            else if (s == Properties.Settings.Default.All)         return new quantifier(Properties.Settings.Default.All);
            else if (s == Properties.Settings.Default.Exists)      return new quantifier(Properties.Settings.Default.Exists);
            else throw new Exception("Неверная операция");
        }


        public static ArrayList function_arguments(ref string str, bool del = false)
        {
            ArrayList args = new ArrayList(); //список аргументов

            if (str[0] == ')') //нашли закрывающую скобку => дальше идёт функция (читаем с конца)
            {
                int end_of_arguments = str.IndexOf('('); //найдем, где открывается
                string sub_function = str.Substring(1, end_of_arguments - 1); //возьмем то, что внутри этих скобок
                args.AddRange(function_arguments(ref sub_function, true));
                if (del) str = str.Substring(end_of_arguments); //если надо - вырезать все это, вместе со скобками
            }
            else //нету никакой лишней скобки
            {
                string argument = "";
                if (str.IndexOf(',') != -1)
                {
                    argument = str.Substring(0, str.IndexOf(',')); //имена аргументов (это может быть константа или переменная) разделены запятыми
                }
                else
                {
                    argument = str;
                }
                string argument_name = Name(ref argument, true); //выделим имя аргумента, если оно записано правильно
                args.Add(argument_name); //добавим элемент с таким именем
                if (del) str = str.Remove(0, argument_name.Length); //если надо - удалим только что полученный аргумент из строки
            }

            return args; //вернуть список аргументов
        }

        public static function get_function(ref string str, bool del = false)
        {
            function fun = new function();
            
            fun.arguments = function_arguments(ref str, true);
            str = str.Substring(1);
            char[] invalid_symbols = { ',', '(' };
            string probably_name = str.Substring(0, str.IndexOfAny(invalid_symbols)); //после открывающей скобки идет имя функции, от других аргументов его отделяет запятая
            fun.name = Name(ref probably_name, true); //выделим его, если оно записано правильно

            if (del)
            {
                str = str.Substring(str.IndexOfAny(invalid_symbols)); //если надо, удалаем и имя
                if (str[0] == ',')
                    str = str.Substring(1);
            }

            return fun;
        }
   
        public static ArrayList predicate_arguments(ref string str, bool del = false)
        {
            ArrayList args = new ArrayList();

            if (str[0] == ')') //найдена закрывающая скобка => дальше пойдёт функция
            {
                function f = get_function(ref str, true);
                args.Add(f);
                if (str[0] == ',') //запятая между аргументами
                    str = str.Substring(1);
                if (str != "" && str[0] != '(' && str[0] != ',')
                    args.InsertRange(0, predicate_arguments(ref str, true));
            }
            else //нету никакой лишней скобки
            {
                char[] invalid_symbols = { ',', '(' };
                string argument = str.Substring(0, str.IndexOfAny(invalid_symbols)); //имена аргументов (это может быть константа или переменная) разделены запятыми
                string argument_name = Name(ref argument, true); //выделим имя аргумента, если оно записано правильно
                args.Add(argument_name); //добавим элемент с таким именем

                if (del)
                {
                    str = str.Substring(str.IndexOfAny(invalid_symbols)); //если надо - удалим только что полученный аргумент из строки
                }
                if (str[0] == ',') //запятая между аргументами
                    str = str.Substring(1);
                if (str != "" && str[0] != '('  && str[0] != ',') 
                    args.InsertRange(0, predicate_arguments(ref str, true));
            }

            return args;
        }

        public static Predicate get_predicate(ref string str, bool del = false)
        {
            ArrayList list = predicate_arguments(ref str, true);

            if (str[0] == '(')
            {
                str = str.Substring(1); //открывающая скобка аргументов
            }
            char[] invalid_symbols = { ',', '|', '&', '~', '(', ')', '=', '→', '\0' };
            string probably_name = str.Substring(0, str.IndexOfAny(invalid_symbols)); //после открывающей скобки идет имя предиката, от других предикатов его отделяют операции
            string name = Name(ref probably_name, true); //выделим его, если оно записано правильно
            
            if (del) str = str.Substring(str.IndexOfAny(invalid_symbols)); //если надо, удалаем и имя
            
            return new Predicate(list, name);
        }

        public static bool is_Name (string str)
        {
            char[] invalid_symbols = { '|', '&', '~', '(', ')', '=', '→', '\0', '∀', '∃' };
            int end_of_a_name = str.IndexOfAny(invalid_symbols);
            if (end_of_a_name != -1)
            {
                return false;
            }
            return true;
        }

        public static string Name(ref string str, bool del = false)
        {

            string nm = "";
            int k = 0;

            //вырежем имя
            char[] invalid_symbols = { '|', '&', '~', '(', ')' , '=', '→', '\0' };
            int end_of_a_name = str.IndexOfAny(invalid_symbols);
            string str1 = str;
            if (end_of_a_name != -1)
            {
                str1 = str.Substring(0, end_of_a_name);
            }

            //перевернём его обратно
            char[] arr = str1.ToCharArray();
            Array.Reverse(arr);
            string name = new string(arr);
            if (name == "")
            {
                //throw new Exception("Found name which consists of invalid symbols");
                MessageBox.Show("Found name which consists of invalid symbols", "Ошибка");
            }

            if (Char.IsLetter(name, 0)) //первый символ - буква
            {
                nm += name.Substring(0, 1);
                k++;
                while (name.Length > k && (Char.IsLetterOrDigit(name, k) || name.Substring(k, 1) == "_"))
                {
                    nm += name.Substring(k, 1);
                    k++;
                }

            }
            else //если некорректное имя
            {
                //throw new Exception("Invalid Name, letter at the first place is expected");
                MessageBox.Show("Invalid Name, letter at the first place is expected", "Ошибка");
            }

            if (del)
            {
                str = str.Substring(k);
            }

            return nm;
        }


        public static bool is_operation(string str)
        {
            string d = str.Substring(0, 1);

            return (d == Properties.Settings.Default.conjunct ||
                    d == Properties.Settings.Default.disjunct || 
                    d == Properties.Settings.Default.negation || 
                    d == Properties.Settings.Default.implication || 
                    d == Properties.Settings.Default.All ||
                    d == Properties.Settings.Default.Exists ||
                    d == "(" || 
                    d == ")");
        }


        public static bool is_quantifier(string str)
        {
            string d = str.Substring(0, 1);

            return (d == Properties.Settings.Default.All || 
                    d == Properties.Settings.Default.Exists);
        }

        public static string get_quantifier(ref string str, bool del = true)
        {
            string d = str.Substring(0, 1);

            if (d == "" || 
                !(d == Properties.Settings.Default.All || 
                  d == Properties.Settings.Default.Exists)
                )
            {
                //throw new Exception("There aint no quantifier, bro");
                MessageBox.Show("There aint no quantifier, bro", "Ошибка");
            }

            if (del)
                str = str.Substring(1);
            return d;           
        }



        public static string get_operation(ref string str, bool del = true)
        {
            string d = str.Substring(0, 1);

            if (d == "" ||
                !(d == Properties.Settings.Default.conjunct ||
                    d == Properties.Settings.Default.disjunct ||
                    d == Properties.Settings.Default.negation ||
                    d == Properties.Settings.Default.implication ||
                    d == "(" ||
                    d == ")")
                )
            {
                //throw new Exception("Invalid operation");
                MessageBox.Show("Invalid operation", "Ошибка");
            
            }
            if (del)
                str = str.Substring(1);
            return d;
        }


        public static int prioritet(string s)
        {
            string dis = Properties.Settings.Default.disjunct;

            //     if (s == "(") return 0;

            if (s == Properties.Settings.Default.disjunct)    return 2;
            if (s == Properties.Settings.Default.implication) return 2;
            if (s == Properties.Settings.Default.conjunct)    return 3;
            if (s == Properties.Settings.Default.negation)    return 4;
            if (s == Properties.Settings.Default.All) return 5;
            if (s == Properties.Settings.Default.Exists) return 5;
            //     if (s == ")") return 0;
            return 0;

        }



        public static formula Parser_Expressions(string str1)
        {
            str1 = str1.Replace(" ", "");

            char[] arr = str1.ToCharArray();
            Array.Reverse(arr);
            string str = new string(arr);  //перевернули строку
            str = str.Replace(" ", "");   //удалить все пробелы 

            ArrayList stack = new ArrayList();
            ArrayList prefix = new ArrayList();
            ArrayList variables = new ArrayList();
            string oper = "";
            string stackvar = "";

            while (str.Length > 0)
            {

                if (!is_operation(str)) //если не операция - значит предикат (имя)
                {
                    prefix.Add(Name(ref str, true));
                }

                else // операция - квантор или обычная
                {
                    oper = get_operation(ref str, true); //выделим для начала символ с операцией

                    if (oper == ")") //если это закрывающая скобка, значит, операция внешняя
                    {
                        stack.Insert(0, oper); //добавим ее снаружи
                    }
                    else if (oper == "(")
                    {
                        if (stack.Count > 0)
                        {
                            stackvar = (string)stack[0];

                            while (stackvar != ")")
                            {
                                prefix.Add(stackvar);
                                stack.RemoveAt(0);
                                stackvar = (string)stack[0];
                            }
                            stack.RemoveAt(0);
                        }
                    }
                    else
                    {
                        if (stack.Count > 0)
                        {
                            stackvar = (string)stack[0];

                            while (prioritet(oper) <= prioritet(stackvar))
                            {

                                prefix.Add(stackvar);
                                stack.RemoveAt(0);
                                if (stack.Count > 0)
                                { stackvar = (string)stack[0]; }
                                else
                                { break; }
                            }
                        }
                        stack.Insert(0, oper);

                    }
                }
            }

            while (stack.Count > 0)
            {
                stackvar = (string)stack[0];
                prefix.Add(stackvar);
                stack.RemoveAt(0);
            }

            prefix.Reverse();
            ArrayList prefix_for_formula = new ArrayList();

            foreach (string f in prefix)
            {
                prefix_for_formula.Add(is_operation(f) ? (formula_member)oper_factory(f) : (formula_member)new Atom(f));
            }

            return new formula(prefix_for_formula);
        }


        public static formula Parser_Predicates(string str1)
        {
            str1 = str1.Replace(" ", "");

            char[] arr = str1.ToCharArray();
            Array.Reverse(arr);
            string str = new string(arr);  //перевернули строку
            str = str.Replace(" ", "");   //удалить все пробелы 

            ArrayList stack = new ArrayList();
            ArrayList prefix = new ArrayList();
            ArrayList variables = new ArrayList();
            string oper = "";
            string stackvar = "";

            while (str.Length > 0)
            {

                if (!is_operation(str)) //если не операция - значит предикат (имя)
                {
                    //1 ДЛЯ ИВ
                    //prefix.Add(Name(ref str, true));
                    
                    //2 ДЛЯ ИППП
                    char[] quants = { '∀', '∃' };
                    int i = str.IndexOfAny(quants);
                    if (str.IndexOfAny(quants) == -1)
                    {
                        MessageBox.Show("Не найдены кванторы. Возможно, вы пытаетесь использовать СА для предикатов для анализа формулы ИВ", "Ошибка");
                        break;
                    }
                    else
                    {
                        string probably_variable_name = str.Substring(0, str.IndexOfAny(quants));
                        if (is_Name(probably_variable_name))
                        {
                            string variable_name = Name(ref probably_variable_name, false);
                            prefix.Add(variable_name);
                            variables.Add(variable_name);

                            str = str.Substring(probably_variable_name.Length);
                            prefix.Add(get_quantifier(ref str, true)); //после имени переменной стоит квантор
                        }
                        else
                        {
                            prefix.Add(get_predicate(ref str, true));
                            str = str.Insert(0, "(");
                        }
                    }
                }

                else // операция - квантор или обычная
                {
                    oper = get_operation(ref str, true); //выделим для начала символ с операцией

                    if (oper == ")") //если это закрывающая скобка, значит, операция внешняя
                    { 
                        stack.Insert(0, oper); //добавим ее снаружи
                    }
                    else if (oper == "(")
                    {
                        if (stack.Count > 0)
                        {
                            stackvar = (string)stack[0];

                            while (stackvar != ")")
                            {
                                prefix.Add(stackvar);
                                stack.RemoveAt(0);
                                stackvar = (string)stack[0];
                            }
                            stack.RemoveAt(0);
                        }
                    }
                    else
                    {
                        if (stack.Count > 0)
                        {
                            stackvar = (string)stack[0];

                            while (prioritet(oper) <= prioritet(stackvar))
                            {

                                prefix.Add(stackvar);
                                stack.RemoveAt(0);
                                if (stack.Count > 0)
                                { stackvar = (string)stack[0]; }
                                else
                                { break; }
                            }
                        }
                        stack.Insert(0, oper);

                    }
                }
            }

            while (stack.Count > 0)
            {
                stackvar = (string)stack[0];
                prefix.Add(stackvar);
                stack.RemoveAt(0);
            }

            prefix.Reverse();
            ArrayList prefix_for_formula = new ArrayList();

            //foreach (string f in prefix)
            //{
            //    prefix_for_formula.Add(is_operation(f) ? (formula_member)oper_factory(f) : (formula_member)new Atom(f));
            //}

            while (prefix.Count > 0)
            {
                if (prefix[0] is string)
                {
                    if (is_operation((string)prefix[0]))
                    {
                        if ((string)prefix[0] == "∀" || (string)prefix[0] == "∃")
                        {
                            prefix_for_formula.Add(new quantifier((string)prefix[0], (string)prefix[1]));
                        }
                        else
                            prefix_for_formula.Add((formula_member)oper_factory((string)prefix[0]));
                    }
                    else
                    {
                        if (variables.Contains((string)prefix[0]))
                        {
                            //do nothing
                        }
                        else
                            prefix_for_formula.Add((formula_member)new Atom((string)prefix[0]));
                    }
                }
                else if (prefix[0] is Predicate)
                {
                    prefix_for_formula.Add(prefix[0]);
                }

                prefix.RemoveAt(0);
            }

            return new formula(prefix_for_formula,variables);
        }


    }
}



