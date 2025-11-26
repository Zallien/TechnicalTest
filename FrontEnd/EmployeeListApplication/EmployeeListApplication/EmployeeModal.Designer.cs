namespace EmployeeListApplication
{
    partial class EmployeeModal
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            firstnametxt = new TextBox();
            lastnametxt = new TextBox();
            middlenametxt = new TextBox();
            agetxt = new TextBox();
            submitbutton = new Button();
            label7 = new Label();
            usernametxt = new TextBox();
            sexcombobox = new ComboBox();
            cancelbutton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(12, 43, 78);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 30);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Cambria", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 30);
            label1.TabIndex = 0;
            label1.Text = "Add Employee";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Cambria", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(131, 28);
            label2.TabIndex = 1;
            label2.Text = "Firstname :";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Cambria", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(131, 28);
            label3.TabIndex = 2;
            label3.Text = "Lastname :";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Cambria", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 104);
            label4.Name = "label4";
            label4.Size = new Size(131, 28);
            label4.TabIndex = 3;
            label4.Text = "Middlename :";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Cambria", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 132);
            label5.Name = "label5";
            label5.Size = new Size(131, 28);
            label5.TabIndex = 4;
            label5.Text = "Sex :";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Font = new Font("Cambria", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 160);
            label6.Name = "label6";
            label6.Size = new Size(131, 28);
            label6.TabIndex = 5;
            label6.Text = "Age: ";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // firstnametxt
            // 
            firstnametxt.Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            firstnametxt.Location = new Point(149, 48);
            firstnametxt.Name = "firstnametxt";
            firstnametxt.Size = new Size(289, 23);
            firstnametxt.TabIndex = 6;
            // 
            // lastnametxt
            // 
            lastnametxt.Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lastnametxt.Location = new Point(149, 77);
            lastnametxt.Name = "lastnametxt";
            lastnametxt.Size = new Size(289, 23);
            lastnametxt.TabIndex = 7;
            // 
            // middlenametxt
            // 
            middlenametxt.Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            middlenametxt.Location = new Point(149, 106);
            middlenametxt.Name = "middlenametxt";
            middlenametxt.Size = new Size(289, 23);
            middlenametxt.TabIndex = 8;
            // 
            // agetxt
            // 
            agetxt.Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            agetxt.Location = new Point(149, 165);
            agetxt.Name = "agetxt";
            agetxt.Size = new Size(289, 23);
            agetxt.TabIndex = 10;
            agetxt.KeyPress += agetxt_KeyPress;
            // 
            // submitbutton
            // 
            submitbutton.FlatStyle = FlatStyle.Flat;
            submitbutton.Font = new Font("Cambria", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitbutton.Location = new Point(338, 245);
            submitbutton.Name = "submitbutton";
            submitbutton.Size = new Size(100, 23);
            submitbutton.TabIndex = 11;
            submitbutton.Text = "Add";
            submitbutton.UseVisualStyleBackColor = true;
            submitbutton.Click += submitbutton_Click;
            // 
            // label7
            // 
            label7.Font = new Font("Cambria", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 188);
            label7.Name = "label7";
            label7.Size = new Size(131, 28);
            label7.TabIndex = 12;
            label7.Text = "Username :";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // usernametxt
            // 
            usernametxt.Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernametxt.Location = new Point(149, 194);
            usernametxt.Name = "usernametxt";
            usernametxt.Size = new Size(289, 23);
            usernametxt.TabIndex = 13;
            // 
            // sexcombobox
            // 
            sexcombobox.AutoCompleteCustomSource.AddRange(new string[] { "Male", "Female" });
            sexcombobox.Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sexcombobox.FormattingEnabled = true;
            sexcombobox.Items.AddRange(new object[] { "Male", "Female" });
            sexcombobox.Location = new Point(149, 135);
            sexcombobox.Name = "sexcombobox";
            sexcombobox.Size = new Size(289, 23);
            sexcombobox.TabIndex = 14;
            // 
            // cancelbutton
            // 
            cancelbutton.FlatStyle = FlatStyle.Flat;
            cancelbutton.Font = new Font("Cambria", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelbutton.Location = new Point(232, 245);
            cancelbutton.Name = "cancelbutton";
            cancelbutton.Size = new Size(100, 23);
            cancelbutton.TabIndex = 15;
            cancelbutton.Text = "Cancel";
            cancelbutton.UseVisualStyleBackColor = true;
            cancelbutton.Click += cancelbutton_Click;
            // 
            // EmployeeModal
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 280);
            Controls.Add(cancelbutton);
            Controls.Add(sexcombobox);
            Controls.Add(usernametxt);
            Controls.Add(label7);
            Controls.Add(submitbutton);
            Controls.Add(agetxt);
            Controls.Add(middlenametxt);
            Controls.Add(lastnametxt);
            Controls.Add(firstnametxt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeModal";
            Text = "EmployeeModal";
            Load += EmployeeModal_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox firstnametxt;
        private TextBox lastnametxt;
        private TextBox middlenametxt;
        private TextBox agetxt;
        private Button submitbutton;
        private Label label7;
        private TextBox usernametxt;
        private ComboBox sexcombobox;
        private Button cancelbutton;
    }
}