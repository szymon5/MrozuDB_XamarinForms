using MrozuDB.Model;
using MrozuDB.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrozuDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetails : ContentPage
    {
        public GamesDetailsViewModel GamesDetailsViewModel
        {
            get { return BindingContext as GamesDetailsViewModel; }
            set { BindingContext = value; }
        }
        public GameDetails(string gameID)
        {
            BindingContext = new GamesDetailsViewModel(new PageService(),gameID);
            InitializeComponent();
            GamesDetailsViewModel.GetListOfGamesDetailsCommand.Execute(null);
        }
    }
}