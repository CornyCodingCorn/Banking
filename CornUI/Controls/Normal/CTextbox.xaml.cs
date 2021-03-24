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

namespace CornUI.Controls.Normal
{
    /// <summary>
    /// Interaction logic for CTextbox.xaml
    /// </summary>
    public partial class CTextbox : CornControl
    {
        public CTextbox()
        {
            InitializeComponent();
        }

        protected void TextBlocKMouseDown(object sender, MouseEventArgs e)
        {
            textBox.Focus();
        }

        protected void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (textBlock.Text == "")
            {
                textBox.IsEnabled = true;
            }
            else
            {
                textBox.IsEnabled = false;
            }
        }
    }
}
