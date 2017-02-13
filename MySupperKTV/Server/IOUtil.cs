using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public class IOUtil
    {
        /// <summary>
        /// 文件及文件夹数量
        /// </summary>
        private int filesCount;
        /// <summary>
        /// 完成数量
        /// </summary>
        public int overCount;
        private string dirPath;
        /// <summary>
        /// 文件及文件夹总数量，此属性全局记录，使用后必须手动清空！
        /// </summary>
        public int FilesCount
        {
            get
            {
                return filesCount;
            }

            set
            {
                filesCount = value;
            }
        }
        /// <summary>
        /// 目录路径
        /// </summary>
        public string DirPath
        {
            get
            {
                return dirPath;
            }

            set
            {
                dirPath = value;
            }
        }
        /// <summary>
        /// 传入要转移过去的目录路径
        /// </summary>
        /// <param name="dirPath"></param>
        public IOUtil(string dirPath)
        {
            this.dirPath = dirPath;
        }
        /// <summary>
        /// 根据目录获取文件的数量
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public void GetDirFilesNum(string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            filesCount += dir.GetFiles().Count();
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                filesCount++;
                GetDirFilesNum(dirInfo.FullName);
            }
        }
        /// <summary>
        /// 删除目录及文件
        /// </summary>
        /// <param name="text">要删除的目录</param>
        /// <param name="progressBar1">更新的进度条</param>
        public void DeleteDirectory(string text, ProgressBar progressBar)
        {
            DirectoryInfo dir = new DirectoryInfo(text);
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
                overCount++;
                // 计算更新进度条
                double percent1 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                progressBar.Value = (int)(100 * percent1) / 2;//求出值
            }
            foreach (DirectoryInfo item in dir.GetDirectories())
            {
                //如果目录下有文件
                if (item.GetFiles().Count()>0)
                {
                    DeleteDirectory(item.FullName, progressBar);
                }
                item.Delete();
                overCount++;
                // 计算更新进度条
                double percent0 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                progressBar.Value = (int)(100 * percent0) / 2;//求出值
            }
        }

        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="srcdir"></param>
        /// <param name="desdir"></param>
        public void CopyDirectory(string srcdir, string desdir, ProgressBar progressBar)
        {
            string folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);

            string desfolderdir = desdir + "\\" + folderName;

            if (desdir.LastIndexOf("\\") == (desdir.Length - 1))
            {
                desfolderdir = desdir + folderName;
            }
            string[] filenames = Directory.GetFileSystemEntries(srcdir);

            foreach (string file in filenames)// 遍历所有的文件和目录
            {
                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {

                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                        overCount++;
                        // 计算更新进度条
                        double percent0 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                        progressBar.Value = (int)(100 * percent0) / 2;//求出值
                    }
                    //计算更新进度条
                    double percent1 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                    progressBar.Value = (int)(100 * percent1) / 2;//求出值
                    CopyDirectory(file, desfolderdir, progressBar);
                }

                else // 否则直接copy文件
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                    srcfileName = desfolderdir + "\\" + srcfileName;


                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                        overCount++;
                        //计算更新进度条
                        double percent2 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                        progressBar.Value = (int)(100 * percent2) / 2;//求出值
                    }
                    File.Copy(file, srcfileName);
                    overCount++;
                    //计算更新进度条
                    double percent3 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                    progressBar.Value = (int)(100 * percent3) / 2;//求出值
                }
            }//foreach 
        }//function end 
    }
}
