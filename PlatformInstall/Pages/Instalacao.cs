using PlaformInstall.Interfaces;
using PlaformInstall.Services;
using PlatformInstall.Domain.Identity;
using System;
using System.Windows.Forms;

namespace PlaformInstall.Pages
{
    public partial class Instalacao : Form
    {
        DataIdentity _identity;
        public Instalacao(DataIdentity dataIdentity)
        {
            _identity = dataIdentity;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Finish = new Button();
            searchFolder = new Button();
            textBoxUser = new TextBox();
            labelPaste = new Label();
            progressBar1 = new ProgressBar();
            folderBrowserDialog1 = new FolderBrowserDialog();
            buttonInstall = new Button();
            logProgress = new RichTextBox();
            SuspendLayout();
            // 
            // Finish
            // 
            Finish.Enabled = false;
            Finish.Location = new Point(597, 428);
            Finish.Name = "Finish";
            Finish.Size = new Size(165, 23);
            Finish.TabIndex = 2;
            Finish.Text = "Finish";
            Finish.UseVisualStyleBackColor = true;
            Finish.Click += Finish_Click;
            // 
            // searchFolder
            // 
            searchFolder.Location = new Point(552, 62);
            searchFolder.Name = "searchFolder";
            searchFolder.Size = new Size(63, 23);
            searchFolder.TabIndex = 12;
            searchFolder.Text = "Buscar...";
            searchFolder.UseVisualStyleBackColor = true;
            searchFolder.Click += searchFolder_Click;
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(134, 62);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(481, 23);
            textBoxUser.TabIndex = 11;
            // 
            // labelPaste
            // 
            labelPaste.AutoSize = true;
            labelPaste.Location = new Point(134, 44);
            labelPaste.Name = "labelPaste";
            labelPaste.Size = new Size(240, 15);
            labelPaste.TabIndex = 13;
            labelPaste.Text = "Selecione a pasta para instalação do projeto:";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(132, 428);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(549, 23);
            progressBar1.TabIndex = 1;
            // 
            // button1
            // 
            buttonInstall.Location = new Point(621, 62);
            buttonInstall.Name = "buttonInstall";
            buttonInstall.Size = new Size(143, 23);
            buttonInstall.TabIndex = 14;
            buttonInstall.Text = "Instalar";
            buttonInstall.Enabled = false;
            buttonInstall.UseVisualStyleBackColor = true;
            buttonInstall.Click += button1_Click;
            // 
            // logProgress
            // 
            logProgress.Location = new Point(134, 120);
            logProgress.Name = "logProgress";
            logProgress.Size = new Size(630, 302);
            logProgress.TabIndex = 0;
            logProgress.Text = "";
            // 
            // Instalacao
            // 
            ClientSize = new Size(809, 521);
            Controls.Add(buttonInstall);
            Controls.Add(labelPaste);
            Controls.Add(searchFolder);
            Controls.Add(textBoxUser);
            Controls.Add(Finish);
            Controls.Add(progressBar1);
            Controls.Add(logProgress);
            Name = "Instalacao";
            ResumeLayout(false);
            PerformLayout();
        }

        private void searchFolder_Click(object? sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var pathUser = folderBrowserDialog1.SelectedPath;
                textBoxUser.Text = pathUser;
                buttonInstall.Enabled = true;
            }
        }

        private Button Finish;

        private void Finish_Click(object sender, EventArgs e)
        {

        }

        private void Install()
        {
            IScriptCommandService script = new ScriptCommandService(_identity, logProgress);
            script.Execute(textBoxUser.Text);
        }

        private Button searchFolder;
        private TextBox textBoxUser;
        private Label labelPaste;
        private ProgressBar progressBar1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonInstall;
        private RichTextBox logProgress;

        private void button1_Click(object sender, EventArgs e)
        {
            Install();
        }
    }
}
