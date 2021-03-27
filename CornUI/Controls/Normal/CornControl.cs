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
    = DependencyProperty.Register("BorderPressed", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.Blue));

        public static readonly DependencyProperty ShadowDirectionProperty
    = DependencyProperty.Register("ShadowDirection", typeof(double), typeof(CButton), new PropertyMetadata((double)270));
        public static readonly DependencyProperty ShadowOpacityProperty
    = DependencyProperty.Register("ShadowOpacity", typeof(double), typeof(CButton), new PropertyMetadata((double)0.75));
        public static readonly DependencyProperty ShadowThicknessProperty
    = DependencyProperty.Register("ShadowThickness", typeof(double), typeof(CButton), new PropertyMetadata((double)5));

        public static readonly DependencyProperty IconMaskProperty
    = DependencyProperty.Register("IconMask", typeof(ImageSource), typeof(CButton), new PropertyMetadata(null));
        public static readonly DependencyProperty IconBrushProperty
    = DependencyProperty.Register("IconBrush", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty IconSizeProperty
    = DependencyProperty.Register("IconSize", typeof(double), typeof(CButton), new PropertyMetadata((double) 20));
    
        public static readonly DependencyProperty TextProperty
    = DependencyProperty.Register("Text", typeof(string), typeof(CButton), new PropertyMetadata(""));
        public static readonly DependencyProperty IconTextArrangementProperty
    = DependencyProperty.Register("IconTextArrangement", typeof(Arrangement), typeof(CButton), new PropertyMetadata(Arrangement.IconRight));
        public static readonly DependencyProperty CornerRadiusProperty
    = DependencyProperty.Register("CornerRadius", typeof(double), typeof(CButton), new PropertyMetadata((double)0));
        public static readonly DependencyProperty CurrentBackColorProperty
    = DependencyProperty.Register("CurrentBackColor", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.White));
        public static readonly DependencyProperty CurrentBorderColorProperty
    = DependencyProperty.Register("CurrentBorderColor", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty IsMouseDownProperty
    = DependencyProperty.Register("IsMouseDown", typeof(bool), typeof(CButton));

        static CornControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CornControl),
                new FrameworkPropertyMetadata(typeof(CornControl)));
        }

        public enum Arrangement
        {
            IconTop,
            IconBottom,
            IconLeft,
            IconRight,
            NoText,
            NoIcon
        }

        [Category("Brush")]
        public Brush BackGround
        {
            get { return (Brush)GetValue(BackGroundProperty); }
            set { SetValue(BackGroundProperty, value); }
        }
        [Category("Brush")]
        public Brush Border
        {
            get { return (Brush)GetValue(BorderProperty); }
            set { SetValue(BorderProperty, value); }
        }
        [Category("Brush")]
        public Brush BackGroundHover
        {
            get { return (Brush)GetValue(BackGroundHoverProperty); }
            set { SetValue(BackGroundHoverProperty, value); }
        }
        [Category("Brush")]
        public Brush BorderHover
        {
            get { return (Brush)GetValue(BorderHoverProperty); }
            set { SetValue(BorderHoverProperty, value); }
        }
        [Category("Brush")]
        public Brush BackGroundPressed
        {
            get { return (Brush)GetValue(BackGroundPressedProperty); }
            set { SetValue(BackGroundPressedProperty, value); }
        }
        [Category("Brush")]
        public Brush BorderPressed
        {
            get { return (Brush)GetValue(BorderPressedProperty); }
            set { SetValue(BorderPressedProperty, value); }
        }

        [Category("Shadow")]
        public double ShadowDirection
        {
            get { return (double)GetValue(ShadowDirectionProperty); }
            set { SetValue(ShadowDirectionProperty, value); }
        }
        [Category("Shadow")]
        public double ShadowOpacity
        {
            get { return (double)GetValue(ShadowOpacityProperty); }
            set { SetValue(ShadowOpacityProperty, value); }
        }
        [Category("Shadow")]
        public double ShadowThickness
        {
            get { return (double)GetValue(ShadowThicknessProperty); }
            set { SetValue(ShadowThicknessProperty, value); }
        }

        [Category("Brush")]
        public Brush IconBrush
        {
            get { return (Brush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }
        [Category("Appearance")]
        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }
        [Category("Appearance")]
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconMaskProperty); }
            set { SetValue(IconMaskProperty, value); }
        }

        [Category("Appearance")]
        Arrangement IconTextArrangement
        {
            get { return (Arrangement)GetValue(IconTextArrangementProperty); }
            set { SetValue(IconTextArrangementProperty, value); }
        }
        [Category("Appearance")]
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
            set 
            { 
                SetValue(CurrentBorderColorProperty, value);
                RaisePropertyChanged("CurrentBorderColor");
            }
        }

        public CornControl() : base()
        {
            CurrentBorderColor = Border;
            CurrentBackColor = BackGround;
        }

        public bool IsMouseDown
        {
            get { return (bool)GetValue(IsMouseDownProperty); }
            set { SetValue(IsMouseDownProperty, value); }
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
