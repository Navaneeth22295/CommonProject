using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAFIL.Common.Utility
{
   public class FileUpload
    {
        public class Files
        {
            public string ImageData { get; set; }
            public string FileName { get; set; }
            public string ImageExtn { get; set; }
            public string UploadFile { get; set; }
        }
        public string CreatePdfFile(Files file)
        {
            string base64String = file.ImageData.Substring(file.ImageData.IndexOf("base64") + 7);
            // Convert Base64 Encoded string to Byte Array.
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // string sPathFile = System.Web.Hosting.HostingEnvironment.MapPath("~/files/");
            string sPathFile = Directory.GetCurrentDirectory() + "/MyStaticFiles";
            var fileNamewithExt = file.FileName;
            int lastIndex = fileNamewithExt.LastIndexOf('.');
            var name = fileNamewithExt.Substring(0, lastIndex);
            var newFileName = Path.GetFileName(name + "(" + DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + ")" + '.' + file.ImageExtn);
            // Save the Byte Array as Image File.
            string fileName = sPathFile + newFileName;
            string fileUrl = Path.GetFileName(newFileName);
            file.UploadFile = fileUrl;
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(imageBytes, 0, imageBytes.Length);
            fileStream.Close();

            return fileUrl;
        }
    }
}
