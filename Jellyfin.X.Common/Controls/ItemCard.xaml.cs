using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jellyfin.X.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCard : Grid
    {
        public ItemCard()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ItemCard), default(string), BindingMode.OneWay);
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public static readonly BindableProperty DetailProperty = BindableProperty.Create(nameof(Detail), typeof(string), typeof(ItemCard), default(string), BindingMode.OneWay);
        public string Detail
        {
            get
            {
                return (string)GetValue(DetailProperty);
            }

            set
            {
                SetValue(DetailProperty, value);
            }
        }

        public bool DetailVisible
        {
            get
            {
                return !string.IsNullOrEmpty(Detail);
            }
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(Uri), typeof(ItemCard), default(string), BindingMode.OneWay);
        public Uri ImageSource
        {
            get
            {
                return (Uri)GetValue(ImageSourceProperty);
            }

            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        public bool HasImage
        {
            get
            {
                return ImageSource != null;
            }
        }

        public static readonly BindableProperty BaseColorProperty = BindableProperty.Create(nameof(BaseColor), typeof(Color), typeof(ItemCard), default(string), BindingMode.OneWay);
        public Color BaseColor
        {
            get
            {
                return (Color)GetValue(BaseColorProperty);
            }

            set
            {
                SetValue(BaseColorProperty, value);
            }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ItemCard), default(string), BindingMode.OneWay);
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }

            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public static readonly BindableProperty BaseTextColorProperty = BindableProperty.Create(nameof(BaseTextColor), typeof(Color), typeof(ItemCard), default(string), BindingMode.OneWay);
        public Color BaseTextColor
        {
            get
            {
                return (Color)GetValue(BaseTextColorProperty);
            }

            set
            {
                SetValue(BaseTextColorProperty, value);
            }
        }

        public static readonly BindableProperty CardWidthProperty = BindableProperty.Create(nameof(CardWidth), typeof(double), typeof(ItemCard), default(string), BindingMode.OneWay);
        public double CardWidth
        {
            get
            {
                return (double)GetValue(CardWidthProperty);
            }

            set
            {
                SetValue(CardWidthProperty, value);
            }
        }

        public static readonly BindableProperty AspectRatioProperty = BindableProperty.Create(nameof(AspectRatio), typeof(double), typeof(ItemCard), default(string), BindingMode.OneWay);
        public double AspectRatio
        {
            get
            {
                return (double)GetValue(AspectRatioProperty);
            }

            set
            {
                SetValue(AspectRatioProperty, value);
            }
        }

        public double ComputedInnerHeight
        {
            get
            {
                return WidthRequest / AspectRatio;
            }
        }
    }
}