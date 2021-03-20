using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CornUI.Model
{
    //Singleton
    public class Theme : CornUI.Controls.BaseINCP
    {
        static Theme theme;

        private Theme(CwndInfo info)
        {
            this.info = info;
            LightMode();
        }

        public static Theme GetInstance()
        {
            if (theme is null)
            {
                theme = new Theme(new CwndInfo());
                return theme;
            }
            else
            {
                return theme;
            }
        }

        public Brush TextBoxBackGround
        {
            get { return textBoxBackGround; }
            set
            {
                textBoxBackGround = value;
                RaisePropertyChanged("TextBoxBackGround");
            }
        }
        public Brush BackGround
        {
            get { return backGround; }
            set
            {
                backGround= value;
                RaisePropertyChanged("BackGround");
                info.BackColor = value;
            }
        }
        public Brush MenuBar
        {
            get { return menuBar; }
            set
            {
                menuBar = value;
                RaisePropertyChanged("MenuBar");
                info.TopBarColor = value;
            }
        }
        public Brush ButtonBackGround
        {
            get { return buttonBackGround; }
            set
            {
                buttonBackGround = value;
                RaisePropertyChanged("ButtonBackGround");
            }
        }
        public Brush TextAndIcon
        {
            get { return textAndIcon; }
            set
            {
                textAndIcon = value;
                RaisePropertyChanged("TextAndIcon");
            }
        }
        public Brush ImportantTextAndIcon
        {
            get { return importantTextAndIcon; }
            set
            {
                importantTextAndIcon = value;
                RaisePropertyChanged("ImportantTextAndIcon");
                info.CwndFontColor = value;
            }
        }
        public Brush FocusedControl
        {
            get { return focusedControl; }
            set
            {
                focusedControl = value;
                RaisePropertyChanged("FocusedControl");
            }
        }
        public Brush HoverControl
        {
            get { return hoverControl; }
            set
            {
                hoverControl = value;
                RaisePropertyChanged("HoverControl");
            }
        }
        public double ShadowOpacity
        {
            get { return shadowOpacity; }
            set
            {
                shadowOpacity = value;
                RaisePropertyChanged("ShadowOpacity");
            }
        }
        public CwndInfo WindowInfo
        {
            get { return info; }
        }

        public void DarkMode()
        {
            TextBoxBackGround = new SolidColorBrush(Color.FromArgb(255, 18, 18, 18));
            BackGround = new SolidColorBrush(Color.FromArgb(255, 24, 24, 24));
            MenuBar = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
            ButtonBackGround = new SolidColorBrush(Color.FromArgb(255, 48, 48, 48));
            TextAndIcon = new SolidColorBrush(Color.FromArgb(255, 160, 160, 160));
            ImportantTextAndIcon = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            FocusedControl = new SolidColorBrush(Color.FromArgb(255, 62, 166, 255));
            HoverControl = new SolidColorBrush(Color.FromArgb(255, 98, 138, 173));
            ShadowOpacity = 0.75f;

        }

        public void LightMode()
        {
            TextBoxBackGround = new SolidColorBrush(Color.FromArgb(255, 18, 18, 18));
            BackGround = new SolidColorBrush(Color.FromArgb(255, 24, 24, 24));
            MenuBar = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
            ButtonBackGround = new SolidColorBrush(Color.FromArgb(255, 48, 48, 48));
            TextAndIcon = new SolidColorBrush(Color.FromArgb(255, 160, 160, 160));
            ImportantTextAndIcon = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            FocusedControl = new SolidColorBrush(Color.FromArgb(255, 62, 166, 255));
            HoverControl = new SolidColorBrush(Color.FromArgb(255, 98, 138, 173));
            ShadowOpacity = 0.75f;
        }

        protected CwndInfo info;
        protected Brush textBoxBackGround;
        protected Brush backGround;
        protected Brush menuBar;
        protected Brush buttonBackGround;
        protected Brush textAndIcon;
        protected Brush importantTextAndIcon;
        protected Brush focusedControl;
        protected Brush hoverControl;
        protected double shadowOpacity;
    }
}
