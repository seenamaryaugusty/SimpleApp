using System;
using BackendLibraries;
using AppModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ModelTest
{
    [TestClass]
    public class ImageSearchModelTest
    {
        private Mock<IXmlHelper> imageXmlHelperMock;
        private Mock<IFileHelper> fileHelperMock;
        private SearchModel model;

        [TestInitialize]
        public void TestInit()
        {
            this.imageXmlHelperMock = new Mock<IXmlHelper>();
            this.fileHelperMock = new Mock<IFileHelper>();
            this.model = new SearchModel(this.imageXmlHelperMock.Object, this.fileHelperMock.Object);
        }

        [TestMethod]
        public void ImageSearchModel_GetStaticImageUrls_Test()
        {
            this.imageXmlHelperMock.Setup(im => im.GetSearchArray()).Returns(new string[] { "sampleUrl" });
            string actual = this.model.GetSearchItems()[0];
            string expected = "sampleUrl";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ImageSearchModel_LoadImagesToLocal_Test()
        {
            this.imageXmlHelperMock.Setup(im => im.LoadXmlDataToLocal(It.IsAny<string>())).Returns(true);
            Assert.IsTrue(this.model.LoadSearchItemsToLocal("sample"));
        }
    }
}
