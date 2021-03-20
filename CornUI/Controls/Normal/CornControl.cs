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
    public class CornControl : UserControl, INotifyPropertyChanged
    {
        #region
        public static readonly DependencyProperty BackGroundProperty
    = DependencyProperty.Register("BackGround", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.White));
        public static readonly DependencyProperty BorderProperty
    = DependencyProperty.Register("Border", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.Gray));
        public static readonly DependencyProperty BackGroundHoverProperty
    = DependencyProperty.Register("BackGroundHover", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.White));
        public static readonly DependencyProperty BorderHoverProperty
    = DependencyProperty.Register("BorderHover", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.SkyBlue));
        public static readonly DependencyProperty BackGroundPressedProperty
    = DependencyProperty.Register("BackGroundPressed", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.SkyBlue));
        public static readonly DependencyProperty BorderPressedProperty
    = DependencyProperty.Register("BorderPressed", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.DeepSkyBlue));

        public static readonly DependencyProperty IconMaskProperty
    = DependencyProperty.Register("IconMask", typeof(Image), typeof(CButton), new PropertyMetadata(null));
        public static readonly DependencyProperty IconBrushProperty
    = DependencyProperty.Register("IconBrush", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty TextProperty
    = DependencyProperty.Register("Text", typeof(string), typeof(CButton), new PropertyMetadata("template"));
        public static readonly DependencyProperty IconTextArrangementProperty
    = DependencyProperty.Register("IconTextArrangement", typeof(Arrangement), typeof(CButton), new PropertyMetadata(Arrangement.IconText));
        public static readonly DependencyProperty CornerRadiusProperty
    = DependencyProperty.Register("CornerRadius", typeof(double), typeof(CButton), new PropertyMetadata((double)0));
        public static readonly DependencyProperty CurrentBackColorProperty
    = DependencyProperty.Register("CurrentBackColor", typeof(Brush), typeof(CButton));
        public static readonly DependencyProperty CurrentBorderColorProperty
    = DependencyProperty.Register("CurrentBorderColor", typeof(Brush), typeof(CButton));

        public enum Arrangement
        {
            TextIcon,
            IconText,
            NoText,
            NoIcon
        }

        [Category("_Cwnd")]
        public Brush BackGround
        {
            get { return (Brush)GetValue(BackGroundProperty); }
            set { SetValue(BackGroundProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush Border
        {
            get { return (Brush)GetValue(BorderProperty); }
            set { SetValue(BorderProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush BackGroundHover
        {
            get { return (Brush)GetValue(BackGroundHoverProperty); }
            set { SetValue(BackGroundHoverProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush BorderHover
        {
            get { return (Brush)GetValue(BorderHoverProperty); }
            set { SetValue(BorderHoverProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush BackGroundPressed
        {
            get { return (Brush)GetValue(BackGroundPressedProperty); }
            set { SetValue(BackGroundPressedProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush BorderPressed
        {
            get { return (Brush)GetValue(BorderPressedProperty); }
            set { SetValue(BorderPressedProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush IconBrush
        {
            get { return (Brush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }
        [Category("_Cwnd")]
        public Image Icon
        {
            get { return (Image)GetValue(IconMaskProperty); }
            set { SetValue(IconMaskProperty, value); }
        }
        [Category("_Cwnd")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        [Category("_Cwnd")]
        Arrangement IconTextArrangement
        {
            get { return (Arrangement)GetValue(IconTextArrangementProperty); }
            set { SetValue(IconTextArrangementProperty, value); }
        }
        [Category("_Cwnd")]
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush CurrentBackColor
        {
            get { return (Brush)GetValue(CurrentBackColorProperty); }
            set { SetValue(CurrentBackColorProperty, value); }
        }
        [Category("_Cwnd")]
        public Brush CurrentBorderColor
        {
            get { return (Brush)GetValue(CurrentBorderColorProperty); }
            set { SetValue(CurrentBorderColorProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
