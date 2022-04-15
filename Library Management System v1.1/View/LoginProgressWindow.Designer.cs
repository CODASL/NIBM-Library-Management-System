
namespace Library_Management_System_v1._1.View
{
    partial class LoginProgressWindow
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
            this.loadProgress = new MaterialSkin.Controls.MaterialProgressBar();
            this.LoginBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // loadProgress
            // 
            this.loadProgress.Depth = 0;
            this.loadProgress.Location = new System.Drawing.Point(30, 317);
            this.loadProgress.MouseState = MaterialSkin.MouseState.HOVER;
            this.loadProgress.Name = "loadProgress";
            this.loadProgress.Size = new System.Drawing.Size(274, 5);
            this.loadProgress.TabIndex = 0;
            // 
            // LoginBackgroundWorker
            // 
            this.LoginBackgroundWorker.WorkerReportsProgress = true;
            this.LoginBackgroundWorker.WorkerSupportsCancellation = true;
            this.LoginBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoginBackgroundWorker_DoWork);
            this.LoginBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoginBackgroundWorker_ProgressChanged);
            this.LoginBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoginBackgroundWorker_RunWorkerCompleted);
            // 
            // LoginProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 390);
            this.Controls.Add(this.loadProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginProgressWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoginProgressWindow";
            this.Load += new System.EventHandler(this.LoginProgressWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialProgressBar loadProgress;
        private System.ComponentModel.BackgroundWorker LoginBackgroundWorker;
    }
}