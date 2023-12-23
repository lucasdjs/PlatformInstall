using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaformInstall.Interfaces
{
    public interface IValidateFiel
    {
        public bool IsValidField(Control control, string fieldName);
    }
}
