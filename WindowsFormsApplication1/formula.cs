using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class formula
    {
        private ArrayList _logical_expr;
        private ArrayList _variables_list;
        
        
        public formula() 
        { 
            _logical_expr = new ArrayList(); 
        }


        public formula(ArrayList a1) 
        {
            _logical_expr = new ArrayList();
            _logical_expr.AddRange(a1);
        }

        public formula(ArrayList prefix, ArrayList variables)
        {
            _logical_expr = new ArrayList();
            _logical_expr.AddRange(prefix);

            _variables_list = new ArrayList();
            _variables_list.AddRange(variables);
        }

        public ArrayList logical_exp
        {
            get { return this._logical_expr;  }
            set { this._logical_expr = value; }
        }

        

        public ArrayList variables
        {
            get
            {
                return this._variables_list;
            }
        }


        public formula(string s)
        {
            string_helper.Parser_Expressions(s); //Строим по строке формулу
        } 
        
        
        public static formula operator &(formula f1, formula f2)
        {
            formula f = new formula();
            f._logical_expr.AddRange(f1._logical_expr);
            f._logical_expr.Insert(0, new kon());
            f._logical_expr.AddRange(f2._logical_expr);
            return f;
        }


        public static formula operator |(formula f1, formula f2)
        {
            formula f = new formula();
            f._logical_expr.AddRange(f1._logical_expr);
            f._logical_expr.Insert(0, new dis());
            f._logical_expr.AddRange(f2._logical_expr);
            return f;
        }


        public static formula operator ~(formula f1)
        {
            formula f = new formula();
            f._logical_expr.AddRange(f1._logical_expr);
            f._logical_expr.Insert(0, new neg());

            if (f._logical_expr[0] is neg && f._logical_expr[1] is neg) //если двойное отрицание
            {
                f._logical_expr.RemoveAt(0); //удаляем первое отрицание
                f._logical_expr.RemoveAt(0); //удаляем второе отрицание
            }
            return f;
        }


        public bool is_Atom 
        { 
            get
            {
                return ((this._logical_expr.Count == 1) && (this._logical_expr[0] is Atom)) || (this._logical_expr[0] is Predicate); 
            }
        }

        
        public operation top_operation
        {
            get 
            {
                if (logical_exp.Count == 0)
                {
                    return new empty_operator();
                }
                else
                {
                    if (logical_exp[0] is operation)
                    {
                        return (operation)logical_exp[0];
                    }
                    
                    else
                    {

                        throw new Exception("Невозможно получить top_operation, там содержится не операция");
                    }
                }
            }
            
        }

    
        public formula first_operand
        {
            get
            {
                int amount = 1;
                ArrayList log1 = new ArrayList();
                
                for (int i = 0; i < amount; i++)
                {
                    if (i + 1 < logical_exp.Count)
                    {
                        if (logical_exp[i + 1] is Predicate)
                        {
                            //log1.Add(logical_exp[i + 1]);
                        }
                        
                        if (logical_exp[i + 1] is operation)
                        {
                            amount += ((operation)logical_exp[i + 1]).dimension;
                        }
                        log1.Add(logical_exp[i + 1]);
                    }
                }
                return new formula(log1);                
            }
        }

        public ArrayList find_first_operand_list(int place, ArrayList exp)
        {
            
                int amount = 1;
                ArrayList log1 = new ArrayList();

                for (int i = 0; i < amount; i++)
                {
                    if (exp[place + (i + 1)] is operation)
                    {
                        amount += ((operation)exp[place + (i + 1)]).dimension;
                    }
                    log1.Add(exp[place + (i + 1)]);

                }
                return log1;
            
        }

       
        
        public formula second_operand
        {
            get
            {
                int amount = 1;
                int i = 0;
                ArrayList log2 = new ArrayList();
                for ( i = 0; i < amount; i++)
                {
                    if (i + 1 < logical_exp.Count)
                    {
                        if (logical_exp[i + 1] is operation)
                        {
                            amount += ((operation)logical_exp[i + 1]).dimension;
                        }
                    }
                }

                amount = 1;
                int k = i;
                for (; i-k < amount; i++)
                {
                    if (i + 1 < logical_exp.Count)
                    {
                        if (logical_exp[i + 1] is operation)
                        {
                            amount += ((operation)logical_exp[i + 1]).dimension;
                        }
                        log2.Add(logical_exp[i + 1]);
                    }
                }
                return new formula(log2);

            }
            
        }

        public ArrayList find_second_operand_list(int place, ArrayList exp)
        {
                int amount = 1;
                int i = 0;
                ArrayList log2 = new ArrayList();
                for (i = 0; i < amount; i++)
                {
                    if (logical_exp[place+(i + 1)] is operation)
                    {
                        amount += ((operation)logical_exp[place + (i + 1)]).dimension;
                    }
                }

                amount = 1;
                int k = i;
                for (; i - k < amount; i++)
                {
                    if (logical_exp[place+(i + 1)] is operation)
                    {
                        amount += ((operation)logical_exp[place + (i + 1)]).dimension;
                    }
                    log2.Add(logical_exp[place + (i + 1)]);
                }
                return log2;
        }

        

        public formula DeMorgan(formula f)
        {
            formula demorg = new formula();
            

            if (f.top_operation is kon)
            {
                demorg.logical_exp.Insert(0, new dis()); //меняем знак операции
                
                //отрицание первого операнда
                demorg.logical_exp.Add(new neg());
                demorg.logical_exp.AddRange(f.first_operand.logical_exp);

                //отрицание второго операнда
                demorg.logical_exp.Add(new neg());
                demorg.logical_exp.AddRange(f.second_operand.logical_exp);
            }            
            else if (f.top_operation is dis)
            {
                demorg.logical_exp.Insert(0, new kon()); //меняем знак операции
                
                //отрицание первого операнда
                demorg.logical_exp.Add(new neg());
                demorg.logical_exp.AddRange(f.first_operand.logical_exp);

                //отрицание второго операнда
                demorg.logical_exp.Add(new neg());
                demorg.logical_exp.AddRange(f.second_operand.logical_exp);
            }

            //удалим все двойные отрицания:
            int i = 0;
            while (i < demorg._logical_expr.Count - 1)
            {
                if (demorg._logical_expr[i] is neg && demorg._logical_expr[i + 1] is neg)
                {
                    demorg._logical_expr.RemoveRange(i, 2);
                }
                i++;
            }
            
            return demorg;
        }
        public bool is_basic
        {
            get
            {
                if (is_some_atom_exp)
                    return true;
                if (!(top_operation is kon) || !(top_operation is dis))
                    return false;
                else
                {
                    if (top_operation.dimension == 1)
                        return first_operand.is_basic;
                    else
                        return (first_operand.is_basic && second_operand.is_basic);
                }
            }
        }

        public formula get_basic()
        {
            if (this.is_basic)
                return this;

            formula func = new formula();

            //если вдруг импликация
            if (top_operation is imp)
            {
                func = (~(first_operand.get_basic())).get_basic() | second_operand.get_basic();
            }
            else
            {
                if (top_operation.dimension == 1)
                {
                    func = first_operand.get_basic();
                    func.logical_exp.Insert(0, top_operation);
                }
                else
                {
                    if (top_operation is dis)
                        func = first_operand.get_basic() | second_operand.get_basic();
                    else
                        func = first_operand.get_basic() & second_operand.get_basic();
                }
            }
            //отрицание перед скобками
            if (top_operation is neg)
            {
                formula negation_trick = new formula(first_operand.logical_exp);
                
                if (negation_trick.top_operation is neg)
                {
                    negation_trick.logical_exp.RemoveAt(0); //убираем второе отрицание
                }

                if (negation_trick.top_operation is quantifier)
                {
                    quantifier K = new quantifier((quantifier)negation_trick.top_operation);
                    K.change_quant();
                    negation_trick.logical_exp.RemoveAt(0);
                    negation_trick = (~negation_trick).get_basic();
                    negation_trick.logical_exp.Insert(0, K);
                    
                }

                //применяем правила ДеМоргана:
                if (negation_trick.top_operation is kon)
                {
                    negation_trick = (~(negation_trick.first_operand.get_basic())).get_basic() | (~(negation_trick.second_operand.get_basic())).get_basic();
                }
                else if (negation_trick.top_operation is dis)
                {
                    negation_trick = (~(negation_trick.first_operand.get_basic())).get_basic() & (~(negation_trick.second_operand.get_basic())).get_basic();
                }
                return negation_trick;
            }
            return func;
        }

    
      
        
        public override string ToString()
        {
            if (this.logical_exp.Count == 0) return "";
            else if (this.is_Atom)
            {
                return this.logical_exp[0].ToString();
            }
            else if (this.logical_exp[0] is Predicate)
            {
                return this.logical_exp[0].ToString();
            }
            else
            {
                if (this.top_operation.dimension == 1)
                {
                    if (this.top_operation is quantifier)
                    {
                        return "(" + this.top_operation.ToString() + "(" +this.first_operand.ToString() + ")" + ")";
                    }
                    return this.top_operation.ToString() + this.first_operand.ToString();
                }
                else
                    return "( " + this.first_operand.ToString() + " " + this.top_operation.ToString() + " " + this.second_operand.ToString() + " )";
            }           
        }




       

        public bool is_some_atom_exp //положительный или отрицательный атом
        {
            get
            {
                return ((this._logical_expr.Count == 1) && (this.is_Atom)) || ((this._logical_expr.Count == 2) && (this._logical_expr[0] is neg) && ((this._logical_expr[1] is Atom)|| (this._logical_expr[1] is Predicate)));
            }
        }

        public bool is_elementary_conjunct //конъюнкт из атомов
        {
            get
            {
                return
                    (logical_exp.Count <= 1) //атом
                    ||
                    top_operation is quantifier
                    ||
                    (
                     (top_operation is kon) 
                     && 
                     (first_operand.is_some_atom_exp || first_operand.is_elementary_conjunct || first_operand.top_operation is quantifier)
                     && 
                     (second_operand.is_some_atom_exp || second_operand.is_elementary_conjunct || second_operand.top_operation is quantifier)
                    );
            }
        }

        public bool is_conjunct //конъюнкт
        {
            get 
            {
                if (is_some_atom_exp) return true;
                else return (top_operation is kon) && first_operand.is_conjunct && second_operand.is_conjunct;                        
            }
        }

        public bool is_disjunct //дизъюнкт
        {
            get
            {
                if (is_some_atom_exp) return true;
                else return(top_operation is dis) && first_operand.is_WWF && second_operand.is_WWF;
            }
        }

        public bool is_elementary_disjunct //дизъюнкт из атомов
        {
            get
            {
                return
                    (logical_exp.Count <= 1) //атом
                    ||
                    top_operation is quantifier
                    ||
                    (
                     (top_operation is dis) 
                     && 
                     (first_operand.is_some_atom_exp || first_operand.is_elementary_disjunct || first_operand.top_operation is quantifier) 
                     && 
                     (second_operand.is_some_atom_exp || second_operand.is_elementary_disjunct || second_operand.top_operation is quantifier)
                    );
            }
        }

        public bool is_WWF
        {
            get
            {
                return is_some_atom_exp || is_conjunct || is_disjunct;
            }
        }

        public bool is_nonAtom_WWF
        {
            get
            {
                if (is_some_atom_exp) return false;
                else return is_conjunct || is_disjunct || (first_operand.is_WWF) || (second_operand.is_WWF);
            }
        }

        public formula distributivity()
        {
            formula distributed = new formula();

            bool suitable_for_distributivity;
            if (first_operand.is_Atom && second_operand.is_Atom) suitable_for_distributivity = false;
            else suitable_for_distributivity = first_operand.is_nonAtom_WWF || second_operand.is_nonAtom_WWF;



            if (top_operation is kon && suitable_for_distributivity)
            {
                if ( !(second_operand.is_Atom) && second_operand.top_operation is dis)
                {
                    distributed._logical_expr.Insert(0, new dis());

                    distributed._logical_expr.Add(new kon());
                    distributed._logical_expr.AddRange(first_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand.first_operand._logical_expr);

                    distributed._logical_expr.Add(new kon());
                    distributed._logical_expr.AddRange(first_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand.second_operand._logical_expr);
                }
                else if ( !(first_operand.is_Atom) &&first_operand.top_operation is dis)
                {
                    distributed._logical_expr.Insert(0, new dis());

                    distributed._logical_expr.Add(new kon());
                    distributed._logical_expr.AddRange(first_operand.first_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand._logical_expr);

                    distributed._logical_expr.Add(new kon());
                    distributed._logical_expr.AddRange(first_operand.second_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand._logical_expr);
                }
            }
            else if (top_operation is dis && suitable_for_distributivity)
            {
                if ( second_operand.top_operation is kon)
                {
                    distributed._logical_expr.Insert(0, new kon());

                    distributed._logical_expr.Add(new dis());
                    distributed._logical_expr.AddRange(first_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand.first_operand._logical_expr);

                    distributed._logical_expr.Add(new dis());
                    distributed._logical_expr.AddRange(first_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand.second_operand._logical_expr);
                }
                else if ( first_operand.top_operation is kon)
                {
                    distributed._logical_expr.Insert(0, new kon());

                    distributed._logical_expr.Add(new dis());
                    distributed._logical_expr.AddRange(first_operand.first_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand._logical_expr);

                    distributed._logical_expr.Add(new dis());
                    distributed._logical_expr.AddRange(first_operand.second_operand._logical_expr);
                    distributed._logical_expr.AddRange(second_operand._logical_expr);
                }
            }
            else
            {
                distributed = this;
            }

            this.logical_exp = distributed.logical_exp;
            return distributed;
        }

        public bool is_DNF
        {
            get
            {
                return
                    is_some_atom_exp
                    ||
                    is_elementary_conjunct
                    ||
                    top_operation is quantifier
                    
                    ||                    
                    (top_operation is dis)
                    &&
                    (first_operand.is_some_atom_exp || first_operand.is_conjunct || first_operand.is_DNF)
                    &&
                    (second_operand.is_some_atom_exp || second_operand.is_conjunct || second_operand.is_DNF)
                    
                    || 
                    (top_operation is quantifier)
                    &&
                    (first_operand.is_some_atom_exp || first_operand.is_conjunct || first_operand.is_DNF)
                    &&
                    (second_operand.is_some_atom_exp || second_operand.is_conjunct || second_operand.is_DNF);

            }
            
        }

        public formula make_DNF()
        {
            formula dnf = new formula();

            if (is_DNF)
            {
                dnf = this;
            }
            else if (top_operation is dis)
            {
                dnf = first_operand.make_DNF() | second_operand.make_DNF();
            }
            else if (top_operation is kon)
            {
                //дистрибутивность справа:
                if (!second_operand.is_some_atom_exp && second_operand.top_operation is dis)
                {
                    formula new_second = new formula();
                    if (!second_operand.is_DNF)
                    {
                        new_second = second_operand.make_DNF();
                    }
                    else new_second = second_operand;

                    dnf = (((first_operand.make_DNF() & new_second.first_operand.make_DNF())).make_DNF() | ((first_operand.make_DNF() & new_second.second_operand.make_DNF()))).make_DNF();
                }
                else if (!second_operand.is_some_atom_exp && second_operand.top_operation is kon)
                {
                    formula new_second = new formula();
                    if (!second_operand.is_DNF)
                    {
                        new_second = second_operand.make_DNF();
                    }
                    dnf = (first_operand.make_DNF() & new_second).make_DNF();
                }
                else if (second_operand.is_some_atom_exp || second_operand.top_operation is quantifier)
                {

                    //дистрибутивность слева:
                    if (!first_operand.is_some_atom_exp && first_operand.top_operation is dis)
                    {
                        formula new_first = new formula();
                        if (!first_operand.is_DNF)
                        {
                            new_first = first_operand.make_DNF();
                        }
                        else new_first = first_operand;

                        dnf = ((new_first.first_operand.make_DNF() & second_operand.make_DNF())).make_DNF() | ((new_first.second_operand.make_DNF() & second_operand.make_DNF())).make_DNF();
                    }
                    else if (!first_operand.is_some_atom_exp && first_operand.top_operation is kon)
                    {
                        formula new_first = new formula();
                        if (!first_operand.is_DNF)
                        {
                            new_first = first_operand.make_DNF();
                        }
                        dnf = (new_first.make_DNF() & second_operand.make_DNF()).make_DNF();
                    }
                    else if (first_operand.is_some_atom_exp)
                    {
                        throw new Exception("Невозможно привести данное выражение к КНФ");
                    }
                }
            }

            return dnf;
        }

        public bool is_KNF
        {
            get
            {
                bool a =
                    is_some_atom_exp                
                    ||
                    top_operation is quantifier
                    ||
                    is_elementary_disjunct
                    ||
                    (
                     (top_operation is kon)  
                     &&  
                     (first_operand.is_some_atom_exp  ||  first_operand.is_KNF || first_operand.is_elementary_disjunct)    
                     &&  
                     (second_operand.is_some_atom_exp ||  second_operand.is_KNF || second_operand.is_elementary_disjunct)
                    )
                
                    || 
                    (top_operation is quantifier)
                    &&
                    (first_operand.is_some_atom_exp || first_operand.is_disjunct || first_operand.is_KNF)
                    &&
                    (second_operand.is_some_atom_exp || second_operand.is_disjunct || second_operand.is_KNF);
                
                return a;
            }
            }

        public formula make_KNF()
        {
            formula knf = new formula();

            if (is_KNF)
            {
                knf = this;
            }
            else if (top_operation is kon)
            {
                knf = first_operand.make_KNF() & second_operand.make_KNF();
            }
            else if (top_operation is dis)
            {
                //дистрибутивность справа:
                if (!second_operand.is_some_atom_exp && second_operand.top_operation is kon)
                {
                    formula new_second = new formula();
                    if (!second_operand.is_KNF)
                    {
                        new_second = second_operand.make_KNF();
                    }
                    else new_second = second_operand;

                    knf = (((first_operand.make_KNF() | new_second.first_operand.make_KNF())).make_KNF() & ((first_operand.make_KNF() | new_second.second_operand.make_KNF()))).make_KNF();
                }
                else if (!second_operand.is_some_atom_exp && second_operand.top_operation is dis)
                {
                    formula new_second = new formula();
                    if (!second_operand.is_KNF)
                    {
                        new_second = second_operand.make_KNF();
                    }
                    knf = (first_operand.make_KNF() | new_second).make_KNF();
                }
                else if (second_operand.is_some_atom_exp || second_operand.top_operation is quantifier)
                {

                    //дистрибутивность слева:
                    if (!first_operand.is_some_atom_exp && first_operand.top_operation is kon)
                    {
                        formula new_first = new formula();
                        if (!first_operand.is_KNF)
                        {
                            new_first = first_operand.make_KNF();
                        }
                        else new_first = first_operand;

                        knf = ((new_first.first_operand.make_KNF() | second_operand.make_KNF())).make_KNF() & ((new_first.second_operand.make_KNF() | second_operand.make_KNF())).make_KNF();
                    }
                    else if (!first_operand.is_some_atom_exp && first_operand.top_operation is dis)
                    {
                        formula new_first = new formula();
                        if (!first_operand.is_KNF)
                        {
                            new_first = first_operand.make_KNF();
                        }
                        knf = (new_first.make_KNF() | second_operand.make_KNF()).make_KNF();
                    }
                    else if (first_operand.is_some_atom_exp)
                    {
                        throw new Exception("Невозможно привести данное выражение к КНФ");
                    }
                }
            }

            return knf;

        }

        //взять связанную переменную из квантора
        public string get_bounded_variable(operation this_operation)
        {
            string var = "";

            if (this_operation is quantifier)
            {
                quantifier K = new quantifier((quantifier)this_operation);

                var = K.variable;
            }
            else
            {
                throw new Exception("Нельзя взять связанную переменную, так как операция - не квантор");
            }

            return var;
        }

        //не содержит заданной переменной
        public bool is_free_from(string variable)
        {
            if (this.logical_exp[0] is Atom)
                return true;
            else if (this.logical_exp[0] is Predicate)
            {
                Predicate Pred = new Predicate((Predicate)this.logical_exp[0]);
                if (!Pred.Contains(variable))
                    return true;
                else return false;
            }
            else if (this.logical_exp[0] is operation && this.top_operation.dimension != 1)
            {
                return this.first_operand.is_free_from(variable) && this.second_operand.is_free_from(variable);
            }
            else if (this.logical_exp[0] is operation && this.top_operation.dimension == 1)
            {
                return this.first_operand.is_free_from(variable);
            }

            return false;
        }

        public bool is_quantum_expression
        {
            get
            {
                if (!this.is_some_atom_exp && this.top_operation is quantifier)
                    return true;
                else return false;
            }
        }

        public formula get_quanted_expression
        {
            get
            {
                if (this.is_quantum_expression)
                    return this.first_operand;
                else throw new Exception("Невозможно выделить подкванторное выражение, т.к. нету квантора");
            }
        }

        public bool is_Predicate
        {
            get
            {
                return (this.logical_exp.Count == 1 && this.logical_exp[0] is Predicate);
            }
        }

        public formula rename_variable(string that_one, string to_this_one)
        {
            formula new_expression = new formula();

            if (!this.is_Predicate)
            {
                if (top_operation is dis)
                    new_expression = first_operand.rename_variable(that_one, to_this_one) | second_operand.rename_variable(that_one, to_this_one);
                else if (top_operation is kon)
                    new_expression = first_operand.rename_variable(that_one, to_this_one) & second_operand.rename_variable(that_one, to_this_one);
                else if (top_operation is quantifier)
                {
                    new_expression = this;
                    new_expression = new_expression.first_operand.rename_variable(that_one, to_this_one);
                    new_expression.logical_exp.Insert(0, top_operation);
                    return new_expression;
                }

                //скорее всего здесь предикатное выражение, посему:
                if (first_operand.is_Predicate)
                {
                    Predicate Pred = new Predicate((Predicate)first_operand.logical_exp[0]);
                    for (int i = 0; i < Pred.arguments.Count; i++)
                    {
                        if ((string)Pred.arguments[i] == that_one)
                            Pred.arguments[i] = to_this_one;
                        if (Pred.arguments[i] is function)
                        {
                            function f = new function((function)Pred.arguments[i]);
                            Pred.arguments[i] = f.rename_variable(that_one, to_this_one);
                        }
                    }
                    new_expression.logical_exp.Add(Pred);
                }
                if (second_operand.is_Predicate)
                {
                    Predicate Pred = new Predicate((Predicate)second_operand.logical_exp[0]);
                    for (int i = 0; i < Pred.arguments.Count; i++)
                    {
                        if (Pred.arguments[i] is function)
                        {
                            function f = new function((function)Pred.arguments[i]);
                            Pred.arguments[i] = f.rename_variable(that_one, to_this_one);
                        }
                        else if ((string)Pred.arguments[i] == that_one)
                            Pred.arguments[i] = to_this_one;
                        
                    }
                    new_expression.logical_exp.Add(Pred);
                }
            }
            else
            {
                Predicate Pred = new Predicate((Predicate)this.logical_exp[0]);
                for (int i = 0; i < Pred.arguments.Count; i++)
                {
                    if (Pred.arguments[i] is function)
                    {
                        function f = new function((function)Pred.arguments[i]);
                        Pred.arguments[i] = f.rename_variable(that_one, to_this_one);
                    }   
                    else if ((string)Pred.arguments[i] == that_one)
                        Pred.arguments[i] = to_this_one;
                                     
                }
                new_expression.logical_exp.Add(Pred);
            }
            
            return new_expression;
        }



        public bool is_PNF
        {
            get
            {

                if (!this.has_quantifier)
                { return true; }

                else
                {
                    if (this.top_operation is quantifier)
                    { return this.first_operand.is_PNF; }
                    else 
                    { return false; }
                }
            }
        }

        public bool has_quantifier
        {
            get
            {
                ArrayList func = new ArrayList(this.logical_exp);

                for (int i = 0; i < func.Count; i++)
                {
                    if (func[i] is quantifier)
                        return true;
                }

                return false;
            }

        }

        public bool is_free_from_quntifiers
        {
            get
            {
                if (this.is_some_atom_exp || !this.is_quantum_expression)
                    return true;
                else if (this.top_operation is quantifier)
                    return false; 
                else
                    return false;
            }

        }

        private ArrayList bounded_variables;

        private ArrayList bounded_vars
        {
            get
            {
                return this.bounded_variables;
            }
            set
            {
                this.bounded_variables = value;
            }

        }

        public formula make_PNF()
        {            
            if (this.is_PNF)
                return this;

            formula pnf = new formula();
            
            

            if (top_operation is quantifier)
            {
                quantifier K1 = new quantifier((quantifier)top_operation);
                //bounded_variables.Add(K1.variable);
                pnf = first_operand.make_PNF();
                pnf.logical_exp.Insert(0, top_operation);
                return pnf;
            }
            else
            {
                //1 правило вноса атомов под квантор
                if (top_operation is dis)
                {
                    if (first_operand.is_free_from_quntifiers && second_operand.is_free_from_quntifiers) //два атома => итак уже пнф
                    {
                        return first_operand | second_operand;
                    }
                    else if (first_operand.is_free_from_quntifiers && second_operand.is_quantum_expression) //атом и кванторное выражение => записываем атом под квантор
                    {
                        pnf = first_operand | second_operand.first_operand.make_PNF();
                        pnf.logical_exp.Insert(0, second_operand.top_operation);
                        pnf = pnf.make_PNF();
                    }
                    else if (!first_operand.is_free_from_quntifiers && first_operand.top_operation is quantifier) //два кванторных выражения
                    {
                        string variable = get_bounded_variable(first_operand.top_operation);

                        if (second_operand.is_free_from(variable))
                        {
                            pnf = first_operand.first_operand.make_PNF() | second_operand.make_PNF();
                            pnf.logical_exp.Insert(0, first_operand.top_operation);
                            pnf = pnf.make_PNF();
                        }
                    }
                    else if (!second_operand.is_free_from_quntifiers && second_operand.top_operation is quantifier)
                    {
                        string variable = get_bounded_variable(second_operand.top_operation);

                        if (first_operand.is_free_from(variable))
                        {
                            pnf = first_operand.make_PNF() | second_operand.first_operand.make_PNF();
                            pnf.logical_exp.Insert(0, second_operand.top_operation);
                            pnf = pnf.make_PNF();
                        }
                    }
                }
                else if (top_operation is kon)
                {
                    if (first_operand.is_free_from_quntifiers && second_operand.is_free_from_quntifiers) //два атома => итак уже пнф
                    {
                        return first_operand & second_operand;
                    }
                    else if (first_operand.is_free_from_quntifiers && second_operand.is_quantum_expression) //атом и кванторное выражение => записываем атом под квантор
                    {
                        pnf = first_operand & second_operand.first_operand.make_PNF();
                        pnf.logical_exp.Insert(0, second_operand.top_operation);
                        pnf = pnf.make_PNF();
                    }
                    else if (second_operand.is_free_from_quntifiers && first_operand.is_quantum_expression) //кванторное выражение и атом
                    {
                        pnf = first_operand.first_operand.make_PNF() & second_operand;
                        pnf.logical_exp.Insert(0, first_operand.top_operation);
                        pnf = pnf.make_PNF();
                    }
                    if (first_operand.is_quantum_expression && first_operand.top_operation is quantifier)
                    {
                        string variable = get_bounded_variable(first_operand.top_operation);
                        bounded_variables.Add(variable);

                        if (second_operand.is_free_from(variable))
                        {
                            pnf = first_operand.first_operand.make_PNF() & second_operand.make_PNF();
                            pnf.logical_exp.Insert(0, first_operand.top_operation);
                            pnf = pnf.make_PNF();
                        }
                    }
                    else if (second_operand.is_quantum_expression && second_operand.top_operation is quantifier)
                    {
                        string variable = get_bounded_variable(second_operand.top_operation);
                        //bounded_variables.Add(variable);

                        if (first_operand.is_free_from(variable))
                        {
                            pnf = first_operand.make_PNF() & second_operand.first_operand.make_PNF();
                            pnf.logical_exp.Insert(0, second_operand.top_operation);
                            pnf = pnf.make_PNF();
                        }
                    }
                }

                //2 - правила объединения кванторов
                //2.1 - всеобщность
                if (top_operation is kon)
                {
                    if (first_operand.is_quantum_expression && second_operand.is_quantum_expression)
                    {
                        if (first_operand.top_operation is quantifier && second_operand.top_operation is quantifier)
                        {
                            quantifier K1 = new quantifier((quantifier)first_operand.top_operation);
                            //bounded_variables.Add(K1.variable);
                            quantifier K2 = new quantifier((quantifier)second_operand.top_operation);

                            if (K1.is_universality && K2.is_universality && K1.variable == K2.variable)
                            {
                                pnf = first_operand.first_operand & second_operand.first_operand;
                                pnf.logical_exp.Insert(0, first_operand.top_operation);
                            }
                        }
                    }
                }
                //2.2 - существование
                if (top_operation is dis)
                {
                    if (first_operand.is_quantum_expression && second_operand.is_quantum_expression)
                    {
                        if (first_operand.top_operation is quantifier && second_operand.top_operation is quantifier)
                        {
                            quantifier K1 = new quantifier((quantifier)first_operand.top_operation);
                            //bounded_variables.Add(K1.variable);
                            quantifier K2 = new quantifier((quantifier)second_operand.top_operation);

                            if (K1.is_existance && K2.is_existance && K1.variable == K2.variable)
                            {
                                pnf = first_operand.first_operand | second_operand.first_operand;
                                pnf.logical_exp.Insert(0, first_operand.top_operation);
                            }
                        }
                    }
                }

                //3 - правило выноса квантора за скобки (с переименованием связанных переменных)
                if (top_operation is dis)
                {
                    if (first_operand.is_quantum_expression && second_operand.is_quantum_expression)
                    {
                        quantifier K1 = new quantifier((quantifier)first_operand.top_operation);
                        //bounded_variables.Add(K1.variable);
                        quantifier K2 = new quantifier((quantifier)second_operand.top_operation);

                        if (K1.variable == K2.variable && bounded_variables.Contains(K2.variable))
                        {

                            pnf = first_operand.first_operand | second_operand.first_operand.rename_variable(K2.variable, K2.variable + "_renamed");
                            K2.variable = K2.variable + "1";
                            pnf.logical_exp.Insert(0, K2);
                            pnf.logical_exp.Insert(0, K1);
                        }
                        else if (!second_operand.is_free_from(K1.variable))
                        {
                            pnf = first_operand.first_operand | second_operand.first_operand.rename_variable(K1.variable, K1.variable + "_renamed");
                            pnf.logical_exp.Insert(0, K2);
                            pnf.logical_exp.Insert(0, K1);
                        }
                        else
                        {
                            pnf = first_operand.first_operand | second_operand.first_operand;
                            pnf.logical_exp.Insert(0, K2);
                            pnf.logical_exp.Insert(0, K1);
                        }
                    }
                }
                else if (top_operation is kon)
                {
                    if (first_operand.is_quantum_expression && second_operand.is_quantum_expression)
                    {
                        quantifier K1 = new quantifier((quantifier)first_operand.top_operation);
                        quantifier K2 = new quantifier((quantifier)second_operand.top_operation);

                        if (K1.variable == K2.variable)
                        {
                            pnf = first_operand.first_operand & second_operand.first_operand.rename_variable(K2.variable, K2.variable + "_renamed");
                            K2.variable = K2.variable + "1";
                            pnf.logical_exp.Insert(0, K2);
                            pnf.logical_exp.Insert(0, K1);
                        }
                    }
                }



                return pnf;
            }
        }


        public formula change_variable(string this_one, function to_this)
        {
            formula new_expression = new formula();

            if (!this.is_Predicate)
            {
                if (top_operation is dis)
                    new_expression = first_operand.change_variable(this_one, to_this) | second_operand.change_variable(this_one, to_this);
                else if (top_operation is kon)
                    new_expression = first_operand.change_variable(this_one, to_this) & second_operand.change_variable(this_one, to_this);
                else if (top_operation is quantifier)
                {
                    new_expression = this;
                    new_expression = new_expression.first_operand.change_variable(this_one, to_this);
                    new_expression.logical_exp.Insert(0, top_operation);
                    return new_expression;
                }

                //скорее всего здесь предикатное выражение, посему:
                if (first_operand.is_Predicate)
                {
                    Predicate Pred = new Predicate((Predicate)first_operand.logical_exp[0]);
                    for (int i = 0; i < Pred.arguments.Count; i++)
                    {
                        if ((string)Pred.arguments[i] == this_one)
                            Pred.arguments[i] = to_this;
                        if (Pred.arguments[i] is function)
                        {
                            function f = new function((function)Pred.arguments[i]);
                            Pred.arguments[i] = f.change_variable(this_one, to_this);
                        }
                    }
                    //new_expression.logical_exp.Add(Pred);
                }
                if (second_operand.is_Predicate)
                {
                    Predicate Pred = new Predicate((Predicate)second_operand.logical_exp[0]);
                    for (int i = 0; i < Pred.arguments.Count; i++)
                    {
                        if (Pred.arguments[i] is function)
                        {
                            function f = new function((function)Pred.arguments[i]);
                            Pred.arguments[i] = f.change_variable(this_one, to_this);
                        }
                        else if ((string)Pred.arguments[i] == this_one)
                            Pred.arguments[i] = to_this;

                    }
                    //new_expression.logical_exp.Add(Pred);
                }
            }
            else
            {
                Predicate Pred = new Predicate((Predicate)this.logical_exp[0]);
                for (int i = 0; i < Pred.arguments.Count; i++)
                {
                    if (Pred.arguments[i] is function)
                    {
                        function f = new function((function)Pred.arguments[i]);
                        Pred.arguments[i] = f.change_variable(this_one, to_this);
                    }
                    else if ((string)Pred.arguments[i] == this_one)
                        Pred.arguments[i] = to_this;

                }
                new_expression.logical_exp.Add(Pred);
            }

            return new_expression;

        }

        public formula make_SSF()
        {
            if (this.is_PNF)
            {
                formula ssf = new formula();
                if (this.top_operation is quantifier)
                {

                    int all_quantors = 0;
                    int existance_quantors = -1;
                    ArrayList all_variables = new ArrayList();
                    ArrayList quantifiers = new ArrayList();
                    while (this.is_quantum_expression && top_operation is quantifier)
                    {
                        quantifier K = new quantifier((quantifier)this.top_operation);
                        if (K.is_universality)
                        {
                            all_quantors++;
                            quantifiers.Add(K);
                            this.logical_exp.RemoveAt(0);
                            all_variables.Add(K.variable);
                        }
                        else // if (K.is_existance)
                        {
                            existance_quantors++;
                            if (all_quantors == 0)
                            {
                                this.logical_exp.RemoveAt(0);
                                this.rename_variable(K.variable, "const");
                            }
                            else
                            {
                                this.logical_exp.RemoveAt(0);
                                function scolem = new function("s" + existance_quantors, all_variables);
                                ssf = this.change_variable(K.variable, scolem);
                            }
                        }
                    }
                    ssf.logical_exp.InsertRange(0, quantifiers);
                }
                else
                {
                    return ssf;
                }

                return ssf;
            }
            else
            {
                MessageBox.Show("Для сколемизации формула должна быть в ПНФ!", "Ошибка");
                return this;
            }
        }
    }
}
