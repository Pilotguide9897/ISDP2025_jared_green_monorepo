using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Helpers
{
    public class ImageManipulation
    {
        public static string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string imagesFolder = Path.Combine(projectPath, "ImagesFolder");
        public static string CopyImageToFolder(OpenFileDialog ofd)
        {
            try
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }
                    File.SetAttributes(imagesFolder, FileAttributes.Normal);
                    var fileTitle = ofd.FileName.Split("\\");
                    File.Copy(ofd.FileName, Path.Combine(imagesFolder, fileTitle[fileTitle.Length -1]), true);
                    return fileTitle[fileTitle.Length - 1];
                }
                return "";

            } catch (Exception ex)
            {
                return "";  
            }

        }
    }
}
