#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
#endregion

namespace Shared.FileStorage.AzureBlob.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private string _connectionString = "UseDevelopmentStorage=true;";

        [TestMethod]
        public async Task UploadFileTest()
        {
            // Arrange
            Service target = new Service();
            target.ConnectionString = _connectionString;
            string blobname = Utilities.GenerateNewFilename().ToLower();
            // Act
            await target.UploadFile("container", blobname, Utilities.TransparentGif);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task DownloadFileTest()
        {
            // Arrange
            Service target = new Service();
            target.ConnectionString = _connectionString;
            string blobname = Utilities.GenerateNewFilename().ToLower();

            // Act
            await target.UploadFile("container", blobname, Utilities.TransparentGif);
            var actual = await target.DownloadFile("container", blobname);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public async Task DeleteFileTest()
        {
            // Arrange
            Service target = new Service();
            target.ConnectionString = _connectionString;
            string blobname = Utilities.GenerateNewFilename().ToLower();

            // Act
            await target.UploadFile("container", blobname, Utilities.TransparentGif);
            await target.DeleteFile("container", blobname);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task ListFilesTest()
        {
            // Arrange
            Service target = new Service();
            target.ConnectionString = _connectionString;

            // Act
            await target.UploadFile("container3", Utilities.GenerateNewFilename(), Utilities.TransparentGif);
            await target.UploadFile("container3", Utilities.GenerateNewFilename(), Utilities.TransparentGif);
            await target.UploadFile("container3", Utilities.GenerateNewFilename(), Utilities.TransparentGif);
            var actual = await target.ListFiles("container3");

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
        }

    }
}
