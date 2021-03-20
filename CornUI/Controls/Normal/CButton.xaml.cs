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

namespace CornUI.Controls.Normal
{
    /// <summary>
    /// Interaction logic for CButton.xaml
    /// </summary>
    public partial class CButton : UserControl
    {
        public enum IconText
        {
            TextAfterIcon,
            IconAfterText
        }

        public Brush BackGround { get; set; }
        public Brush Border { get; set; }
        public Brush IconBrush { get; set; }
        public Image Icon { get; set; }
        public string Text { get; set; }
        IconText IconTextArrangement { get; set; }
        public double CornerRadius { get; set; }

        public CButton()
        {
            InitializeComponent();
        }
    }
}
