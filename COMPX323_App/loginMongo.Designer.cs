namespace COMPX323_App
{
    partial class loginMongo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginMongo));
            this.loginButtonMongo = new System.Windows.Forms.Button();
            this.password_input_mongo = new System.Windows.Forms.TextBox();
            this.passwordLabelMongo = new System.Windows.Forms.Label();
            this.emai_input_mongo = new System.Windows.Forms.TextBox();
            this.emailLabelMongo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginButtonMongo
            // 
            this.loginButtonMongo.Location = new System.Drawing.Point(270, 43);
            this.loginButtonMongo.Name = "loginButtonMongo";
            this.loginButtonMongo.Size = new System.Drawing.Size(75, 23);
            this.loginButtonMongo.TabIndex = 9;
            this.loginButtonMongo.Text = "Login";
            this.loginButtonMongo.UseVisualStyleBackColor = true;
            this.loginButtonMongo.Click += new System.EventHandler(this.loginButtonMongo_ClickAsync);
            // 
            // password_input_mongo
            // 
            this.password_input_mongo.AcceptsReturn = true;
            this.password_input_mongo.AcceptsTab = true;
            this.password_input_mongo.Location = new System.Drawing.Point(143, 43);
            this.password_input_mongo.Name = "password_input_mongo";
            this.password_input_mongo.PasswordChar = '*';
            this.password_input_mongo.Size = new System.Drawing.Size(100, 20);
            this.password_input_mongo.TabIndex = 8;
            // 
            // passwordLabelMongo
            // 
            this.passwordLabelMongo.AutoSize = true;
            this.passwordLabelMongo.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabelMongo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabelMongo.Location = new System.Drawing.Point(46, 43);
            this.passwordLabelMongo.Name = "passwordLabelMongo";
            this.passwordLabelMongo.Size = new System.Drawing.Size(78, 20);
            this.passwordLabelMongo.TabIndex = 7;
            this.passwordLabelMongo.Text = "Password";
            // 
            // emai_input_mongo
            // 
            this.emai_input_mongo.Location = new System.Drawing.Point(143, 17);
            this.emai_input_mongo.Name = "emai_input_mongo";
            this.emai_input_mongo.Size = new System.Drawing.Size(100, 20);
            this.emai_input_mongo.TabIndex = 6;
            // 
            // emailLabelMongo
            // 
            this.emailLabelMongo.AutoSize = true;
            this.emailLabelMongo.BackColor = System.Drawing.Color.Transparent;
            this.emailLabelMongo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabelMongo.Location = new System.Drawing.Point(46, 17);
            this.emailLabelMongo.Name = "emailLabelMongo";
            this.emailLabelMongo.Size = new System.Drawing.Size(48, 20);
            this.emailLabelMongo.TabIndex = 5;
            this.emailLabelMongo.Text = "Email";
            // 
            // loginMongo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(399, 282);
            this.Controls.Add(this.loginButtonMongo);
            this.Controls.Add(this.password_input_mongo);
            this.Controls.Add(this.passwordLabelMongo);
            this.Controls.Add(this.emai_input_mongo);
            this.Controls.Add(this.emailLabelMongo);
            this.Name = "loginMongo";
            this.Text = "Login Using MongoDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButtonMongo;
        private System.Windows.Forms.TextBox password_input_mongo;
        private System.Windows.Forms.Label passwordLabelMongo;
        private System.Windows.Forms.TextBox emai_input_mongo;
        private System.Windows.Forms.Label emailLabelMongo;
    }
}