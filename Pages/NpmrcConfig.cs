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

            if (!saveIdentityService.IsValidField(textBoxCabecalho, "Cabeçalho") ||
         !saveIdentityService.IsValidField(textBoxUser, "Diretório do Usuário") ||
         !saveIdentityService.IsValidField(textBoxAdmin, "Diretório do Admin") ||
         !DirectoryExists(textBoxUser.Text, "Diretório do Usuário") ||
         !DirectoryExists(textBoxAdmin.Text, "Diretório do Admin") ||
         !saveIdentityService.IsValidField(richTextToken, "Token"))
            {
                return; // Retorna se algum campo não for válido
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

            // Define o título do diálogo
            folderBrowserDialog.Description = "Selecione uma pasta";

            // Configurações adicionais, se necessário
            // ...

            // Exibe o diálogo e verifica se o usuário clicou em "OK"
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // A pasta selecionada está em folderBrowserDialog.SelectedPath
                string pastaSelecionada = folderBrowserDialog.SelectedPath;

                // Faça algo com a pasta selecionada
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
                MessageBox.Show($"O {directoryName} não existe.");
                return false;
            }
            return true;
        }

        private void next_Click(object sender, EventArgs e)
        {
            ICreateRegistryKeys createRegistryKeys = new CreateRegistryKeysService();
            ISaveIdentityService saveIdentityService = new SaveIdentityService(createRegistryKeys);

            // Crie uma instância de ConfigIdentity, passando a instância de ISaveIdentityService.
            var form1 = new ConfigIdentity(saveIdentityService);

            // Esconda o formulário atual e mostre o novo formulário.
            this.Hide();
            form1.Show();
        }
    }
}
