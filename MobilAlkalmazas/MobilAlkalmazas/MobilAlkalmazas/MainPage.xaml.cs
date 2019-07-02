using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobilAlkalmazas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Your given content", entry.Text, "close");
        }

    }
}
