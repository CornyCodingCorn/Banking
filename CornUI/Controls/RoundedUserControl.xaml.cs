using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace CornUI.Controls
{
    /// <summary>
    /// Interaction logic for RoundedUserControl.xaml
    /// </summary>
    public partial class RoundedUserControl : INPCUserControl
    {
        #region Property
        [Category("CustomAppearance")]
        public double CornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = value; }
        }
        [Category("CustomAppearance")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }
        [Category("CustomAppearance")]
        public Color NormalColor
        {
            get { return normalColor; }
            set { normalColor = value; }
        }
        [Category("CustomAppearance")]
        public Color HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; }
        }
        #endregion

        double cornerRadius = 0;
        int borderWidth = 2;

        Color normalColor;
        Color hoverColor;
        Color focusColor;

        public RoundedUserControl()
        {
            InitializeComponent();
        }
    }
}
