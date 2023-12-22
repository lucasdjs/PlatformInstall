namespace PlatformInstall
{
    partial class NpmrcConfig
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelCabecalho = new Label();
            labelToken = new Label();
            label3 = new Label();
            salvar = new Button();
            textBoxCabecalho = new TextBox();
            richTextToken = new RichTextBox();
            label1 = new Label();
            textBoxUser = new TextBox();
            buttonUser = new Button();
            buttonAdmin = new Button();
            textBoxAdmin = new TextBox();
            label2 = new Label();
            folderBrowserDialogUser = new FolderBrowserDialog();
            folderBrowserDialogAdmin = new FolderBrowserDialog();
            next = new Button();
            SuspendLayout();
            // 
            // labelCabecalho
            // 
            labelCabecalho.AutoSize = true;
            labelCabecalho.Location = new Point(15, 167);
            labelCabecalho.Margin = new Padding(4, 0, 4, 0);
            labelCabecalho.Name = "labelCabecalho";
            labelCabecalho.Size = new Size(136, 17);
            labelCabecalho.TabIndex = 0;
            labelCabecalho.Text = "Cabeçalho .npmrc:";
            labelCabecalho.Click += LabelCabecalho;
            // 
            // labelToken
            // 
            labelToken.AutoSize = true;
            labelToken.Location = new Point(21, 211);
            labelToken.Margin = new Padding(4, 0, 4, 0);
            labelToken.Name = "labelToken";
            labelToken.Size = new Size(49, 17);
            labelToken.TabIndex = 3;
            labelToken.Text = "Token:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 33);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 26);
            label3.TabIndex = 4;
            label3.Text = "Criar NPMRC";
            label3.Click += label3_Click;
            // 
            // salvar
            // 
            salvar.Location = new Point(157, 550);
            salvar.Margin = new Padding(4, 3, 4, 3);
            salvar.Name = "salvar";
            salvar.Size = new Size(151, 26);
            salvar.TabIndex = 5;
            salvar.Text = "Salvar";
            salvar.UseVisualStyleBackColor = true;
            salvar.Click += ButtonSalvar;
            // 
            // textBoxCabecalho
            // 
            textBoxCabecalho.Location = new Point(158, 164);
            textBoxCabecalho.Name = "textBoxCabecalho";
            textBoxCabecalho.Size = new Size(450, 23);
            textBoxCabecalho.TabIndex = 6;
            textBoxCabecalho.TextChanged += cabecalhoText;
            // 
            // richTextToken
            // 
            richTextToken.Location = new Point(164, 211);
            richTextToken.Name = "richTextToken";
            richTextToken.Size = new Size(450, 279);
            richTextToken.TabIndex = 7;
            richTextToken.Text = "";
            richTextToken.TextChanged += tokenText;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 75);
            label1.Name = "label1";
            label1.Size = new Size(123, 17);
            label1.TabIndex = 8;
            label1.Text = "Caminho usuário:";
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(143, 75);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(365, 23);
            textBoxUser.TabIndex = 9;
            textBoxUser.TextChanged += textBoxUser_TextChanged;
            // 
            // buttonUser
            // 
            buttonUser.Location = new Point(495, 75);
            buttonUser.Name = "buttonUser";
            buttonUser.Size = new Size(75, 23);
            buttonUser.TabIndex = 10;
            buttonUser.Text = "buscar...";
            buttonUser.UseVisualStyleBackColor = true;
            buttonUser.Click += buttonUser_Click;
            // 
            // buttonAdmin
            // 
            buttonAdmin.Location = new Point(539, 114);
            buttonAdmin.Name = "buttonAdmin";
            buttonAdmin.Size = new Size(75, 23);
            buttonAdmin.TabIndex = 13;
            buttonAdmin.Text = "buscar...";
            buttonAdmin.UseVisualStyleBackColor = true;
            buttonAdmin.Click += buttonAdmin_Click;
            // 
            // textBoxAdmin
            // 
            textBoxAdmin.Location = new Point(187, 114);
            textBoxAdmin.Name = "textBoxAdmin";
            textBoxAdmin.Size = new Size(365, 23);
            textBoxAdmin.TabIndex = 12;
            textBoxAdmin.TextChanged += textBoxAdmin_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 117);
            label2.Name = "label2";
            label2.Size = new Size(167, 17);
            label2.TabIndex = 11;
            label2.Text = "Caminho administrador:";
            // 
            // next
            // 
            next.Location = new Point(493, 550);
            next.Name = "next";
            next.Size = new Size(113, 26);
            next.TabIndex = 14;
            next.Text = "Próximo";
            next.UseVisualStyleBackColor = true;
            next.Click += next_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuBar;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(683, 588);
            Controls.Add(next);
            Controls.Add(buttonAdmin);
            Controls.Add(textBoxAdmin);
            Controls.Add(label2);
            Controls.Add(buttonUser);
            Controls.Add(textBoxUser);
            Controls.Add(label1);
            Controls.Add(richTextToken);
            Controls.Add(textBoxCabecalho);
            Controls.Add(salvar);
            Controls.Add(label3);
            Controls.Add(labelToken);
            Controls.Add(labelCabecalho);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Instalação Platform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCabecalho;
        private Label labelToken;
        private Label label3;
        private Button salvar;
        private TextBox textBoxCabecalho;
        private RichTextBox richTextToken;
        private Label label1;
        private TextBox textBoxUser;
        private Button buttonUser;
        private Button buttonAdmin;
        private TextBox textBoxAdmin;
        private Label label2;
        private FolderBrowserDialog folderBrowserDialogUser;
        private FolderBrowserDialog folderBrowserDialogAdmin;
        private Button next;
    }
}
