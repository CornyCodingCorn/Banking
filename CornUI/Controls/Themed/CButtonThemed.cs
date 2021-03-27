using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornUI.Controls.Themed
{
    public class CButtonThemed : CornUI.Controls.Normal.CButton
    {
        public CButtonThemed()
        {
            this.DataContext = CornUI.Model.Theme.GetInstance();
        }
    }
}
