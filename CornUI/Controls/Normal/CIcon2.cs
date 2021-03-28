using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Shapes;

namespace CornUI.Controls.Normal
{
    /// <summary>
    /// Interaction logic for CIcon.xaml
    /// </summary>
    public class CIcon2 : UserControl
    {
        public static readonly DependencyProperty ClipImageProperty
    = DependencyProperty.Register("ClipImage", typeof(ImageSource), typeof(CIcon), null);
        public static readonly DependencyProperty ImageColorProperty
    = DependencyProperty.Register("ImageColor", typeof(Brush), typeof(CIcon), null);

        [Category("Cwnd")]
        public ImageSource ClipImage
        {
            get { return (ImageSource)GetValue(ClipImageProperty); }
            set { SetValue(ClipImageProperty, value); }
        }

        [Category("Cwnd")]
        public Brush ImageColor
        {
            get { return (Brush)GetValue(ImageColorProperty); }
            set { SetValue(ImageColorProperty, value); }
        }

        Rectangle rect;
        ImageBrush mask;

        public CIcon2()
        {
            rect = new Rectangle();
            mask = new ImageBrush();
            mask.Stretch = Stretch.Uniform;
        }
    }
}
