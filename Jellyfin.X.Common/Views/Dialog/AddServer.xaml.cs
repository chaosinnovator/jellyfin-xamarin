using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jellyfin.X.Views.Dialog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddServer : ContentView
    {
        public AddServer()
        {
            InitializeComponent();
        }
    }
}