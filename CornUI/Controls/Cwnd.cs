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
using CornUI.Model;

namespace CornUI.Controls
{
    /// <summary>
    /// Interaction logic for CwndVisual.xaml
    /// </summary>
    public partial class Cwnd : Window, INotifyPropertyChanged
    {
        #region Property
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
                    RaisePropertyChanged("BorderPadding");

                    if (state == WindowState.Maximized)
                    {
                        GetCurrentScreen();
                        if (!resizeWithMaximize)
                        {
                            Height = MaxHeight;
                        }
                    }
                    else
                    {
                        MaxHeight = SystemParameters.VirtualScreenHeight;
                    }
                }
                RaisePropertyChanged("MaximizePadding");
            }
        }
        public double MaximizePadding
        {
            get
            {
                if (state != WindowState.Maximized)
                {
                    return 0;
                }
                return maximizePadding;
            }
            set { }
        }
        public double BorderPadding
        {
            get 
            { 
                if (state == WindowState.Maximized)
                {
                    return 0;
                }

                return borderPadding; 
            }
            set 
            { 
                borderPadding = value;
                RaisePropertyChanged("BorderPadding");
            }
        }
        public Utility.Screen CurrentScreen
        {
            get { return currentScreen; }
            set
            {
                currentScreen = value;
                MaxHeight = value.height;
            }
        }
        #endregion
        protected bool used = false;
        protected bool resizeWithMaximize = false;


        protected Utility.Screen currentScreen;
        protected double borderPadding = 15;
        protected double maximizePadding = 6;
        protected bool restoreIfMove = false;
        protected WindowState state = WindowState.Normal;
        protected string title = "yeah";
        protected string iconPath = "Icon.png";
        protected bool allowResize = true;
        protected CwndInfo info;
        protected Border borderShadow;

        #region Constructor
        public Cwnd(CwndInfo info)
        {
            Register(info);
        }
        protected void Register(CwndInfo info)
        {
            info.Register(this);
            this.info = info;
            this.DataContext = this;
        }
        #endregion
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
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("One of the system buttons is null");
            }

            used = true;
            base.OnApplyTemplate();
        }

        protected void GetCurrentScreen()
        {
            if (!used)
                return;

            Point pos = this.PointToScreen(new Point(0, 0));
            CurrentScreen = Utility.ScreenHelper.GetScreen(pos.X, pos.Y, Width, Height);
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
                resizeWithMaximize = true;
                WindowState = WindowState.Maximized;
            }
        }
        protected void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
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
