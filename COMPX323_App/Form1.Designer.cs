namespace COMPX323_App
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
            this.label1 = new System.Windows.Forms.Label();
            this.openLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mongoLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // openLogin
            // 
            this.openLogin.Location = new System.Drawing.Point(77, 75);
            this.openLogin.Name = "openLogin";
            this.openLogin.Size = new System.Drawing.Size(75, 23);
            this.openLogin.TabIndex = 1;
            this.openLogin.Text = "Login";
            this.openLogin.UseVisualStyleBackColor = true;
            this.openLogin.Click += new System.EventHandler(this.openLogin_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "MongoDB Connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mongoLogin
            // 
            this.mongoLogin.Location = new System.Drawing.Point(12, 148);
            this.mongoLogin.Name = "mongoLogin";
            this.mongoLogin.Size = new System.Drawing.Size(140, 23);
            this.mongoLogin.TabIndex = 3;
            this.mongoLogin.Text = "MongoDB Login";
            this.mongoLogin.UseVisualStyleBackColor = true;
            this.mongoLogin.Click += new System.EventHandler(this.mongoLogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mongoLogin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openLogin);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button mongoLogin;
    }
}

