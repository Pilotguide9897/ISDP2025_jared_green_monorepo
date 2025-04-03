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
        public static string webAppPath = @"C:\NBCC\ISDP2025_jared_green_monorepo\web-app\ISDP2025_jared_green\ISDP2025_jared_green_web.Server\wwwroot\Images";

        public static string CopyImageToFolder(OpenFileDialog ofd, int itemID)
        {
            try
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!Directory.Exists(imagesFolder))
                        Directory.CreateDirectory(imagesFolder);

                    File.SetAttributes(imagesFolder, FileAttributes.Normal);

                    var fileName = Path.GetFileName(ofd.FileName);
                    var localPath = Path.Combine(imagesFolder, fileName);
                    File.Copy(ofd.FileName, localPath, true);

                    // Also copy to web app folder
                    //var webImagePath = Path.Combine(webAppPath, fileName);
                    var webImagePath = Path.Combine(webAppPath, $"{ itemID }.png");
                    if (!Directory.Exists(webAppPath))
                        Directory.CreateDirectory(webAppPath);

                    File.Copy(ofd.FileName, webImagePath, true);

                    return fileName;
                }

                return "";
            }
            catch (Exception ex)
            {
                // Optional: log error
                return "";
            }
        }
        }
}
