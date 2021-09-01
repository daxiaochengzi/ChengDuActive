namespace BenDingForm
{
    partial class Form2
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
            this.btn_ini = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Transaction_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ini
            // 
            this.btn_ini.Location = new System.Drawing.Point(108, 28);
            this.btn_ini.Name = "btn_ini";
            this.btn_ini.Size = new System.Drawing.Size(75, 23);
            this.btn_ini.TabIndex = 0;
            this.btn_ini.Text = "初始化";
            this.btn_ini.UseVisualStyleBackColor = true;
            this.btn_ini.Click += new System.EventHandler(this.btn_ini_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "入参：";
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(74, 124);
            this.txt_Input.Multiline = true;
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(885, 200);
            this.txt_Input.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "出参:";
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(74, 341);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.Size = new System.Drawing.Size(885, 253);
            this.txt_Output.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Transaction_Code);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_ini);
            this.panel1.Location = new System.Drawing.Point(16, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 100);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "执行控件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Transaction_Code
            // 
            this.txt_Transaction_Code.Location = new System.Drawing.Point(366, 30);
            this.txt_Transaction_Code.Name = "txt_Transaction_Code";
            this.txt_Transaction_Code.Size = new System.Drawing.Size(184, 21);
            this.txt_Transaction_Code.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "交易编号";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_Output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ini;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Transaction_Code;
    }
}