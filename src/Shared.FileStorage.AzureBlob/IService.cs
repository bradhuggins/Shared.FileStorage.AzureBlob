#region Using Statements
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Shared.FileStorage.AzureBlob
{
    public interface IService
    {
        string ErrorMessage { get; set; }
        bool HasError { get; }
        string ConnectionString { get; set; }

        Task DeleteFile(string container, string fileName);
        Task<byte[]> DownloadFile(string container, string fileName);
        Task UploadFile(string container, string fileName, byte[] fileData);
        Task<List<string>> ListFiles(string container);
    }
}
