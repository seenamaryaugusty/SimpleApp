using System;
using AppViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibraries;
using Moq;

namespace ViewModelTest
{
    [TestClass]
    public class ImageSearchViewModelTest
    {
        private Mock<ISearchModel> modelMock;
        private SearchViewModel viewModel;

        [TestInitialize]
        public void TestInit()
        {
            this.modelMock = new Mock<ISearchModel>();
            this.viewModel = new SearchViewModel(modelMock.Object);
        }

        [TestMethod]
        public void ImageSearchViewModel_ImagesTestForUrl()
        {
            this.modelMock.Setup(m => m.GetSearchItems()).Returns(new string[] { "sampleUrl" });
            Assert.AreEqual(this.viewModel.SearchItems[0], "sampleUrl");
        }

        [TestMethod]
        public void ImageSearchViewModel_SearchCommandTest()
        {
            this.modelMock.Setup(m => m.LoadSearchItemsToLocal("nature")).Returns(true);
            this.modelMock.Setup(m => m.GetSearchItems()).Returns(new string[] { "sampleUrl" });
            this.viewModel.Search.Execute("nature");
            Assert.AreEqual(this.viewModel.SearchItems[0], "sampleUrl");
        }
    }
}
