using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Download;
using Google.Apis.Drive.v2.Data;
using System.Net;

namespace PowerPoint
{
    public class GoogleDriveService
    {
        private readonly string[] _scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService _service;
        private const int KB = 0x400;
        private const int DOWNLOAD_CHUNK_SIZE = 256 * KB;
        private int _timeStamp;
        private string _applicationName;
        private string _clientSecretFileName;
        private UserCredential _credential;

        /// <summary>
        /// 創造一個Google Drive Service
        /// </summary>
        /// <param name="applicationName">應用程式名稱</param>
        /// <param name="clientSecretFileName">ClientSecret檔案名稱</param>
        public GoogleDriveService(string applicationName, string clientSecretFileName)
        {
            _applicationName = applicationName;
            _clientSecretFileName = clientSecretFileName;
            this.CreateNewService(applicationName, clientSecretFileName);
        }

        //建立新的服務
        private void CreateNewService(string applicationName, string clientSecretFileName)
        {
            const string USER = "user";
            const string CREDENTIAL_FOLDER = ".credential/";
            var credentialPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), CREDENTIAL_FOLDER + applicationName);
            using (var stream = new FileStream(clientSecretFileName, FileMode.Open, FileAccess.Read))
            {
                _credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets, _scopes, USER, CancellationToken.None,
                    new FileDataStore(credentialPath, true)).Result;
            }
            _service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = _credential,
                ApplicationName = applicationName
            });
            _timeStamp = UNIXNowTimeStamp;
        }

        private int UNIXNowTimeStamp
        {
            get
            {
                const int UNIX_START_YEAR = 1970;
                DateTime unixStartTime = new DateTime(UNIX_START_YEAR, 1, 1);
                return Convert.ToInt32((DateTime.Now.Subtract(unixStartTime).TotalSeconds));
            }
        }

        //Check and refresh the credential if credential is out-of-date
        private void CheckCredentialTimeStamp()
        {
            const int ONE_HOUR_SECOND = 3600;
            int nowTimeStamp = UNIXNowTimeStamp;

            if ((nowTimeStamp - _timeStamp) > ONE_HOUR_SECOND)
                this.CreateNewService(_applicationName, _clientSecretFileName);
        }

        /// <summary>
        /// 查詢Google Drive 根目錄的檔案
        /// </summary>
        /// <returns>Google Drive File List</returns>
        public List<Google.Apis.Drive.v2.Data.File> ListRootFileAndFolder()
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            const string ROOT_QUERY_STRING = "'root' in parents";

            try
            {
                returnList = ListFileAndFolderWithQueryString(ROOT_QUERY_STRING);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return returnList;
        }

        /// <summary>
        /// 使用QueryString 查詢檔案 回傳一List
        /// </summary>
        /// <param name="queryString">QueryString，使用方法: https://developers.google.com/drive/web/search-parameters </param>
        /// <returns>含有Google Drive File 格式的 List</returns>
        private List<Google.Apis.Drive.v2.Data.File> ListFileAndFolderWithQueryString(string queryString)
        {
            CheckCredentialTimeStamp();
            var returnList = new List<Google.Apis.Drive.v2.Data.File>();
            var listRequest = _service.Files.List();
            listRequest.Q = queryString;
            do
            {
                returnList.AddRange(listRequest.Execute().Items);
                listRequest.PageToken = listRequest.Execute().NextPageToken;
            } while (!string.IsNullOrEmpty(listRequest.PageToken));
            return returnList;
        }

        /// <summary>
        /// 上傳檔案
        /// </summary>
        /// <param name="uploadFileName">上傳的檔案名稱 </param>
        /// <param name="contentType">上傳的檔案種類，請參考MIME Type : http://www.iana.org/assignments/media-types/media-types.xhtml </param>
        /// <param name="responseReceivedEventHandler">收到回應時呼叫的函式 </param>
        /// <returns>上傳成功，回傳上傳成功的 Google Drive 格式之File</returns>
        public Google.Apis.Drive.v2.Data.File UploadFile(string uploadFileName, string contentType, Action<Google.Apis.Drive.v2.Data.File> responseReceivedEventHandler = null)
        {
            const int DOUBLE = 2;
            using (var uploadStream = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read))
            {
                CheckCredentialTimeStamp();
                var title = Path.GetFileName(uploadFileName);
                var fileToInsert = new Google.Apis.Drive.v2.Data.File
                { 
                    Title = title };
                var insertRequest = _service.Files.Insert(fileToInsert, uploadStream, contentType);
                insertRequest.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * DOUBLE;
                insertRequest.ResponseReceived += responseReceivedEventHandler;
                insertRequest.Upload();
                return insertRequest.ResponseBody;
            }
        }

        /// <summary>
        /// 下載檔案
        /// </summary>
        /// <param name="fileToDownload">欲下載的檔案(Google Drive File) 一般會從List取得</param>
        /// <param name="downloadPath">下載到路徑</param>
        public void DownloadFile(Google.Apis.Drive.v2.Data.File fileToDownload, string downloadPath)
        {
            const string FILE_TYPE = "json";
            const string FILE_TYPE_ERROR = "The file is not a JSON file.";
            CheckCredentialTimeStamp();
            if (!string.IsNullOrEmpty(fileToDownload.DownloadUrl))
            {
                if (fileToDownload.FileExtension.ToLower() != FILE_TYPE)
                    throw new InvalidOperationException(FILE_TYPE_ERROR);
                var downloadByte = _service.HttpClient.GetByteArrayAsync(fileToDownload.DownloadUrl).Result;
                var downloadPosition = Path.Combine(downloadPath, fileToDownload.Title);
                System.IO.File.WriteAllBytes(downloadPosition, downloadByte);
            }
        }
    }
}
