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
    /// Interaction logic for CTextbox.xaml
    /// </summary>
    public partial class CPasswordBox : CornControl
    {

        [Category("Brush")]
        public Brush DefaulTextBrush
        {
            get { return (Brush)GetValue(CTextbox.DefaultTextBrushProperty); }
            set { SetValue(CTextbox.DefaultTextBrushProperty, value); }
        }
        [Category("Text")]
        public string DefaultText
        {
            get { return (string)GetValue(CTextbox.DefaultTextProperty); }
            set { SetValue(CTextbox.DefaultTextProperty, value); }
        }
        [Category("Text")]
        public char PasswordChar
        {
            get { return (char)GetValue(PasswordBox.PasswordCharProperty); }
            set
            {
                SetValue(PasswordBox.PasswordCharProperty, value);
                RaisePropertyChanged("PasswordChar");
            }
        }
        public string Password
        {
            get { return textBox.Password; }
            set 
            { 
                textBox.Password = value;
                RaisePropertyChanged("Password");
            }
        }
        [Category("Text")]
        public Int32 MaxLength
        {
            get { return (Int32)GetValue(PasswordBox.MaxLengthProperty); }
            set
            {
                SetValue(PasswordBox.MaxLengthProperty, value);
                RaisePropertyChanged("MaxLength");
            }
        }

        public CPasswordBox()
        {
            InitializeComponent();
            this.PasswordChar = '●';
            textBox.GotFocus += ControlGotFocus;
            textBox.LostFocus += ControlLostFocus;
            textBox.PreviewKeyDown += CheckForEmpty;
        }

        protected void ControlMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                textBox.Focus();
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (IsMouseOver)
                return;

            CurrentBackColor = BackGround;
            if (!textBox.IsFocused)
            {
                CurrentBorderColor = Border;
            }
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            CurrentBackColor = BackGroundHover;
            if (!textBox.IsFocused)
            {
                CurrentBorderColor = BorderHover;
            }
        }
        protected void ControlGotFocus(object sender, EventArgs e)
        {
            CurrentBackColor = BackGroundPressed;
            CurrentBorderColor = BorderPressed;
        }
        protected void ControlLostFocus(object sender, EventArgs e)
        {
            if (IsMouseOver)
            {
                CurrentBackColor = BackGroundHover;
                CurrentBorderColor = BorderHover;
            }
            else
            {
                CurrentBackColor = BackGround;
                CurrentBorderColor = Border;
            }

            if (textBox.Password == "")
            {
                textBlock.Opacity = 1;
            }
        }

        protected void CheckForEmpty(object sender, KeyEventArgs e)
        {
            if (textBox.Password == "")
            {
                textBlock.Opacity = 0;
            }
        }
    }
}
