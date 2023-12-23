namespace PlatformInstall.Pages
{
    partial class Install
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
            buttonInstall = new Button();
            labelPaste = new Label();
            searchFolder = new Button();
            textBoxUser = new TextBox();
            Finish = new Button();
            logProgress = new RichTextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // buttonInstall
            // 
            buttonInstall.Enabled = false;
            buttonInstall.Location = new Point(557, 40);
            buttonInstall.Name = "buttonInstall";
            buttonInstall.Size = new Size(143, 23);
            buttonInstall.TabIndex = 21;
            buttonInstall.Text = "Instalar";
            buttonInstall.UseVisualStyleBackColor = true;
            buttonInstall.Click += buttonInstall_Click;
            // 
            // labelPaste
            // 
            labelPaste.AutoSize = true;
            labelPaste.Location = new Point(70, 22);
            labelPaste.Name = "labelPaste";
            labelPaste.Size = new Size(240, 15);
            labelPaste.TabIndex = 20;
            labelPaste.Text = "Selecione a pasta para instalação do projeto:";
            // 
            // searchFolder
            // 
            searchFolder.Location = new Point(488, 40);
            searchFolder.Name = "searchFolder";
            searchFolder.Size = new Size(63, 23);
            searchFolder.TabIndex = 19;
            searchFolder.Text = "Buscar...";
            searchFolder.UseVisualStyleBackColor = true;
            searchFolder.Click += searchFolder_Click;
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(70, 40);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(481, 23);
            textBoxUser.TabIndex = 18;
            // 
            // Finish
            // 
            Finish.Enabled = false;
            Finish.Location = new Point(623, 406);
            Finish.Name = "Finish";
            Finish.Size = new Size(110, 23);
            Finish.TabIndex = 17;
            Finish.Text = "Finish";
            Finish.UseVisualStyleBackColor = true;
            // 
            // logProgress
            // 
            logProgress.Location = new Point(70, 98);
            logProgress.Name = "logProgress";
            logProgress.Size = new Size(630, 302);
            logProgress.TabIndex = 15;
            logProgress.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 22;
            // 
            // Install
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonInstall);
            Controls.Add(labelPaste);
            Controls.Add(searchFolder);
            Controls.Add(textBoxUser);
            Controls.Add(Finish);
            Controls.Add(progressBar1);
            Controls.Add(logProgress);
            Name = "Install";
            Text = "Install";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonInstall;
        private Label labelPaste;
        private Button searchFolder;
        private TextBox textBoxUser;
        private Button Finish;
        private RichTextBox logProgress;
        private FolderBrowserDialog folderBrowserDialog1;
        private ProgressBar progressBar1;
    }
}