using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using CornUI.Controls;

namespace CornUI.Model
{
    public class CwndInfo
    {
        public double BorderWidth
        {
            get { return borderWidth; }
            set 
            {
                borderWidth = value;
                UpdateUI("BorderWidth");
            }
        }
        public double BorderRoundEdgeRadius
        {
            get { return borderWidth + roundEdgeRadius; }
            set { }
        }
        public int TopBarHeight
        {
            get { return topBarHeight; }
            set 
            { 
                topBarHeight = value;
                UpdateUI("TopBarHeight");
            }
        }
        public Brush TopBarColor
        {
            get { return topBarColor; }
            set 
            { 
                topBarColor = value;
                UpdateUI("TopBarColor");
            }
        }
        public Brush BackColor
        {
            get { return backColor; }
            set 
            { 
                backColor = value;
                UpdateUI("BackColor");
            }
        }
        public double RoundEdgeRadius
        {
            get { return roundEdgeRadius; }
            set 
            {
                roundEdgeRadius = value;
                UpdateUI("RoundEdgeRadius");
            }
        }
        public FontFamily CwndFontType
        {
            get { return fontType; }
            set 
            { 
                fontType = value;
                UpdateUI("CwndFontType");
            }
        }
        public FontWeight CwndFontWeight
        {
            get { return fontWeight; }
            set 
            { 
                fontWeight = value;
                UpdateUI("CwndFontWeight");
            }
        }
        public Brush CwndFontColor
        {
            get { return fontColor; }
            set 
            { 
                fontColor = value;
                UpdateUI("CwndFontColor");
            }
        }
        public int CwndFontSize
        {
            get { return fontSize; }
            set 
            { 
                fontSize = value;
                UpdateUI("CwndFontSize");
            }
        }
        public int IconSize
        {
            get { return iconSize; }
            set 
            { 
                iconSize = value; 
            }
        }

        List<Cwnd> windows = new List<Cwnd>();

        protected bool allowResize = true;
        protected double borderWidth = 10;

        protected int topBarHeight = 30;
        protected Brush topBarColor = Brushes.Gray;
        protected Brush backColor = Brushes.White;
        protected double roundEdgeRadius = 7;

        protected FontFamily fontType = new FontFamily("Tahoma");
        protected FontWeight fontWeight = FontWeights.Bold;
        protected Brush fontColor = Brushes.Black;
        protected int fontSize = 14;

        protected int resizeRectSizeCorner = 10;
        protected int resizeRectSizeMiddle = 5;

        protected int iconSize = 25;

        public void Register(Cwnd cwnd)
        {
            windows.Add(cwnd);
        }
        protected void UpdateUI(string propertyName)
        {
            foreach(Cwnd window in windows)
            {
                window.RaisePropertyChanged(propertyName);
            }
        }
    }
}
