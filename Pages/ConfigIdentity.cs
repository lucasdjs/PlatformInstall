using PlaformInstall.Interfaces;
using PlaformInstall.Services;
using PlatformInstall.Domain.Identity;
using PlatformInstall.Pages;

namespace PlatformInstall
{
    public partial class ConfigIdentity : Form
    {
        private readonly ISaveIdentityService _saveIdentityService;

        public ConfigIdentity()
        {
        }

        public ConfigIdentity(ISaveIdentityService saveIdentityService)
        {
            InitializeComponent();
            _saveIdentityService = saveIdentityService;
        }

        private void SalvarConfig_Click(object sender, EventArgs e)
        {

            IValidateFiel saveIdentityService = new ValidateField();

            if (!saveIdentityService.IsValidField(clientIdBack, "ClientId Back") ||
         !saveIdentityService.IsValidField(SecretKeyBack, "SecretKey Back") ||
         !saveIdentityService.IsValidField(clientIdFrontTextBox, "ClientId Front") ||
         !saveIdentityService.IsValidField(userSDKClientIDTextBox, "userSDK ClientId") ||
         !saveIdentityService.IsValidField(clientSecrectUserSDK, "userSDK ClientSecrect") || 
         !saveIdentityService.IsValidField(idUser, "UserId") ||
         !saveIdentityService.IsValidField(userName, "userName") ||
         !saveIdentityService.IsValidField(email, "email")
         )
            {
                return; // Retorna se algum campo não for válido
            }

            var userBack = new User(clientIdBack.Text, SecretKeyBack.Text);
            var userFront = new User(clientIdFrontTextBox.Text, secretKeyFront.Text);
            var userSDK = new User(userSDKClientIDTextBox.Text, clientSecrectUserSDK.Text);
            var dataDatabase = new DataDatabase(idUser.Text, userName.Text, email.Text);

            var dataIdentity = new DataIdentity(dataDatabase, userBack, userFront, userSDK);
            _saveIdentityService.Process(dataIdentity);

            var form1 = new Install(dataIdentity);

            this.Close();
            form1.Show();
        }
    }
}
