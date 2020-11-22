using System;
using ImageAppViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibraries;
using Moq;

namespace ViewModelTest
{
    [TestClass]
    public class ImageSearchViewModelTest
    {
        private Mock<IImageSearchModel> modelMock;
        private ImageSearchViewModel viewModel;

        [TestInitialize]
        public void TestInit()
        {
            this.modelMock = new Mock<IImageSearchModel>();
            this.viewModel = new ImageSearchViewModel(modelMock.Object);
        }

        [TestMethod]
        public void ImageSearchViewModel_ImagesTestForUrl()
        {
            this.modelMock.Setup(m => m.GetStaticImageUrls()).Returns(new string[] { "sampleUrl" });
            Assert.AreEqual(this.viewModel.Images[0], "sampleUrl");
        }

        [TestMethod]
        public void ImageSearchViewModel_SearchCommandTest()
        {
            this.modelMock.Setup(m => m.LoadImagesToLocal("nature")).Returns(true);
            this.modelMock.Setup(m => m.GetStaticImageUrls()).Returns(new string[] { "sampleUrl" });
            this.viewModel.SearchImage.Execute("nature");
            Assert.AreEqual(this.viewModel.Images[0], "sampleUrl");
        }
    }
}
