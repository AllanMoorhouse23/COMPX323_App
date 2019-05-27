namespace COMPX323_App
{
    partial class index
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
            this.openLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mongoLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonMongoHome = new System.Windows.Forms.Button();
            this.buttonOracleHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openLogin
            // 
            this.openLogin.Location = new System.Drawing.Point(195, 89);
            this.openLogin.Name = "openLogin";
            this.openLogin.Size = new System.Drawing.Size(88, 23);
            this.openLogin.TabIndex = 1;
            this.openLogin.Text = "Login";
            this.openLogin.UseVisualStyleBackColor = true;
            this.openLogin.Click += new System.EventHandler(this.openLogin_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mongoLogin
            // 
            this.mongoLogin.Location = new System.Drawing.Point(31, 89);
            this.mongoLogin.Name = "mongoLogin";
            this.mongoLogin.Size = new System.Drawing.Size(88, 23);
            this.mongoLogin.TabIndex = 3;
            this.mongoLogin.Text = "Login";
            this.mongoLogin.UseVisualStyleBackColor = true;
            this.mongoLogin.Click += new System.EventHandler(this.mongoLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "MongoDB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Oracle";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 8;
            // 
            // buttonMongoHome
            // 
            this.buttonMongoHome.Location = new System.Drawing.Point(31, 130);
            this.buttonMongoHome.Name = "buttonMongoHome";
            this.buttonMongoHome.Size = new System.Drawing.Size(88, 23);
            this.buttonMongoHome.TabIndex = 10;
            this.buttonMongoHome.Text = "Home";
            this.buttonMongoHome.UseVisualStyleBackColor = true;
            this.buttonMongoHome.Click += new System.EventHandler(this.ButtonMongoHome_Click);
            // 
            // buttonOracleHome
            // 
            this.buttonOracleHome.Location = new System.Drawing.Point(195, 130);
            this.buttonOracleHome.Name = "buttonOracleHome";
            this.buttonOracleHome.Size = new System.Drawing.Size(88, 23);
            this.buttonOracleHome.TabIndex = 11;
            this.buttonOracleHome.Text = "Home";
            this.buttonOracleHome.UseVisualStyleBackColor = true;
            this.buttonOracleHome.Click += new System.EventHandler(this.ButtonOracleHome_Click);
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 231);
            this.Controls.Add(this.buttonOracleHome);
            this.Controls.Add(this.buttonMongoHome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mongoLogin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openLogin);
            this.Name = "index";
            this.Text = "Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button mongoLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonMongoHome;
        private System.Windows.Forms.Button buttonOracleHome;
        //private System.Windows.Forms.Label label5;
    }
}

