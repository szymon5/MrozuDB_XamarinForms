using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MrozuDB.Model;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Net;
using System.Collections.Specialized;
using MrozuDB.ViewModel;

namespace MrozuDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmDetails : ContentPage
    {   
        public FilmsDetailsViewModel FilmsDetailsViewModel
        {
            get { return BindingContext as FilmsDetailsViewModel; }
            set { BindingContext = value; }
        }
        public FilmDetails(string filmID)
        {
            BindingContext = new FilmsDetailsViewModel(new PageService(),filmID);
            InitializeComponent();

            FilmsDetailsViewModel.GetListOfFilmsDetailsCommand.Execute(null);
        }
    }
}