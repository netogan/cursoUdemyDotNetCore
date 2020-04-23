using RestAppUdemy.Data.VO;
using System.IO;

namespace RestAppUdemy.Business.Implementations
{
    public class FileBusinessImpl : IFileBusiness
    {

        public byte[] GetFile()
        {
            var path = Directory.GetCurrentDirectory();

            var fullPath = path + "\\Other\\croqui.pdf";

            return File.ReadAllBytes(fullPath);
        }
    }
}
