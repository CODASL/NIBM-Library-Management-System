namespace Library_Management_System_v1._1
{
    partial class Login
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
        [System.Obsolete]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.bluebackround = new System.Windows.Forms.Panel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnlogin = new Library_Management_System_v1._1.View.Custom_Controls.RJButton();
            this.btnQR = new Library_Management_System_v1._1.View.Custom_Controls.RJButton();
            this.txtPass = new CustomControls.RJControls.RJTextBox();
            this.txtmail = new CustomControls.RJControls.RJTextBox();
            this.bluebackround.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.SuspendLayout();
            // 
            // bluebackround
            // 
            this.bluebackround.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(159)))));
            this.bluebackround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bluebackround.Controls.Add(this.label5);
            this.bluebackround.Controls.Add(this.label4);
            this.bluebackround.Controls.Add(this.label3);
            this.bluebackround.Controls.Add(this.piclogo);
            this.bluebackround.Location = new System.Drawing.Point(0, 23);
            this.bluebackround.Name = "bluebackround";
            this.bluebackround.Size = new System.Drawing.Size(300, 450);
            this.bluebackround.TabIndex = 10;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.btnQR);
            this.materialCard1.Controls.Add(this.label6);
            this.materialCard1.Controls.Add(this.metroPanel1);
            this.materialCard1.Controls.Add(this.resetBtn);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(292, 23);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(343, 450);
            this.materialCard1.TabIndex = 26;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.txtmail);
            this.metroPanel1.Controls.Add(this.txtPass);
            this.metroPanel1.Controls.Add(this.btnlogin);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(46, 103);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(251, 220);
            this.metroPanel1.TabIndex = 22;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Employee ID";
            // 
            // resetBtn
            // 
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(113, 401);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(109, 23);
            this.resetBtn.TabIndex = 25;
            this.resetBtn.Text = "Reset Password";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // piclogo
            // 
            this.piclogo.Image = ((System.Drawing.Image)(resources.GetObject("piclogo.Image")));
            this.piclogo.Location = new System.Drawing.Point(21, 32);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(72, 70);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piclogo.TabIndex = 11;
            this.piclogo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "NIBM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "LIBRARY MANAGEMENT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "SYSTEM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(43, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Hello Welcome Again !";
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnlogin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnlogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnlogin.BorderRadius = 8;
            this.btnlogin.BorderSize = 0;
            this.btnlogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnlogin.FlatAppearance.BorderSize = 0;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Roboto Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Image = ((System.Drawing.Image)(resources.GetObject("btnlogin.Image")));
            this.btnlogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogin.Location = new System.Drawing.Point(0, 180);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(251, 40);
            this.btnlogin.TabIndex = 27;
            this.btnlogin.Text = "Login";
            this.btnlogin.TextColor = System.Drawing.Color.White;
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnQR
            // 
            this.btnQR.BackColor = System.Drawing.Color.White;
            this.btnQR.BackgroundColor = System.Drawing.Color.White;
            this.btnQR.BorderColor = System.Drawing.Color.Black;
            this.btnQR.BorderRadius = 8;
            this.btnQR.BorderSize = 1;
            this.btnQR.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnQR.FlatAppearance.BorderSize = 0;
            this.btnQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQR.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQR.ForeColor = System.Drawing.Color.Black;
            this.btnQR.Image = ((System.Drawing.Image)(resources.GetObject("btnQR.Image")));
            this.btnQR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQR.Location = new System.Drawing.Point(46, 342);
            this.btnQR.Name = "btnQR";
            this.btnQR.Size = new System.Drawing.Size(251, 40);
            this.btnQR.TabIndex = 28;
            this.btnQR.Text = "Login with QR";
            this.btnQR.TextColor = System.Drawing.Color.Black;
            this.btnQR.UseVisualStyleBackColor = false;
            this.btnQR.Click += new System.EventHandler(this.btnQR_Click);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtPass.BorderColor = System.Drawing.Color.Black;
            this.txtPass.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(159)))));
            this.txtPass.BorderSize = 2;
            this.txtPass.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(0, 133);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Multiline = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.Padding = new System.Windows.Forms.Padding(7);
            this.txtPass.PasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(250, 28);
            this.txtPass.TabIndex = 15;
            this.txtPass.Text = "";
            this.txtPass.UnderlinedStyle = true;
            // 
            // txtmail
            // 
            this.txtmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtmail.BorderColor = System.Drawing.Color.Black;
            this.txtmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(159)))));
            this.txtmail.BorderSize = 2;
            this.txtmail.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmail.ForeColor = System.Drawing.Color.Black;
            this.txtmail.Location = new System.Drawing.Point(0, 52);
            this.txtmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtmail.Multiline = false;
            this.txtmail.Name = "txtmail";
            this.txtmail.Padding = new System.Windows.Forms.Padding(7);
            this.txtmail.PasswordChar = false;
            this.txtmail.Size = new System.Drawing.Size(250, 28);
            this.txtmail.TabIndex = 28;
            this.txtmail.Text = "";
            this.txtmail.UnderlinedStyle = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 466);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.bluebackround);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Login";
            this.bluebackround.ResumeLayout(false);
            this.bluebackround.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bluebackround;
        private System.Windows.Forms.PictureBox piclogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Button resetBtn;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private View.Custom_Controls.RJButton btnlogin;
        private View.Custom_Controls.RJButton btnQR;
        private CustomControls.RJControls.RJTextBox txtPass;
        private CustomControls.RJControls.RJTextBox txtmail;
    }
}