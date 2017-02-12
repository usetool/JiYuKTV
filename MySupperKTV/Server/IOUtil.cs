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
        private int overCount;
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
        /// 转移目录下的文件及目录，更新progressBar中进度值
        /// </summary>
        /// <param name="progressBar">进度条对象</param>
        /// <param name="formPath">源路径</param>
        /// <param name="toPath">目标路径</param>
        /// <param name="concatPath">拼接的路径</param>
        public void UpdateProgressBar(ProgressBar progressBar, string formPath, string toPath, string concatPath)
        {
            string tempPath = concatPath;//当前目录结构的路径
            int okNum = 0;//完成的数量

            DirectoryInfo dir = new DirectoryInfo(formPath);
            //复制目录下的文件到目标
            foreach (FileInfo fileInfo in dir.GetFiles())
            {
                fileInfo.CopyTo(toPath + tempPath + fileInfo.Name);
                okNum++;
                //计算更新进度条
                double percent = Convert.ToDouble(okNum) / filesCount;//计算出分数
                progressBar.Value = (int)(100 * percent);//求出值
            }
            //复制目录下的目录到目标
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                Directory.CreateDirectory(toPath + tempPath + dirInfo.Name);
                concatPath += dirInfo.Name + "\\";
                okNum++;
                //计算更新进度条
                double percent = Convert.ToDouble(okNum) / filesCount;//计算出分数
                progressBar.Value = (int)(100 * percent)/2;//求出值
                                                         //递归目录更新
                UpdateProgressBar(progressBar, dirInfo.FullName, toPath, concatPath);
            }
        }

        public void DeleteDirectory(string text, ProgressBar progressBar1)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="srcdir"></param>
        /// <param name="desdir"></param>
        public void CopyDirectory(string srcdir, string desdir,ProgressBar progressBar)
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
                        
                    }
                    //计算更新进度条
                    double percent1 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                    progressBar.Value = (int)(100 * percent1)/2;//求出值
                    CopyDirectory(file, desfolderdir,progressBar);
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
                        progressBar.Value = (int)(100 * percent2)/2;//求出值
                    }


                    File.Copy(file, srcfileName);
                    overCount++;
                    //计算更新进度条
                    double percent3 = Convert.ToDouble(overCount) / filesCount;//计算出分数
                    progressBar.Value = (int)(100 * percent3)/2;//求出值
                }
            }//foreach 
        }//function end 
    }
}
