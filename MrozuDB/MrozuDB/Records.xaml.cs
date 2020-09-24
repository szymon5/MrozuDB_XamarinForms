using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using MrozuDB.Model;
using System.Threading;
using MrozuDB.ViewModel;

namespace MrozuDB
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Records : ContentPage
    {
        public RecordsViewModel RecordsViewModel
        {
            get { return BindingContext as RecordsViewModel; }
            set { BindingContext = value; }
        }
        public Records()
        {
            
            RecordsViewModel = new RecordsViewModel(new PageService());
            InitializeComponent();
            RecordsViewModel.DisplayListOfRecordsCommand.Execute(null);
        }
        private void LVRecords_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            RecordsViewModel.SelectRecordCommand.Execute(e.SelectedItem);
        }
    }
}
