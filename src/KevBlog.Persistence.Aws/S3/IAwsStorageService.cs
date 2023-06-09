﻿namespace KevBlog.Persistence.Aws.S3
{
    public interface IAwsStorageService
    {
        Task<bool> UploadFileAsync(Stream localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3);
        Task<byte[]> DownloadFileAsync(string file);
        Task<bool> DeleteAsync(string fileName, string versionId = "");
        Task<bool> IsFileExists(string fileName, string versionId = "");
    }
}
