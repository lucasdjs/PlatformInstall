using PlaformInstall.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaformInstall.Services
{
    public class ValidateField : IValidateFiel
    {
        public ValidateField() { }
        public bool IsValidField(Control control, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                MessageBox.Show($"O campo {fieldName} é obrigatório.");
                return false;
            }
            return true;
        }
    }
}
