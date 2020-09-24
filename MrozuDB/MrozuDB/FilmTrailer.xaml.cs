using Microsoft.WindowsAzure.Storage;
using MrozuDB.Model;
using MrozuDB.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrozuDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmTrailer : ContentPage
    {
        public FilmTrailerViewModel FilmTrailerViewModel
        {
            get { return BindingContext as FilmTrailerViewModel; }
            set { BindingContext = value; }
        }
        public FilmTrailer()
        {
            BindingContext = new FilmTrailerViewModel(new PageService());
            InitializeComponent();
            FilmTrailerViewModel.PlayFilmTrailerCommand.Execute(video);
            //PlayFilmTrailer();
        }
        //public async void PlayFilmTrailer()
        //{
        //    await FilmTrailerViewModel.PlayFilmTrailer(video, FilmTrailerIndicator);
        //}
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            FilmTrailerViewModel.StopFilmTrailerAndBackToTheFilmDetailsCommand.Execute(video);
        }
    }
}