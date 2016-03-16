namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.evaluate_button = new System.Windows.Forms.Button();
            this.insert_implication_button = new System.Windows.Forms.Button();
            this.insert_equality_button = new System.Windows.Forms.Button();
            this.insert_disjunction_button = new System.Windows.Forms.Button();
            this.insert_conjunction_button = new System.Windows.Forms.Button();
            this.insert_negation_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.formula_is_DNF = new System.Windows.Forms.Label();
            this.formula_is_KNF = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.make_DNF = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.Expression_checkbox = new System.Windows.Forms.CheckBox();
            this.Predicate_checkbox = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.make_pnf_button = new System.Windows.Forms.Button();
            this.make_ssf_button = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(32, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(409, 145);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "a|b|c&d&g&~d&(~g|v)&e";
            // 
            // evaluate_button
            // 
            this.evaluate_button.Location = new System.Drawing.Point(436, 197);
            this.evaluate_button.Name = "evaluate_button";
            this.evaluate_button.Size = new System.Drawing.Size(75, 23);
            this.evaluate_button.TabIndex = 1;
            this.evaluate_button.Text = "evaluate";
            this.evaluate_button.UseVisualStyleBackColor = true;
            this.evaluate_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // insert_implication_button
            // 
            this.insert_implication_button.Location = new System.Drawing.Point(32, 12);
            this.insert_implication_button.Name = "insert_implication_button";
            this.insert_implication_button.Size = new System.Drawing.Size(75, 23);
            this.insert_implication_button.TabIndex = 2;
            this.insert_implication_button.Text = "→";
            this.insert_implication_button.UseVisualStyleBackColor = true;
            this.insert_implication_button.Click += new System.EventHandler(this.insert_implication_button_Click);
            // 
            // insert_equality_button
            // 
            this.insert_equality_button.Location = new System.Drawing.Point(113, 12);
            this.insert_equality_button.Name = "insert_equality_button";
            this.insert_equality_button.Size = new System.Drawing.Size(75, 23);
            this.insert_equality_button.TabIndex = 3;
            this.insert_equality_button.Text = "=";
            this.insert_equality_button.UseVisualStyleBackColor = true;
            this.insert_equality_button.Click += new System.EventHandler(this.insert_equality_button_Click);
            // 
            // insert_disjunction_button
            // 
            this.insert_disjunction_button.Location = new System.Drawing.Point(194, 12);
            this.insert_disjunction_button.Name = "insert_disjunction_button";
            this.insert_disjunction_button.Size = new System.Drawing.Size(75, 23);
            this.insert_disjunction_button.TabIndex = 4;
            this.insert_disjunction_button.Text = "dis";
            this.insert_disjunction_button.UseVisualStyleBackColor = true;
            this.insert_disjunction_button.Click += new System.EventHandler(this.insert_disjunction_button_Click);
            // 
            // insert_conjunction_button
            // 
            this.insert_conjunction_button.Location = new System.Drawing.Point(275, 12);
            this.insert_conjunction_button.Name = "insert_conjunction_button";
            this.insert_conjunction_button.Size = new System.Drawing.Size(75, 23);
            this.insert_conjunction_button.TabIndex = 5;
            this.insert_conjunction_button.Text = "con&";
            this.insert_conjunction_button.UseVisualStyleBackColor = true;
            this.insert_conjunction_button.Click += new System.EventHandler(this.insert_conjunction_button_Click);
            // 
            // insert_negation_button
            // 
            this.insert_negation_button.Location = new System.Drawing.Point(356, 12);
            this.insert_negation_button.Name = "insert_negation_button";
            this.insert_negation_button.Size = new System.Drawing.Size(75, 23);
            this.insert_negation_button.TabIndex = 6;
            this.insert_negation_button.Text = "¬";
            this.insert_negation_button.UseVisualStyleBackColor = true;
            this.insert_negation_button.Click += new System.EventHandler(this.insert_negation_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Is DNF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Is KNF:";
            // 
            // formula_is_DNF
            // 
            this.formula_is_DNF.AutoSize = true;
            this.formula_is_DNF.Location = new System.Drawing.Point(29, 226);
            this.formula_is_DNF.Name = "formula_is_DNF";
            this.formula_is_DNF.Size = new System.Drawing.Size(16, 13);
            this.formula_is_DNF.TabIndex = 9;
            this.formula_is_DNF.Text = "...";
            // 
            // formula_is_KNF
            // 
            this.formula_is_KNF.AutoSize = true;
            this.formula_is_KNF.Location = new System.Drawing.Point(110, 226);
            this.formula_is_KNF.Name = "formula_is_KNF";
            this.formula_is_KNF.Size = new System.Drawing.Size(16, 13);
            this.formula_is_KNF.TabIndex = 10;
            this.formula_is_KNF.Text = "...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Exp Example 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(194, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Exp Example 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(396, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 22);
            this.button3.TabIndex = 13;
            this.button3.Text = "perform distribution law";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(194, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Exp Example 3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(194, 289);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Exp Example 4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // make_DNF
            // 
            this.make_DNF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.make_DNF.Location = new System.Drawing.Point(396, 254);
            this.make_DNF.Name = "make_DNF";
            this.make_DNF.Size = new System.Drawing.Size(75, 23);
            this.make_DNF.TabIndex = 16;
            this.make_DNF.Text = "Make DNF";
            this.make_DNF.UseVisualStyleBackColor = true;
            this.make_DNF.Click += new System.EventHandler(this.make_DNF_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(447, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "All";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(447, 41);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 18;
            this.button7.Text = "Exists";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(285, 202);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 19;
            this.button8.Text = "Predicate 1";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(477, 254);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Make KNF";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Expression_checkbox
            // 
            this.Expression_checkbox.AutoSize = true;
            this.Expression_checkbox.Checked = true;
            this.Expression_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Expression_checkbox.Location = new System.Drawing.Point(32, 260);
            this.Expression_checkbox.Name = "Expression_checkbox";
            this.Expression_checkbox.Size = new System.Drawing.Size(102, 17);
            this.Expression_checkbox.TabIndex = 21;
            this.Expression_checkbox.Text = "Expression logic";
            this.Expression_checkbox.UseVisualStyleBackColor = true;
            this.Expression_checkbox.CheckedChanged += new System.EventHandler(this.Expression_checkbox_CheckedChanged);
            // 
            // Predicate_checkbox
            // 
            this.Predicate_checkbox.AutoSize = true;
            this.Predicate_checkbox.Location = new System.Drawing.Point(32, 283);
            this.Predicate_checkbox.Name = "Predicate_checkbox";
            this.Predicate_checkbox.Size = new System.Drawing.Size(101, 17);
            this.Predicate_checkbox.TabIndex = 22;
            this.Predicate_checkbox.Text = "Predicates logic";
            this.Predicate_checkbox.UseVisualStyleBackColor = true;
            this.Predicate_checkbox.CheckedChanged += new System.EventHandler(this.Predicate_checkbox_CheckedChanged);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(285, 231);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 23;
            this.button10.Text = "Predicate 2";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // make_pnf_button
            // 
            this.make_pnf_button.Location = new System.Drawing.Point(396, 283);
            this.make_pnf_button.Name = "make_pnf_button";
            this.make_pnf_button.Size = new System.Drawing.Size(75, 23);
            this.make_pnf_button.TabIndex = 24;
            this.make_pnf_button.Text = "Make PNF";
            this.make_pnf_button.UseVisualStyleBackColor = true;
            this.make_pnf_button.Click += new System.EventHandler(this.make_pnf_button_Click);
            // 
            // make_ssf_button
            // 
            this.make_ssf_button.Location = new System.Drawing.Point(477, 283);
            this.make_ssf_button.Name = "make_ssf_button";
            this.make_ssf_button.Size = new System.Drawing.Size(75, 23);
            this.make_ssf_button.TabIndex = 25;
            this.make_ssf_button.Text = "Make SSF";
            this.make_ssf_button.UseVisualStyleBackColor = true;
            this.make_ssf_button.Click += new System.EventHandler(this.make_ssf_button_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(285, 260);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 26;
            this.button11.Text = "Predicate 3";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(285, 289);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 27;
            this.button12.Text = "Predicate 4";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 323);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.make_ssf_button);
            this.Controls.Add(this.make_pnf_button);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.Predicate_checkbox);
            this.Controls.Add(this.Expression_checkbox);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.make_DNF);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.formula_is_KNF);
            this.Controls.Add(this.formula_is_DNF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.insert_negation_button);
            this.Controls.Add(this.insert_conjunction_button);
            this.Controls.Add(this.insert_disjunction_button);
            this.Controls.Add(this.insert_equality_button);
            this.Controls.Add(this.insert_implication_button);
            this.Controls.Add(this.evaluate_button);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button evaluate_button;
        private System.Windows.Forms.Button insert_implication_button;
        private System.Windows.Forms.Button insert_equality_button;
        private System.Windows.Forms.Button insert_disjunction_button;
        private System.Windows.Forms.Button insert_conjunction_button;
        private System.Windows.Forms.Button insert_negation_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label formula_is_DNF;
        private System.Windows.Forms.Label formula_is_KNF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button make_DNF;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.CheckBox Expression_checkbox;
        private System.Windows.Forms.CheckBox Predicate_checkbox;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button make_pnf_button;
        private System.Windows.Forms.Button make_ssf_button;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
    }
}

