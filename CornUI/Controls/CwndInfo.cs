using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;

namespace CornUI.Controls
{
    public class CwndInfo : BaseINCP
    {
        public bool AllowResize
        {
            get { return allowResize; }
            set { allowResize = value; }
        }
        public int MinHeight
        { 
            get { return minHeight; }
            set { minHeight = value; }
        }
        public int MaxHeight
        { 
            get { return maxHeight; }
            set { maxHeight = value; }
        }
        public int MinWidth
        { 
            get { return minWidth; }
            set { minWidth = value; }
        }
        public int MaxWidth
        {
            get { return maxWidth; }
            set { maxWidth = value; }
        }
        public int BorderWidth
        { 
            get { return borderWidth; }
            set { borderWidth = value; }
        }
        public int BorderRoundEdgeRadius
        {
            get { return borderWidth + topRoundEdgeRadius; }
        }
        public int TopBarHeight
        { 
            get { return topBarHeight; }
            set { topBarHeight = value; }
        }
        public Color TopBarColor
        {
            get { return topBarColor; }
            set { topBarColor = value; }
        }
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        public int BottomRoundEdgeRadius
        { 
            get { return bottomRoundEdgeRadius; }
            set { bottomRoundEdgeRadius = value; }
        }
        public int TopRoundEdgeRadius
        { 
            get { return topRoundEdgeRadius; }
            set { topRoundEdgeRadius = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public FontFamily FontType
        { 
            get { return fontType; }
            set { fontType = value; }
        }
        public FontWeight FontWeight
        {
            get { return fontWeight; }
            set { fontWeight = value; }
        }
        public Color FontColor
        {
            get { return fontColor; }
            set { fontColor = value; }
        }
        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }
        protected string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }
        protected int IconSize 
        {
            get { return iconSize; }
            set { iconSize = value; }
        }

        protected bool allowResize = true;
        protected int minHeight = 200;
        protected int minWidth = 200;
        protected int maxHeight = -1;
        protected int maxWidth = -1;

        protected int borderWidth = 5;

        protected int topBarHeight = 25;
        protected Color topBarColor = Colors.Gray;
        protected Color backColor = Colors.White;

        protected int bottomRoundEdgeRadius = 10;
        protected int topRoundEdgeRadius = 10;

        protected string title = "feneric title";
        protected FontFamily fontType = new FontFamily("Tahoma");
        protected FontWeight fontWeight = FontWeights.Bold;
        protected Color fontColor = Colors.Black;
        protected int fontSize = 14;

        protected int iconSize = 20;
        protected string iconPath = "Icon.png";
    }
}
