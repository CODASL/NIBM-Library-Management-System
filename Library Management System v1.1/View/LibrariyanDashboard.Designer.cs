
namespace Library_Management_System_v1._1.View
{
    partial class LibrariyanDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibrariyanDashboard));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.LibrariyanProfileBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.bookBorrowingBtn = new System.Windows.Forms.Button();
            this.btnManageFee = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.IntroPanel = new MetroFramework.Controls.MetroPanel();
            this.avatarImg = new System.Windows.Forms.PictureBox();
            this.lblUserPosition = new MetroFramework.Controls.MetroLabel();
            this.lblUserName = new MetroFramework.Controls.MetroLabel();
            this.contextPanel = new MetroFramework.Controls.MetroPanel();
            this.Heading = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroPanel1.SuspendLayout();
            this.IntroPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarImg)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.LibrariyanProfileBtn);
            this.metroPanel1.Controls.Add(this.logoutBtn);
            this.metroPanel1.Controls.Add(this.bookBorrowingBtn);
            this.metroPanel1.Controls.Add(this.btnManageFee);
            this.metroPanel1.Controls.Add(this.btnManageCustomers);
            this.metroPanel1.Controls.Add(this.btnManageUsers);
            this.metroPanel1.Controls.Add(this.btnDashboard);
            this.metroPanel1.Controls.Add(this.IntroPanel);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(195, 469);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // LibrariyanProfileBtn
            // 
            this.LibrariyanProfileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LibrariyanProfileBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.LibrariyanProfileBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LibrariyanProfileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LibrariyanProfileBtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LibrariyanProfileBtn.Image = ((System.Drawing.Image)(resources.GetObject("LibrariyanProfileBtn.Image")));
            this.LibrariyanProfileBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LibrariyanProfileBtn.Location = new System.Drawing.Point(0, 304);
            this.LibrariyanProfileBtn.Name = "LibrariyanProfileBtn";
            this.LibrariyanProfileBtn.Size = new System.Drawing.Size(195, 41);
            this.LibrariyanProfileBtn.TabIndex = 9;
            this.LibrariyanProfileBtn.Text = "My Profile";
            this.LibrariyanProfileBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LibrariyanProfileBtn.UseVisualStyleBackColor = true;
            this.LibrariyanProfileBtn.Click += new System.EventHandler(this.LibrariyanProfileBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.Location = new System.Drawing.Point(47, 381);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(76, 29);
            this.logoutBtn.TabIndex = 8;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // bookBorrowingBtn
            // 
            this.bookBorrowingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookBorrowingBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.bookBorrowingBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bookBorrowingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookBorrowingBtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookBorrowingBtn.Image = ((System.Drawing.Image)(resources.GetObject("bookBorrowingBtn.Image")));
            this.bookBorrowingBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bookBorrowingBtn.Location = new System.Drawing.Point(0, 263);
            this.bookBorrowingBtn.Name = "bookBorrowingBtn";
            this.bookBorrowingBtn.Size = new System.Drawing.Size(195, 41);
            this.bookBorrowingBtn.TabIndex = 7;
            this.bookBorrowingBtn.Text = "Book Borrwing";
            this.bookBorrowingBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bookBorrowingBtn.UseVisualStyleBackColor = true;
            this.bookBorrowingBtn.Click += new System.EventHandler(this.bookBorrowingBtn_Click);
            // 
            // btnManageFee
            // 
            this.btnManageFee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageFee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageFee.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnManageFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageFee.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageFee.Image = ((System.Drawing.Image)(resources.GetObject("btnManageFee.Image")));
            this.btnManageFee.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageFee.Location = new System.Drawing.Point(0, 222);
            this.btnManageFee.Name = "btnManageFee";
            this.btnManageFee.Size = new System.Drawing.Size(195, 41);
            this.btnManageFee.TabIndex = 6;
            this.btnManageFee.Text = "Manage Fee";
            this.btnManageFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageFee.UseVisualStyleBackColor = true;
            this.btnManageFee.Click += new System.EventHandler(this.btnManageFee_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageCustomers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnManageCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCustomers.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageCustomers.Image = ((System.Drawing.Image)(resources.GetObject("btnManageCustomers.Image")));
            this.btnManageCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageCustomers.Location = new System.Drawing.Point(0, 181);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(195, 41);
            this.btnManageCustomers.TabIndex = 5;
            this.btnManageCustomers.Text = "Manage Books";
            this.btnManageCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageCustomers.UseVisualStyleBackColor = true;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageUsers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Image")));
            this.btnManageUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageUsers.Location = new System.Drawing.Point(0, 140);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(195, 41);
            this.btnManageUsers.TabIndex = 4;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDashboard.Location = new System.Drawing.Point(0, 99);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(195, 41);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // IntroPanel
            // 
            this.IntroPanel.BackColor = System.Drawing.Color.Red;
            this.IntroPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IntroPanel.Controls.Add(this.avatarImg);
            this.IntroPanel.Controls.Add(this.lblUserPosition);
            this.IntroPanel.Controls.Add(this.lblUserName);
            this.IntroPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.IntroPanel.HorizontalScrollbarBarColor = true;
            this.IntroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.IntroPanel.HorizontalScrollbarSize = 10;
            this.IntroPanel.Location = new System.Drawing.Point(0, 0);
            this.IntroPanel.Name = "IntroPanel";
            this.IntroPanel.Size = new System.Drawing.Size(195, 99);
            this.IntroPanel.TabIndex = 2;
            this.IntroPanel.VerticalScrollbarBarColor = true;
            this.IntroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.IntroPanel.VerticalScrollbarSize = 10;
            // 
            // avatarImg
            // 
            this.avatarImg.BackColor = System.Drawing.Color.White;
            this.avatarImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("avatarImg.BackgroundImage")));
            this.avatarImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatarImg.InitialImage = null;
            this.avatarImg.Location = new System.Drawing.Point(11, 13);
            this.avatarImg.Name = "avatarImg";
            this.avatarImg.Size = new System.Drawing.Size(74, 72);
            this.avatarImg.TabIndex = 5;
            this.avatarImg.TabStop = false;
            // 
            // lblUserPosition
            // 
            this.lblUserPosition.AutoSize = true;
            this.lblUserPosition.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUserPosition.Location = new System.Drawing.Point(91, 69);
            this.lblUserPosition.Name = "lblUserPosition";
            this.lblUserPosition.Size = new System.Drawing.Size(54, 15);
            this.lblUserPosition.TabIndex = 4;
            this.lblUserPosition.Text = "Librariyan";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(91, 50);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(64, 19);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "John Doe";
            this.lblUserName.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // contextPanel
            // 
            this.contextPanel.HorizontalScrollbarBarColor = true;
            this.contextPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.contextPanel.HorizontalScrollbarSize = 10;
            this.contextPanel.Location = new System.Drawing.Point(221, 60);
            this.contextPanel.Name = "contextPanel";
            this.contextPanel.Size = new System.Drawing.Size(704, 481);
            this.contextPanel.TabIndex = 2;
            this.contextPanel.VerticalScrollbarBarColor = true;
            this.contextPanel.VerticalScrollbarHighlightOnWheel = false;
            this.contextPanel.VerticalScrollbarSize = 10;
            // 
            // Heading
            // 
            this.Heading.AutoSize = true;
            this.Heading.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Heading.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.Heading.Location = new System.Drawing.Point(20, 19);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(286, 25);
            this.Heading.TabIndex = 3;
            this.Heading.Text = "NIBM Library Management System";
            this.Heading.UseCustomForeColor = true;
            this.Heading.UseStyleColors = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(0, 768);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1922, 20);
            this.panel1.TabIndex = 9;
            // 
            // LibrariyanDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(935, 549);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Heading);
            this.Controls.Add(this.contextPanel);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.Name = "LibrariyanDashboard";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.metroPanel1.ResumeLayout(false);
            this.IntroPanel.ResumeLayout(false);
            this.IntroPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Button bookBorrowingBtn;
        private System.Windows.Forms.Button btnManageFee;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button logoutBtn;
        private MetroFramework.Controls.MetroLabel lblUserName;
        private MetroFramework.Controls.MetroLabel lblUserPosition;
        private MetroFramework.Controls.MetroPanel contextPanel;
        private MetroFramework.Controls.MetroPanel IntroPanel;
        private System.Windows.Forms.PictureBox avatarImg;
        private MetroFramework.Controls.MetroLabel Heading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LibrariyanProfileBtn;
    }
}