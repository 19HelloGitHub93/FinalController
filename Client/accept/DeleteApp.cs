using System;
using System.IO;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Client.accept
{
    public class DeleteApp:IAccept
    {
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.DeleteApp)
            {
                try
                {
                    string path = data.msg;
                    
                    if (Directory.Exists(path))
                    {
                        DeleteDir(path);
                    }
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch (Exception e)
                {
                    LogUtil.Error(e.Message);
                }
                
            }
        }

        private void DeleteDir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)  
                {
                    DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                    subdir.Delete(true);     
                } 
                else
                {
                    File.Delete(i.FullName);     
                }
            }
            
            dir.Delete(true);
        }
    }
}