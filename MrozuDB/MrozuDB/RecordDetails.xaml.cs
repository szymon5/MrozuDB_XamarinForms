using MrozuDB.Model;
using MrozuDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrozuDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordDetails : ContentPage
    {
        public RecordsDetailsViewModel RecordsDetailsViewModel
        {
            get { return BindingContext as RecordsDetailsViewModel; }
            set { BindingContext = value; }
        }
        public RecordDetails(string recordID)
        {
            BindingContext = new RecordsDetailsViewModel(new PageService(),recordID);
            InitializeComponent();
            RecordsDetailsViewModel.GetListOfRecordsDetailsCommand.Execute(null);
        }
    }
}