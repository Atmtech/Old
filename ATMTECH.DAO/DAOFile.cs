using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOFile : BaseDao<File, int>, IDAOFile
    {

        public IList<File> Files
        {
            get
            {
                if (ContextSessionManager.Context.Session["File"] == null)
                {
                    ContextSessionManager.Context.Session["File"] = GetAllActive();
                }
                return (IList<File>)ContextSessionManager.Context.Session["File"];
            }
            set
            {
                if (ContextSessionManager.Context.Session["File"] == null || value == null)
                    ContextSessionManager.Context.Session["File"] = value;
            }
        }

        public IList<File> GetFileByFileType(FileType fileType)
        {
            //return GetAllOneCriteria(File.FILE_TYPE, fileType.Id.ToString());
            return Files.Where(x => x.FileType.Id == fileType.Id).ToList();
        }
        public File GetFile(int id)
        {
            return Files.FirstOrDefault(x => x.Id == id);
            //return GetById(id);
        }

        public File GetFile(File file)
        {
            IList<File> files = Files.Where(x => x.FileName == file.FileName).ToList();
            //IList<File> files = GetAllOneCriteria(File.FILE_NAME, file.FileName);
            return files.Count > 0 ? files[0] : null;
        }

        public File GetFileByFileName(string fileName)
        {
            IList<File> files = Files.Where(x => x.FileName == fileName).ToList();
            //IList<File> files = GetAllOneCriteria(File.FILE_NAME, fileName);
            return files.Count > 0 ? files[0] : null;
        }

        public IList<File> GetAllFile()
        {
            return Files;
            //return GetAllActive();
        }

        public void DeleteFile(File file)
        {
            Files = null;
            ExecuteSql("DELETE FROM [File] WHERE Id = " + file.Id.ToString());
            ExecuteSql("DELETE FROM ProductFile Where [File] = " + file.Id.ToString());
        }

        public int UpdateFile(File file)
        {
            Files =null;
            return Save(file);
        }
    }
}
