
namespace PlatformInstall
{
    partial class Inicio
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
            fileSystemWatcher1 = new FileSystemWatcher();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(165, 172);
            label1.Name = "label1";
            label1.Size = new Size(259, 22);
            label1.TabIndex = 0;
            label1.Text = "Instalação do NDDPlatform";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(165, 242);
            label2.Name = "label2";
            label2.Size = new Size(302, 15);
            label2.TabIndex = 1;
            label2.Text = "Lembrete: Conectar a VPN para realização da instalação ";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Location = new Point(111, 324);
            button1.Name = "button1";
            button1.Size = new Size(399, 56);
            button1.TabIndex = 2;
            button1.Text = "Começar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Comecar;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 549);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Inicio";
            Text = "Form2";
            Load += Inicio_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Comecar(object sender, EventArgs e)
        {
            var form1 = new NpmrcConfig();
            this.Hide();
            form1.Show();
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private Label label1;
        private Button button1;
        private Label label2;
    }
}