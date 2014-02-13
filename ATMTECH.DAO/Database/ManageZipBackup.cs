using System;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace ATMTECH.DAO.Database
{
    public class ManageZipBackup
    {
        public void CreateZipFile(string zipFile)
        {
            if (File.Exists(zipFile))
            {
                File.Delete(zipFile);
            }

            string path = Path.GetDirectoryName(zipFile);
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(path);
                zip.Save(zipFile);
            }

            string[] extensionFilters = new[] { ".xml" };
            String[] files = Directory.GetFiles(path).Where(filename => extensionFilters.Any(x => filename.EndsWith(x, StringComparison.OrdinalIgnoreCase))).ToArray();

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
        public void UnzipFile(string zipFile)
        {
            string path = Path.GetDirectoryName(zipFile);

            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(path, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
