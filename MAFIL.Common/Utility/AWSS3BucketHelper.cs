using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAFIL.Common.Utility
{
   /// Developer : Sanoop ,Date : 15-06-21, Description:Helper class to upload documents to AWS-S3 
    public interface IAWSS3BucketHelper
    {
        Task<string> UploadFile(System.IO.Stream inputStream, string fileName, string bucketName);
        Task<ListVersionsResponse> FilesList(string bucketName);

        Task<Stream> GetFile(string bucketName, string key);

        string GetPreSignedURL(string fileName, string bucketName);

        Task<string> DeleteFile(string bucketName, string key);

    }
    public class AWSS3BucketHelper : IAWSS3BucketHelper
    {
        private readonly IAmazonS3 _amazonS3;
     
        public AWSS3BucketHelper(IAmazonS3 s3Client)
        {
            this._amazonS3 = s3Client;
          
        }
        public async Task<string> UploadFile(System.IO.Stream inputStream, string fileName, string bucketName)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest()
                {
                    InputStream = inputStream,
                    //BucketName = "losdocs", /*_settings.AWSS3.BucketName*/
                    BucketName= bucketName,
                    Key = fileName
                };
                
                PutObjectResponse response = await _amazonS3.PutObjectAsync(request);

                return response.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<Stream> GetFile(string bucketName, string key)
        {
            try
            {
                //GetObjectResponse response = await _amazonS3.GetObjectAsync("losdocs", key);
                GetObjectResponse response = await _amazonS3.GetObjectAsync(bucketName, key);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return await Task.FromResult(response.ResponseStream);
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }

            
        }
        public async Task<ListVersionsResponse> FilesList(string bucketName)
        {
            //return await _amazonS3.ListVersionsAsync("losdocs");
            return await _amazonS3.ListVersionsAsync(bucketName);
        }

        public string GetPreSignedURL(string fileName, string bucketName)
        {
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest();
            //request.BucketName = "losdocs"; 
            request.BucketName = bucketName;
            request.Key = fileName;
            request.Expires = DateTime.Now.AddHours(1);
            request.Protocol = Protocol.HTTP;
            string url = _amazonS3.GetPreSignedURL(request);
            return url;
        }

        public async Task<string> DeleteFile(string bucketName, string key)
        {
            try
            {
                //DeleteObjectResponse response = await _amazonS3.DeleteObjectAsync("losdocs", key);
                DeleteObjectResponse response = await _amazonS3.DeleteObjectAsync(bucketName, key);

                return response.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        //public async Task<List<string>> FilesListOfURL()
        //{
        //    try
        //    {
        //        ListVersionsResponse listVersions = await _AWSS3BucketHelper.FilesList();
        //        return listVersions.Versions.Select(c => c.Key).ToList();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}



    }
}
