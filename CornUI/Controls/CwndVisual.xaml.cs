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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace CornUI.Controls
{
    /// <summary>
    /// Interaction logic for CwndVisual.xaml
    /// </summary>
    public partial class Cwnd : Window
    {
        CwndInfo info;

        public Cwnd(CwndInfo info)
        {
            this.info = info;
            this.DataContext = this.info;
        }
        public override void OnApplyTemplate()
        {
            try
            {
                Button minimize = GetTemplateChild("minimizeButton") as Button;
                minimize.Click += MinimizeClick;

                Button maximize = GetTemplateChild("maximizeButton") as Button;
                maximize.Click += MaximizeClick;

                Button close = GetTemplateChild("closeButton") as Button;
                close.Click += CloseClick;

                Rectangle topBar1 = GetTemplateChild("topBar1") as Rectangle;
                topBar1.MouseDown += WindowDrag;

                Rectangle topBar2 = GetTemplateChild("topBar2") as Rectangle;
                topBar2.MouseDown += WindowDrag;

                Grid topBarTitle = GetTemplateChild("topBarTitle") as Grid;
                topBarTitle.MouseDown += WindowDrag;

                AssignMouseDownEvent();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("One of the system buttons is null");
            }

            base.OnApplyTemplate();
        }
        protected void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        #region Click event
        protected void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        protected void MaximizeClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }
        protected void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region Resize
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        protected void AssignMouseDownEvent()
        {
            Rectangle rect = GetTemplateChild("top") as Rectangle;
            rect.MouseDown += ResizeTop;

            rect = GetTemplateChild("bottom") as Rectangle;
            rect.MouseDown += ResizeBottom;

            rect = GetTemplateChild("left") as Rectangle;
            rect.MouseDown += ResizeLeft;

            rect = GetTemplateChild("right") as Rectangle;
            rect.MouseDown += ResizeRight;

            rect = GetTemplateChild("topLeft") as Rectangle;
            rect.MouseDown += ResizeTopLeft;

            rect = GetTemplateChild("topRight") as Rectangle;
            rect.MouseDown += ResizeTopRight;

            rect = GetTemplateChild("bottomLeft") as Rectangle;
            rect.MouseDown += ResizeGura;

            rect = GetTemplateChild("bottomRight") as Rectangle;
            rect.MouseDown += ResizeBottomRight;
        }

        protected void ResizeTop(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.Top);
        }
        protected void ResizeBottom(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.Bottom);
        }
        protected void ResizeLeft(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.Left);
        }
        protected void ResizeRight(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.Right);
        }
        protected void ResizeTopLeft(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.TopLeft);
        }
        protected void ResizeTopRight(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.TopRight);
        }
        protected void ResizeGura(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.Gura);
        }
        protected void ResizeBottomRight(object sender, MouseButtonEventArgs e)
        {
            ResizeWindow(ResizeDirection.BottomRight);
        }

        private void ResizeWindow(ResizeDirection direction)
        {
            SendMessage(_hwndSource.Handle, 0x112, (IntPtr)(61440 + direction), IntPtr.Zero);
        }

        private enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            Gura = 7,
            BottomRight = 8,
        }

        private HwndSource _hwndSource;

        protected override void OnInitialized(EventArgs e)
        {
            SourceInitialized += OnSourceInitialized;
            base.OnInitialized(e);
        }

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            _hwndSource = (HwndSource)PresentationSource.FromVisual(this);
        }
        #endregion
    }
}
