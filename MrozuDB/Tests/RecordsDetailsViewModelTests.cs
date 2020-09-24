using Moq;
using MrozuDB.Model;
using MrozuDB.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace MrozuDB.Tests
{
    public class RecordsDetailsViewModelTests
    {
        private RecordsDetailsViewModel _recordsDetails;
        private Mock<IPageService> _pageService;
        private Mock<string> _recID;

        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _recordsDetails = new RecordsDetailsViewModel(_pageService.Object,_recID.Object);
        }
        [Test]
        public void GetRecordLayout_Test()
        {
            var expexted = new List<RecordDetailsInfo.Layout>();
            _recordsDetails.GetRecordLayout();
            CollectionAssert.AreEqual(expexted,_recordsDetails.RecordDetailsLayoutInfo);
        }

        [Test]
        public void GetRecordListView_Test()
        {
            var expexted = new List<RecordDetailsInfo.listView>();
            _recordsDetails.GetRecordListView();
            CollectionAssert.AreEqual(expexted, _recordsDetails.RecordDetailslistViewInfo);
        }
    }
}
