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
    public partial class CButton : CornControl
    {
        public double CornerRadius { get; set; }

        public CButton()
        {
            InitializeComponent();
            CurrentBorderColor = Border;
            CurrentBackColor = BackGround;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            MouseHover();
        }
        protected void MouseHover()
        {
            CurrentBackColor = BackGroundHover;
            if (!IsFocused)
            {
                CurrentBorderColor = BorderHover;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            CurrentBackColor = BackGround;
            if (!IsFocused)
            {
                CurrentBorderColor = Border;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            this.Focus();
            CurrentBackColor = BackGroundPressed;
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (IsMouseOver)
            {
                MouseHover();
            }
            else
            {
                CurrentBorderColor = Border;
            }
        }
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            CurrentBorderColor = BorderPressed;
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            CurrentBackColor = BackGround;
        }
    }
}
