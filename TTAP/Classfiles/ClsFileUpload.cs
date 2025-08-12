using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI.WebControls;

namespace TTAP.Classfiles
{
    public class ClsFileUpload
    {
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        public static int MimeSampleSize = 256;
        [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
        static extern int FindMimeFromData(IntPtr pBC,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)]
        byte[] pBuffer,
        int cbSize,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
        int dwMimeFlags,
        out IntPtr ppwzMimeOut,
        int dwReserved);

        General Gen = new General();

        public string getmimetype(FileUpload FileUploadDoc)
        {

            string[] fileType = FileUploadDoc.PostedFile.FileName.Split('.');
            int i = fileType.Length;
            HttpPostedFile file = FileUploadDoc.PostedFile;
            byte[] document = new byte[file.ContentLength];
            file.InputStream.Read(document, 0, file.ContentLength);

            IntPtr mimeTypePtr;
            FindMimeFromData(IntPtr.Zero, null, document, 256, null, 0, out mimeTypePtr, 0);
            string mime = Marshal.PtrToStringUni(mimeTypePtr);

            return mime;
        }
        public string GetMimeFromBytes(byte[] document)
        {
            var mime = "";
            try
            {
                uint mimeType = 0;
                IntPtr mimeTypePtr;
                FindMimeFromData(IntPtr.Zero, null, document, 256, null, 0, out mimeTypePtr, 0);
                var mimePointer = new IntPtr(mimeType);
                mime = Marshal.PtrToStringUni(mimePointer);
                Marshal.FreeCoTaskMem(mimePointer);
            }
            catch
            {

            }
            return mime;
        }
        public void DeleteFile(string strFileName)
        {//Delete file from the server
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }
        public void AssignPath(HyperLink hlp, string Path)
        {
            hlp.NavigateUrl = Path;
            hlp.Text = "View";
            hlp.Visible = true;
        }



        public string IncentiveFileUploading(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string EntprIncentive, string SubIncentiveID, string DocID, string CreatedUserID, string DocUploadedUserType)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = EntprIncentive + SubIncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, EntprIncentive + "\\" + SubIncentiveID + "\\" + DocID);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    Output = Gen.InsertIncentiveUploads(EntprIncentive, SubIncentiveID, DocID, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, null);
                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + EntprIncentive + "/" + SubIncentiveID + "/" + DocID + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }



        public string IncentiveFileUploadingfromDigilocker(string ShortFiledirectory, string FileDirectory, byte[] FileUploadDoc, HyperLink hlp, string Description, string EntprIncentive, string SubIncentiveID, string DocID, string CreatedUserID, string DocUploadedUserType, string Mimetype)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            try
            {
                string sFileDir = FileDirectory;

                // sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                string fileExtension = GetExtensionByContentType(Mimetype);//Path.GetExtension(sFileName);
                string Attachmentidnew = EntprIncentive + SubIncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                sFileName = Description + Attachmentidnew + fileExtension;

                newPath = System.IO.Path.Combine(sFileDir, EntprIncentive + "\\" + SubIncentiveID + "\\" + DocID);

                if (!Directory.Exists(newPath))
                    System.IO.Directory.CreateDirectory(newPath);
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                int count = dir.GetFiles().Length;
                if (count == 0)
                {
                    // FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    File.WriteAllBytes(Path.Combine(newPath, sFileName), FileUploadDoc);
                }
                else
                {
                    if (count == 1)
                    {
                        string[] Files = Directory.GetFiles(newPath);

                        foreach (string files in Files)
                        {
                            File.Delete(files);
                        }
                        //FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        File.WriteAllBytes(Path.Combine(newPath, sFileName), FileUploadDoc);
                    }
                }

                Output = Gen.InsertIncentiveUploads(EntprIncentive, SubIncentiveID, DocID, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, null);

                hlp.Text = "View";
                hlp.NavigateUrl = ShortFiledirectory + "/" + EntprIncentive + "/" + SubIncentiveID + "/" + DocID + "/" + sFileName;
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }

        public string IncentiveFileUploadingQuery(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string EntprIncentive, string SubIncentiveID, string DocID, string CreatedUserID, string DocUploadedUserType, string QueryId, string EnclTpeesign)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            try
            {

                string sFileDir = FileDirectory; 
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = EntprIncentive + SubIncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, EntprIncentive + "\\" + SubIncentiveID + "\\" + DocID);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    Output = Gen.InsertIncentiveUploads(EntprIncentive, SubIncentiveID, DocID, sFileName, newPath, Description, DocUploadedUserType, "", EnclTpeesign, CreatedUserID, QueryId);
                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + EntprIncentive + "/" + SubIncentiveID + "/" + DocID + "/" + sFileName;
                }
            }
            catch (Exception ex)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
                throw ex;
            }
            return Output.ToString();
        }

        public string GetExtensionByContentType(string contentType)
        {
            string strExtension = "unknown";
            switch (contentType)
            {
                case "image/jpg":
                    strExtension = ".jpg";
                    break;
                case "image/png":
                    strExtension = ".png";
                    break;
                case "application/pdf":
                    strExtension = ".pdf";
                    break;
                case "text/plain":
                    strExtension = ".txt";
                    break;
                default:
                    strExtension = "unknown";
                    break;
            }
            return strExtension;
        }

        public string CheckFileSize(FileUpload FileUploadDoc)
        {
            string errormsg = "";
            //if (FileUploadDoc.PostedFile.ContentLength > (1024 * 1024))
            //{
            //    errormsg = "The Uploaded File Size Should be Less Than or Equal to 1MB Only";
            //}
            return errormsg;
        }

        public string IncentiveFileUploadingPM(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string EntprIncentive, string SubIncentiveID, string DocID, string CreatedUserID, string DocUploadedUserType)
        {
            string Output = "";
            string newPath = "";
            string sFileName = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = EntprIncentive + SubIncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, EntprIncentive + "\\" + SubIncentiveID + "\\" + DocID);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        string[] Files = Directory.GetFiles(newPath);

                        //foreach (string files in Files)
                        //{
                        //    File.Delete(files);
                        //}
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    Output = Gen.InsertIncentiveUploadsPM(EntprIncentive, SubIncentiveID, DocID, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, null);
                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + EntprIncentive + "/" + SubIncentiveID + "/" + DocID + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }

        public string IncentiveProceedingsFileUploading(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string EntprIncentive, string SubIncentiveID, string DocID, string CreatedUserID, string DocUploadedUserType, string DLCNumber, string DLCDate, out string SavedFileLocation)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            SavedFileLocation = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = CreatedUserID + SubIncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, CreatedUserID + "Proceedings\\" + DLCNumber + "\\" + SubIncentiveID + "\\" + DocID);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    Output = Gen.InsertIncentiveProceedingsUploads(EntprIncentive, SubIncentiveID, DocID, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, DLCNumber, DLCDate);

                    SavedFileLocation = System.IO.Path.Combine(newPath, sFileName);

                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + CreatedUserID + "Proceedings/" + DLCNumber + "/" + SubIncentiveID + "/" + DocID + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }

        public string IncentiveSanctionLetterFileUploading(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string EntprIncentive, string SubIncentiveID, string DocID, string CreatedUserID, string DocUploadedUserType, string DLCNumber, string DLCDate, out string SavedFileLocation)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            SavedFileLocation = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = CreatedUserID + SubIncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + "_" + EntprIncentive + "_" + SubIncentiveID + "_" + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, CreatedUserID + "SanctionOrder\\" + DLCNumber + "\\" + EntprIncentive + "\\" + SubIncentiveID + "\\" + DocID);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    Output = Gen.InsertIncentiveProceedingsUploads(EntprIncentive, SubIncentiveID, DocID, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, DLCNumber, DLCDate);

                    SavedFileLocation = System.IO.Path.Combine(newPath, sFileName);

                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + CreatedUserID + "SanctionOrder/" + DLCNumber + "/" + EntprIncentive + "/" + SubIncentiveID + "/" + DocID + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }
        public string IncentivePartialProceedingsFileUploading(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string EntprIncentive, string SubIncentiveID, string DocID, string CreatedUserID, string DocUploadedUserType, string DLCNumber, string DLCDate, out string SavedFileLocation)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            SavedFileLocation = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = CreatedUserID + SubIncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, CreatedUserID + "PartialProceedings\\" + DLCNumber + "\\" + SubIncentiveID + "\\" + DocID);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    Output = Gen.InsertIncentiveProceedingsUploads(EntprIncentive, SubIncentiveID, DocID, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, DLCNumber, DLCDate);

                    SavedFileLocation = System.IO.Path.Combine(newPath, sFileName);

                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + CreatedUserID + "PartialProceedings/" + DLCNumber + "/" + SubIncentiveID + "/" + DocID + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }
        public string SlcFileUploading(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description,  string SlcNo, string DocID, string CreatedUserID, string DocUploadedUserType,string Type)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = SlcNo + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, SlcNo + "\\" + DocID);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    Output = Gen.InsertSlcFileUploading(SlcNo, DocID, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, null, Type);
                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + SlcNo + "/" + DocID + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }

        public string WorkSheetFileUploading(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string IncId, string SubIncId, string CreatedUserID, string DocUploadedUserType, string Type)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = IncId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, IncId + "\\" + SubIncId);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    Output = Gen.InsertWorkSheetFile(IncId, SubIncId, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, null, Type);
                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + IncId + "/" + SubIncId + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }

        public string DLOImageUploading(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string IncentiveID, string SubIncentiveId, string CreatedUserID, string DocUploadedUserType, string AttachmentId)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = IncentiveID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, IncentiveID + "\\" + SubIncentiveId);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    Output = Gen.InsertImageFileUploading(IncentiveID, SubIncentiveId, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID,AttachmentId);
                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + IncentiveID + "/" + SubIncentiveId + "/" + sFileName;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }
        public string BankerIdentification(string ShortFiledirectory, string FileDirectory, FileUpload FileUploadDoc, HyperLink hlp, string Description, string IncId, string SubIncId, string CreatedUserID, string DocUploadedUserType, string Type)
        {
            int Output = 0;
            string newPath = "";
            string sFileName = "";
            try
            {

                string sFileDir = FileDirectory;
                if (FileUploadDoc.HasFile && FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
                {
                    sFileName = System.IO.Path.GetFileName(FileUploadDoc.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(sFileName);
                    string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                    string Attachmentidnew = IncId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                    sFileName = Description + Attachmentidnew + fileExtension;

                    newPath = System.IO.Path.Combine(sFileDir, IncId + "\\" + SubIncId);

                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string files in Files)
                            {
                                File.Delete(files);
                            }
                            FileUploadDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    Output = Gen.InsertBankerIdentificationFile(IncId, SubIncId, sFileName, newPath, Description, DocUploadedUserType, "", "", CreatedUserID, null, Type);
                    hlp.Text = "View";
                    hlp.NavigateUrl = ShortFiledirectory + "/" + IncId + "/" + SubIncId + "/" + sFileName;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
            return Output.ToString();
        }
    }
}