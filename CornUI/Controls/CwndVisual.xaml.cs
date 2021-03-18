using System;
using System.IO;
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
using System.ComponentModel;

namespace CornUI.Controls
{
    /// <summary>
    /// Interaction logic for CwndVisual.xaml
    /// </summary>
    public partial class Cwnd : Window, INotifyPropertyChanged
    {
        #region Property
        public bool AllowResize
        {
            get { return allowResize; }
            set 
            { 
                if (allowResize == !value)
                {
                    allowResize = value;

                    if (allowResize)
                    {
                        EnableResize();
                    }
                    else
                    {
                        DisableResize();
                    }

                    RaisePropertyChanged("AllowResize");
                }
            }
        }
        public double BorderWidth
        {
            get 
            {
                if (state == WindowState.Maximized)
                {
                    return 0;
                }

                return info.BorderWidth;
            }
            set { info.BorderWidth = value; }
        }
        public double BorderRoundEdgeRadius
        {
            get { return info.BorderWidth + info.RoundEdgeRadius; }
            set { }
        }
        public int TopBarHeight
        {
            get { return info.TopBarHeight; }
            set { info.TopBarHeight = value; }
        }
        public Brush TopBarColor
        {
            get { return info.TopBarColor; }
            set { info.TopBarColor = value; }
        }
        public Brush BackColor
        {
            get { return info.BackColor; }
            set { info.BackColor = value; }
        }
        public double RoundEdgeRadius
        {
            get 
            { 
                if (state == WindowState.Maximized)
                {
                    return 0;
                }

                return info.RoundEdgeRadius; 
            }
            set { info.RoundEdgeRadius = value; }
        }
        public int ResizeRectSizeCorner
        {
            get { return info.ResizeRectSizeCorner; }
            set { info.ResizeRectSizeCorner = value; }
        }
        public int ResizeRectSizeMiddle
        {
            get { return info.ResizeRectSizeMiddle; }
            set { info.ResizeRectSizeMiddle = value; }
        }
        public double ResizeBorderWidth
        {
            get { return info.BorderWidth - info.ResizeRectSizeMiddle; }
            set { }
        }
        public string CwndTitle
        {
            get { return title; }
            set 
            { 
                title = value;
                RaisePropertyChanged("CwndTitle");
            }
        }
        public FontFamily CwndFontType
        {
            get { return info.CwndFontType; }
            set { info.CwndFontType = value; }
        }
        public FontWeight CwndFontWeight
        {
            get { return info.CwndFontWeight; }
            set { info.CwndFontWeight = value; }
        }
        public Brush CwndFontColor
        {
            get { return info.CwndFontColor; }
            set { info.CwndFontColor = value; }
        }
        public int CwndFontSize
        {
            get { return info.CwndFontSize; }
            set { info.CwndFontSize = value; }
        }
        public string IconPath
        {
            get { return iconPath; }
            set 
            { 
                iconPath = value;
                RaisePropertyChanged("IconPath");
            }
        }
        public int IconSize
        {
            get { return info.IconSize; }
            set { info.IconSize = value; }
        }

        public WindowState CwndWindowState
        {
            get { return state; }
            set 
            { 
                state = value;
                if (state != WindowState.Minimized)
                {
                    RaisePropertyChanged("BorderWidth");
                    RaisePropertyChanged("RoundEdgeRadius");

                    if (state == WindowState.Maximized)
                    {
                        DisableResize();
                    }
                    else
                    {
                        EnableResize();
                    }
                }
            }
        }

        #endregion
        protected bool restoreIfMove = false;
        protected WindowState state = WindowState.Normal;
        protected string title = "yeah";
        protected string iconPath = "Icon.png";
        protected bool allowResize = true;
        protected CwndInfo info;
        protected List<Rectangle> resizeRects = new List<Rectangle>();

        public Cwnd(CwndInfo info)
        {
            info.Register(this);
            this.info = info;
            this.DataContext = this;
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

                //Rectangle topBar1 = GetTemplateChild("topBar1") as Rectangle;
                //topBar1.MouseDown += StartWindowDrag;
                //topBar1.MouseDown += WindowDrag;
                //topBar1.MouseDown += EndWindowDrag;
                //
                //Rectangle topBar2 = GetTemplateChild("topBar2") as Rectangle;
                //topBar2.MouseDown += StartWindowDrag;
                //topBar2.MouseDown += WindowDrag;
                //topBar2.MouseDown += EndWindowDrag;
                //
                //Grid topBarTitle = GetTemplateChild("topBarTitle") as Grid;
                //topBarTitle.MouseDown += StartWindowDrag;
                //topBarTitle.MouseDown += WindowDrag;
                //topBarTitle.MouseDown += EndWindowDrag;

                AssignMouseDownEvent();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("One of the system buttons is null");
            }

            base.OnApplyTemplate();
        }
        protected void StartWindowDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if ((ResizeMode == ResizeMode.CanResize) ||
                    (ResizeMode == ResizeMode.CanResizeWithGrip))
                {
                    SwitchState();
                }
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    restoreIfMove = true;
                }

                DragMove();
            }
        }
        protected void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            if (restoreIfMove)
            {
                restoreIfMove = false;
                var mouseX = e.GetPosition(this).X;
                var width = RestoreBounds.Width;
                var x = mouseX - width / 2;

                if (x < 0)
                {
                    x = 0;
                }
                else
                if (x + width > System.Windows.SystemParameters.WorkArea.Width)
                {
                    x = System.Windows.SystemParameters.WorkArea.Width - width;
                }

                WindowState = WindowState.Normal;
                Left = x;
                Top = 0;
                DragMove();
            }
        }
        protected void EndWindowDrag(object sender, MouseButtonEventArgs e)
        {
            restoreIfMove = false;
        }
        private void SwitchState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    {
                        WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized:
                    {
                        WindowState = WindowState.Normal;
                        break;
                    }
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
            resizeRects.Add(rect);

            rect = GetTemplateChild("bottom") as Rectangle;
            rect.MouseDown += ResizeBottom;
            resizeRects.Add(rect);

            rect = GetTemplateChild("left") as Rectangle;
            rect.MouseDown += ResizeLeft;
            resizeRects.Add(rect);

            rect = GetTemplateChild("right") as Rectangle;
            rect.MouseDown += ResizeRight;
            resizeRects.Add(rect);

            rect = GetTemplateChild("topLeft") as Rectangle;
            rect.MouseDown += ResizeTopLeft;
            resizeRects.Add(rect);

            rect = GetTemplateChild("topRight") as Rectangle;
            rect.MouseDown += ResizeTopRight;
            resizeRects.Add(rect);

            rect = GetTemplateChild("bottomLeft") as Rectangle;
            rect.MouseDown += ResizeGura;
            resizeRects.Add(rect);

            rect = GetTemplateChild("bottomRight") as Rectangle;
            rect.MouseDown += ResizeBottomRight;
            resizeRects.Add(rect);
        }
        protected void DisableResize()
        {
            foreach (Rectangle rectangle in resizeRects)
            {
                rectangle.IsEnabled = false;
            }
        }
        protected void EnableResize()
        {
            if (!AllowResize)
                return;

            foreach (Rectangle rectangle in resizeRects)
            {
                rectangle.IsEnabled = true;
            }
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
