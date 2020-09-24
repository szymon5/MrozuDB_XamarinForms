using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MrozuDB.Model
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopAsync();
        Task<bool> DisplayAlert(string title, string msg, string ok, string cancel);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);

        Task OpenAsync(string uri);
    }
}
