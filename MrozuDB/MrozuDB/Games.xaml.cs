using MrozuDB.Model;
using MrozuDB.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrozuDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Games : ContentPage
    {
        public GamesViewModel GamesViewModel
        {
            get { return BindingContext as GamesViewModel; }
            set { BindingContext = value; }
        }
        public Games()
        {
            BindingContext = new GamesViewModel(new PageService());
            InitializeComponent();
            GamesViewModel.DisplayGamesListCommand.Execute(null);

        }

        private void LVGames_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as GamesViewModel).SelectedGameCommand.Execute(e.SelectedItem);
        }
    }
}