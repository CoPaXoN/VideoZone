using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;


namespace VideoZoneV2.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Upload
    {
        [OperationContract]
        public UploadFile DoUpload(string videoname, string username, string filename, string category, string sharedTo, byte[] content, bool append)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            Video row = new Video()
            {
                VideoName = videoname,
                Username = username,
                FilePath = "/FileStore/" + username.Trim() + "/" + filename,
                Category = category,
            };
            if (sharedTo[sharedTo.Length] != ',')
            {
                row.SharedTo = sharedTo + ',';
            }
            else
            {
                row.SharedTo = sharedTo;
            }
            db.Videos.InsertOnSubmit(row);
            try
            {
                db.SubmitChanges();
            }
            catch { }
            string folder = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"FileStore\" + username.Trim() + @"\"));
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);
            FileMode m = FileMode.Create;
            if (append)
                m = FileMode.Append;
            using (FileStream fs = new FileStream(folder + @"\" + filename, m, FileAccess.Write))
            {
                fs.Write(content, 0, content.Length);
            }
            UploadFile file = new UploadFile { Name = filename, FileStoreUrl = "../FileStore/" + filename };
            return file;
        }
        [OperationContract]
        public byte[] DownloadChunk(String DocUrl, Int64 Offset, Int32 BufferSize)
        {
            String FilePath = HttpContext.Current.Server.MapPath(DocUrl);
            if (!System.IO.File.Exists(FilePath))
                return null;
            Int64 FileSize = new FileInfo(FilePath).Length;
            //// if the requested Offset is larger than the file, quit.
            if (Offset > FileSize)
            {
                //SecurityService.logger.Fatal("Invalid Download Offset - " + String.Format("The file size is {0}, received request for offset {1}", FileSize, Offset));
                return null;
            }
            // open the file to return the requested chunk as a byte[]
            byte[] TmpBuffer;
            int BytesRead;
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    fs.Seek(Offset, SeekOrigin.Begin);	// this is relevent during a retry. otherwise, it just seeks to the start
                    TmpBuffer = new byte[BufferSize];
                    BytesRead = fs.Read(TmpBuffer, 0, BufferSize);	// read the first chunk in the buffer (which is re-used for every chunk)
                }
                if (BytesRead != BufferSize)
                {
                    // the last chunk will almost certainly not fill the buffer, so it must be trimmed before returning
                    byte[] TrimmedBuffer = new byte[BytesRead];
                    Array.Copy(TmpBuffer, TrimmedBuffer, BytesRead);
                    return TrimmedBuffer;
                }
                else
                    return TmpBuffer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    [DataContract]
    public class UploadFile
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FileStoreUrl { get; set; }
    }
}
