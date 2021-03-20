using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CornUI.Model;

namespace CornUI.Controls
{
    public partial class ThemedCwnd : Cwnd
    {
        Theme theme;

        public ThemedCwnd() : base(Theme.GetInstance().WindowInfo)
        {
            this.theme = Theme.GetInstance();
        }
    }
}
