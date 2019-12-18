using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Jellyfin.X.Models
{
    public class ItemCard
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool DetailVisible
        {
            get
            {
                return !string.IsNullOrEmpty(Detail);
            }
        }
        public Color BaseColor { get; set; }
        public Color BaseTextColor { get; set; }
        public Color BorderColor { get; set; }
        public Uri ImageSourceUri { get; set; }
        public bool HasImage
        {
            get
            {
                return ImageSourceUri != null;
            }
        }
        public double Width { get; set; } = 100;
        public double AspectRatio { get; set; } = Helpers.AspectRatio.Poster;
        public double ComputedInnerHeight
        {
            get
            {
                return Width / AspectRatio;
            }
        }
        public double ComputedTotalHeight
        {
            get
            {
                return ComputedInnerHeight + 60;
            }
        }
    }
}
