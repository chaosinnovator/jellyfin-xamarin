using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Jellyfin.X.Helpers
{
    public static class SolidColorProvider
    {
        private static int Index = 0;
        public static Color ThisColor {
            get
            {
                return ColorList[Index];
            }
        }
        public static Color ThisColorAccent
        {
            get
            {
                return ThisColor.Luminosity > 0.5 ? new Color(0, 0, 0) : new Color(1, 1, 1);
            }
        }
        public static Color NextColor
        {
            get
            {
                _ = Index < ColorList.Length - 1 ? Index++ : 0;
                return ThisColor;
            }
        }
        public static Color NextRandomColor
        {
            get
            {
                Index = new Random().Next(0, ColorList.Length - 1);
                return ThisColor;
            }
        }

        public static Color[] ColorList =
        {
            Color.FromHsla(0.136, 0.79, 0.46), // Yellow; #d2b019; HSL 49 79 46
            Color.FromHsla(0.561, 0.58, 0.47), // Blue; #338abb; HSL 202 58 47
            Color.FromHsla(0.675, 0.21, 0.51), // Purple; #6b689d; HSL 243 21 51
            Color.FromHsla(0.025, 0.72, 0.52), // Red; #dd452b; HSL 9 72 52
            Color.FromHsla(0.447, 0.54, 0.58), // Green; #5ccea9; HSL 161 54 58
        };
    }
}
