using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MrozuDB.Model
{
    public class PageService : IPageService
    {
        public async Task<bool> DisplayAlert(string title, string msg, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, msg, ok, cancel);
        }
        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }
        public async Task PopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task OpenAsync(string uri)
        {
            await Xamarin.Essentials.Launcher.OpenAsync(uri);
        }
    }
}
