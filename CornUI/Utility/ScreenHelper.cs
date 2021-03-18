using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;

namespace CornUI.Utility
{
    public class Screen
    {
        public int height;
        public int width;
    }

    public static class ScreenHelper
    {
        public static Screen GetScreen(Window window)
        {
            Screen returnValue = new Screen();
            var screen = System.Windows.Forms.Screen.FromHandle(
                new System.Windows.Interop.WindowInteropHelper(window).Handle);
            returnValue.height = screen.WorkingArea.Height;
            returnValue.width = screen.WorkingArea.Width;
            return returnValue;
        }

        public static Screen GetScreen(double x, double y, double width, double height)
        {
            Rectangle rect = System.Windows.Forms.Screen.GetWorkingArea(new Rectangle((int)x, (int)y, (int)width, (int)height));
            Screen returnValue = new Screen();
            returnValue.height = rect.Height + 10;
            returnValue.width = rect.Width;
            return returnValue;
        }

        public static Screen GetScreen(int x, int y, double width, double height)
        {
            return GetScreen((double)x, (double)y, width, height);
        }
    }
}
