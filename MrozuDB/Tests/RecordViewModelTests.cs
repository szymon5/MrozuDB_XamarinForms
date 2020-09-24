using Moq;
using MrozuDB.Model;
using MrozuDB.ViewModel;
using NUnit.Framework;
using System.Collections.Generic;

namespace MrozuDB.Tests
{
    public class RecordViewModelTests
    {
        private RecordsViewModel _recordsViewModel;
        private Mock<IPageService> _pageService;
        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _recordsViewModel = new RecordsViewModel(_pageService.Object);
        }

        [Test]
        public void GetListOfRecords_Test()
        {
            var expected = new List<Record>();
            _recordsViewModel.DisplayListOfRecordsCommand.Execute(null);
            CollectionAssert.AreEqual(expected, _recordsViewModel.Records);
        }
        
        [Test]
        public void RecordSelected_Test()
        {
            var record = new Record();
            _recordsViewModel.Records.Add(record);
            _recordsViewModel.SelectRecordCommand.Execute(record);

            var id = Help.recordID;
            var title = Help.recordTitle;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(record.rec_id, id);
                Assert.AreEqual(record.rec_title, title);
                Assert.IsNull(_recordsViewModel.SelectedRecord);
            });
        }
    }
}