using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formula a = new formula();
            if (Expression_checkbox.Checked)
            {
                a = string_helper.Parser_Expressions(richTextBox1.Text); //Строим по строке формулу
            }
            else //if (Predicate_checkbox.Checked)
            {
                a = string_helper.Parser_Predicates(richTextBox1.Text); //Строим по строке формулу
            }
            a = a.get_basic();
            formula_is_DNF.Text = "...";
            formula_is_KNF.Text = "...";
            //a = a.get_basic(); //приведем формулу к нормальному виду
            richTextBox1.Text = a.ToString();   //выводим ее назад

            if (a.is_DNF)
            {
                formula_is_DNF.Text = "true";
            }
            else
            {
                formula_is_DNF.Text = "false";
            }
            if (a.is_KNF)
            {
                formula_is_KNF.Text = "true";
            }
            else
            {
                formula_is_KNF.Text = "false";
            }
        }

        private void insert_implication_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Properties.Settings.Default.implication;
        }

        private void insert_equality_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Properties.Settings.Default.equality;
        }

        private void insert_disjunction_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Properties.Settings.Default.disjunct;
        }

        private void insert_conjunction_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Properties.Settings.Default.conjunct;
        }

        private void insert_negation_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Properties.Settings.Default.negation;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = "a|b|c&d&g&~d&(~(g|v))&e";
            Expression_checkbox.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "(x→y)→((x→z)→(x→(y&z)))";
            Expression_checkbox.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formula a = new formula();
            if (Expression_checkbox.Checked)
            {
                a = string_helper.Parser_Expressions(richTextBox1.Text); //Строим по строке формулу
            }
            else //if (Predicate_checkbox.Checked)
            {
                a = string_helper.Parser_Predicates(richTextBox1.Text); //Строим по строке формулу
            }
            a = a.get_basic(); //приведем формулу к нормальному виду
            a = a.distributivity();
            richTextBox1.Text = a.ToString();   //выводим ее назад
            if (a.is_DNF)
            {
                formula_is_DNF.Text = "true";
            }
            else
            {
                formula_is_DNF.Text = "false";
            }
            if (a.is_KNF)
            {
                formula_is_KNF.Text = "true";
            }
            else
            {
                formula_is_KNF.Text = "false";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Ring & (Bilbo | Gollum)";
            Expression_checkbox.Checked = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "(Bilbo | Gollum) & Ring ";
            Expression_checkbox.Checked = true;
        }

        private void make_DNF_Click(object sender, EventArgs e)
        {
            formula a = new formula();
            if (Expression_checkbox.Checked)
            {
                a = string_helper.Parser_Expressions(richTextBox1.Text); //Строим по строке формулу
            }
            else //if (Predicate_checkbox.Checked)
            {
                a = string_helper.Parser_Predicates(richTextBox1.Text); //Строим по строке формулу
            }
            a = a.get_basic(); //приведем формулу к нормальному виду
            a = a.make_DNF();
            richTextBox1.Text = a.ToString();   //выводим ее назад
            if (a.is_DNF)
            {
                formula_is_DNF.Text = "true";
            }
            else
            {
                formula_is_DNF.Text = "false";
            }
            if (a.is_KNF)
            {
                formula_is_KNF.Text = "true";
            }
            else
            {
                formula_is_KNF.Text = "false";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Properties.Settings.Default.All;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Properties.Settings.Default.Exists;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "∀var(P(var,x1)&G(y))";
            Predicate_checkbox.Checked = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            formula a = new formula();
            if (Expression_checkbox.Checked)
            {
                a = string_helper.Parser_Expressions(richTextBox1.Text); //Строим по строке формулу
            }
            else //if (Predicate_checkbox.Checked)
            {
                a = string_helper.Parser_Predicates(richTextBox1.Text); //Строим по строке формулу
            }
            a = a.get_basic(); //приведем формулу к нормальному виду
            a = a.make_KNF();
            richTextBox1.Text = a.ToString();   //выводим ее назад
            if (a.is_DNF)
            {
                formula_is_DNF.Text = "true";
            }
            else
            {
                formula_is_DNF.Text = "false";
            }
            if (a.is_KNF)
            {
                formula_is_KNF.Text = "true";
            }
            else
            {
                formula_is_KNF.Text = "false";
            }
        }

        private void Predicate_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Predicate_checkbox.Checked)
            {
                Expression_checkbox.Checked = false;
            }
        }

        private void Expression_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Expression_checkbox.Checked)
            {
                Predicate_checkbox.Checked = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "(∀var (P(var,x1)&G(y)))|(∃x (P(x)))";
            Predicate_checkbox.Checked = true;
        }

        private void make_pnf_button_Click(object sender, EventArgs e)
        {
            formula a = new formula();
            if (Expression_checkbox.Checked)
            {
                MessageBox.Show("Необходимо выражение ИППП", "Ошибка");
                richTextBox1.Text = "Введите сюда выражение ИППП";
                
            }
            else //if (Predicate_checkbox.Checked)
            {
                a = string_helper.Parser_Predicates(richTextBox1.Text); //Строим по строке формулу

                a = a.get_basic(); //приведем формулу к нормальному виду
                a = a.make_PNF();
                richTextBox1.Text = a.ToString();   //выводим ее назад
                if (a.is_DNF)
                {
                    formula_is_DNF.Text = "true";
                }
                else
                {
                    formula_is_DNF.Text = "false";
                }
                if (a.is_KNF)
                {
                    formula_is_KNF.Text = "true";
                }
                else
                {
                    formula_is_KNF.Text = "false";
                }
            }
        }

        private void make_ssf_button_Click(object sender, EventArgs e)
        {
            formula a = new formula();
            if (Expression_checkbox.Checked)
            {
                MessageBox.Show("Необходимо выражение ИППП", "Ошибка");
                richTextBox1.Text = "Введите сюда выражение ИППП";
            }
            else //if (Predicate_checkbox.Checked)
            {
                a = string_helper.Parser_Predicates(richTextBox1.Text); //Строим по строке формулу

                a = a.get_basic(); //приведем формулу к нормальному виду
                a = a.make_PNF();
                a = a.make_SSF();
                richTextBox1.Text = a.ToString();   //выводим ее назад
                if (a.is_DNF)
                {
                    formula_is_DNF.Text = "true";
                }
                else
                {
                    formula_is_DNF.Text = "false";
                }
                if (a.is_KNF)
                {
                    formula_is_KNF.Text = "true";
                }
                else
                {
                    formula_is_KNF.Text = "false";
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "(∀var (P(var,y)&G(y)))|(∃x (P(x)))|(∀y(B(x,y)))";
            Predicate_checkbox.Checked = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Predicate_checkbox.Checked = true;
            richTextBox1.Text = "(∃x((∀var (P(var,x1)&G(y)))|(∃x (P(x)))))";
        }


    }
}
