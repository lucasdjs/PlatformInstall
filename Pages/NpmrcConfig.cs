using PlaformInstall.Interfaces;
using PlaformInstall.Services;
using PlatformInstall.Interfaces;
using PlatformInstall.Services;

namespace PlatformInstall
{
    public partial class NpmrcConfig : Form
    {
        public NpmrcConfig()
        {
            InitializeComponent();
        }

        public void LabelCabecalho(object sender, EventArgs e)
        {

        }

        public void ButtonSalvar(object sender, EventArgs e)
        {
            IValidateFiel saveIdentityService = new ValidateField();

            if (!saveIdentityService.IsValidField(textBoxCabecalho, "Cabe�alho") ||
         !saveIdentityService.IsValidField(textBoxUser, "Diret�rio do Usu�rio") ||
         !saveIdentityService.IsValidField(textBoxAdmin, "Diret�rio do Admin") ||
         !DirectoryExists(textBoxUser.Text, "Diret�rio do Usu�rio") ||
         !DirectoryExists(textBoxAdmin.Text, "Diret�rio do Admin") ||
         !saveIdentityService.IsValidField(richTextToken, "Token"))
            {
                return; // Retorna se algum campo n�o for v�lido
            }

            string cabecalho = textBoxCabecalho.Text;
            string token = richTextToken.Text;

            string fileName = ".npmrc";

            string filePathUser = Path.Combine(textBoxUser.Text, fileName);
            string filePathAdmin = Path.Combine(textBoxAdmin.Text, fileName);

            try
            {
                // Escreva os dados no arquivo
                using (StreamWriter writer = new StreamWriter(filePathUser))
                {
                    writer.WriteLine(cabecalho);
                    writer.WriteLine(token);
                }

                using (StreamWriter writer = new StreamWriter(filePathAdmin))
                {
                    writer.WriteLine(cabecalho);
                    writer.WriteLine(token);
                }

                MessageBox.Show("Dados salvos com sucesso!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void cabecalhoText(object sender, EventArgs e)
        {

        }

        public void tokenText(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Define o t�tulo do di�logo
            folderBrowserDialog.Description = "Selecione uma pasta";

            // Configura��es adicionais, se necess�rio
            // ...

            // Exibe o di�logo e verifica se o usu�rio clicou em "OK"
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // A pasta selecionada est� em folderBrowserDialog.SelectedPath
                string pastaSelecionada = folderBrowserDialog.SelectedPath;

                // Fa�a algo com a pasta selecionada
                MessageBox.Show("Pasta selecionada: " + pastaSelecionada);
            }
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogUser.ShowDialog() == DialogResult.OK)
            {
                var pathUser = folderBrowserDialogUser.SelectedPath;
                textBoxUser.Text = pathUser;
            }

        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogAdmin.ShowDialog() == DialogResult.OK)
            {
                var pathAdmin = folderBrowserDialogAdmin.SelectedPath;
                textBoxAdmin.Text = pathAdmin;
            }
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool DirectoryExists(string path, string directoryName)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show($"O {directoryName} n�o existe.");
                return false;
            }
            return true;
        }

        private void next_Click(object sender, EventArgs e)
        {
            ICreateRegistryKeys createRegistryKeys = new CreateRegistryKeysService();
            ISaveIdentityService saveIdentityService = new SaveIdentityService(createRegistryKeys);

            // Crie uma inst�ncia de ConfigIdentity, passando a inst�ncia de ISaveIdentityService.
            var form1 = new ConfigIdentity(saveIdentityService);

            // Esconda o formul�rio atual e mostre o novo formul�rio.
            this.Hide();
            form1.Show();
        }
    }
}
