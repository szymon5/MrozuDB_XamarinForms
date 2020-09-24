using MrozuDB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MrozuDB.ViewModel
{
    public class RecordsDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<RecordDetailsInfo.Layout> RecordDetailsLayoutInfo { get; private set; } = new ObservableCollection<RecordDetailsInfo.Layout>();

        public ObservableCollection<RecordDetailsInfo.listView> RecordDetailslistViewInfo { get; private set; } = new ObservableCollection<RecordDetailsInfo.listView>();

        public IPageService pageService;
        public ICommand GetListOfRecordsDetailsCommand { get; private set; }
        public ICommand ListenOnYouTubeCommand { get; private set; }

        private string recordID;

        public RecordsDetailsViewModel(IPageService pageService,string recordID)
        {
            this.pageService = pageService;
            this.recordID = recordID;
            GetListOfRecordsDetailsCommand = new Command(GetListOfRecordsDetails);
            ListenOnYouTubeCommand = new Command(() => ListenOnYouTube());
        }
        private void GetListOfRecordsDetails()
        {
            Thread layoutThread = new Thread(GetRecordLayout);
            layoutThread.Start();

            Thread listViewThread = new Thread(GetRecordListView);
            listViewThread.Start();

            layoutThread.Join();
            listViewThread.Join();
        }
        public async void GetRecordLayout()
        {
            //var layout = (await App.MobileServiceClient.GetTable<RecordDetailsInfo.Layout>().Where(l => l.Id == recordID).ToListAsync()).FirstOrDefault();
            //RecordDetailsLayoutInfo.Add(layout);

            var json = JsonConvert.DeserializeObject<List<RecordDetailsInfo.Layout>>(await DataBaseConnection.GetDetails(URL.RECORD_LAYOUT, "rec_id", recordID)).ToArray();

            for (int i = 0; i < json.Length; i++) RecordDetailsLayoutInfo.Add(json[i]);
        }
        public async void GetRecordListView()
        {
            var json = JsonConvert.DeserializeObject<List<RecordDetailsInfo.listView>>(await DataBaseConnection.GetDetails(URL.RECORD_LISTVIEW, "rec_id", recordID)).ToArray();

            for (int i = 0; i < json.Length; i++) RecordDetailslistViewInfo.Add(json[i]);
        }
        private async void ListenOnYouTube()
        {
            await pageService.OpenAsync(Lists.YouTube.RecordsFilmsGames[0][Help.recordTitle]);
        }
        protected void OnProrertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
