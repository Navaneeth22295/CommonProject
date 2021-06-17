using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MAFIL.Common.Utility
{
   public class FileUpload
    {
        public class UploadFile
        {
            public string Base64Data { get; set; }
            public string FileName { get; set; }
            public string FileExtn { get; set; }

            public Stream FileUrl { get; set; }
        }
        public string CreatePdfFile(UploadFile file)
        {
            string base64String = file.Base64Data.Substring(file.Base64Data.IndexOf("base64") + 7);
            // Convert Base64 Encoded string to Byte Array.
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // string sPathFile = System.Web.Hosting.HostingEnvironment.MapPath("~/files/");
            string sPathFile = Directory.GetCurrentDirectory() + "/MyStaticFiles/files";
            var fileNamewithExt = file.FileName;
            int lastIndex = fileNamewithExt.LastIndexOf('.');
            var name = fileNamewithExt.Substring(0, lastIndex);
            var newFileName = Path.GetFileName(name + "(" + DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + ")" + '.' + file.FileExtn);
            // Save the Byte Array as Image File.
            string fileName = sPathFile + newFileName;
            string fileUrl = Path.GetFileName(newFileName);
           // file.UploadFile = fileUrl;
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(imageBytes, 0, imageBytes.Length);
            fileStream.Close();

            return fileUrl;
        }

        //public string BaseImageReader(IFormFile file, string extn, string name)
        //{
        //    try
        //    {
        //        var stream = file.OpenReadStream();
        //        byte[] bytes;

        //        using (var memoryStream = new MemoryStream())
        //        {
        //            stream.CopyTo(memoryStream);
        //            bytes = memoryStream.ToArray();
        //            string base64 = Convert.ToBase64String(bytes);
        //            string imageExtn = extn;
        //            string imageName = (name.Split(".")[0]).Trim(' ');
        //            byte[] imageBytes = Convert.FromBase64String(base64);
        //            var fileName = imageName.Replace('.' + imageExtn, "") + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + imageExtn;
        //            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        //            {
        //                ms.Write(imageBytes, 0, imageBytes.Length);
        //                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
        //                string imageUrl = Path.GetFileName(fileName);
        //                ImageFormat imageFormat = null;

        //                switch (imageExtn)
        //                {
        //                    case "jpg":
        //                    case "jpeg":
        //                        imageFormat = ImageFormat.Jpeg;
        //                        break;
        //                    case "png":
        //                        imageFormat = ImageFormat.Png;
        //                        break;
        //                }

        //                var folder = Directory.GetCurrentDirectory() + "/wwwroot/images/" + fileName;



        //                image.Save(folder);






        //                // image.Save(filePath + "/" +fileName);
        //                // _log.Info("After Save");
        //            }
        //            return fileName;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _log.ErrorFormat("BaseImageReader " + e.InnerException.Message);
        //        _log.ErrorFormat("BaseImageReader " + e.Message);
        //        return null;
        //    }
        //}



    }
}
