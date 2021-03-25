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
    public partial class CTextbox : CornControl
    {
        public static readonly DependencyProperty DefaultTextProperty
    = DependencyProperty.Register("DefaultText", typeof(string), typeof(CButton), new PropertyMetadata("Type"));
        public static readonly DependencyProperty DefaultTextBrushProperty
    = DependencyProperty.Register("DefaultTextBrush", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.DarkGray));

        [Category("Brush")]
        public Brush DefaulTextBrush
        {
            get { return (Brush)GetValue(DefaultTextBrushProperty); }
            set { SetValue(DefaultTextBrushProperty, value); }
        }
        [Category("Text")]
        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(TextProperty, value); }
        }
        [Category("Text")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set 
            { 
                SetValue(TextProperty, value);
                if (textBlock != null)
                {
                    if (Text == "")
                    {
                        textBlock.Opacity = 1;
                    }
                    else
                    {
                        textBlock.Opacity = 0;
                    }
                }
                RaisePropertyChanged("Text");
            }
        }

        public CTextbox()
        {
            InitializeComponent();
            textBox.GotFocus += ControlGotFocus;
            textBox.LostFocus += ControlLostFocus;
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
        }
    }
}
