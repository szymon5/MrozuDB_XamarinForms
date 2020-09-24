using MrozuDB.Model;
//using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MrozuDB.ViewModel
{
    public class RecordsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Record> Records { get; private set; } = new ObservableCollection<Record>();

        private IPageService pageService;
        public ICommand DisplayListOfRecordsCommand { get; private set; }
        public ICommand SelectRecordCommand { get; private set; }

        private Record _selectedRecord;

        public Record SelectedRecord
        {
            get
            {
                return _selectedRecord;
            }
            set
            {
                if (_selectedRecord == value) return;
                _selectedRecord = value;
                OnProrertyChanged();
            }
        }
        public RecordsViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            DisplayListOfRecordsCommand = new Command(async () => await GetListOfRecords());
            SelectRecordCommand = new Command<Record>(async sr => await RecordSelected(sr));
        }

        private async Task GetListOfRecords()
        {
            //var rec = await App.MobileServiceClient.GetTable<Record>().ToListAsync();
            //for (int i = 0; i < rec.Count; i++) Records.Add(rec[i]);

            var response = await DataBaseConnection.GetList(URL.RECORDS);
            var json = JsonConvert.DeserializeObject<List<Record>>(response).ToArray();

            for (int i = 0; i < json.Length; i++) Records.Add(json[i]);


        }
        private async Task RecordSelected(Record record)
        {
            if (record == null) return;
            string recordID = record.rec_id;
            Help.recordTitle = record.rec_title;
            SelectedRecord = null;
            await pageService.PushAsync(new RecordDetails(recordID));
        }
        protected void OnProrertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
