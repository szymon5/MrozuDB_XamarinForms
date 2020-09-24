using MrozuDB.Model;
using MrozuDB.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrozuDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameTrailer : ContentPage
    {
        public GameTrailerViewModel GameTrailerViewModel
        {
            get { return BindingContext as GameTrailerViewModel; }
            set { BindingContext = value; }
        }
        public GameTrailer()
        {
            BindingContext = new GameTrailerViewModel(new PageService());
            InitializeComponent();
            GameTrailerViewModel.PlayGameTrailerCommand.Execute(video);
            //PlayGameTrailer();
        }
        //public async void PlayGameTrailer()
        //{
        //    await GameTrailerViewModel.PlayGameTrailer(video, GameTrailerIndicator);
        //}
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            GameTrailerViewModel.StopGameTrailerAndBackToTheGameDetailsCommand.Execute(video);
        }
    }
}