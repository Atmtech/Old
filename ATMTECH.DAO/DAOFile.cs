using System.Collections.Generic;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOFile : BaseDao<File, int>, IDAOFile
    {
        public IList<File> GetFileByFileType(FileType fileType)
        {
           return GetAllOneCriteria(File.FILE_TYPE, fileType.Id.ToString());
        }
        public File GetFile(int id)
        {
            return GetById(id);
        }

        public File GetFile(File file)
        {
            IList<File> files = GetAllOneCriteria(File.FILE_NAME, file.FileName);
            return files.Count > 0 ? files[0] : null;
        }

        public File GetFileByFileName(string fileName)
        {
            IList<File> files = GetAllOneCriteria(File.FILE_NAME, fileName);
            return files.Count > 0 ? files[0] : null;
        }

        public IList<File> GetAllFile()
        {
            return GetAllActive();
        }

        public void DeleteFile(File file)
        {
            file.IsActive = false;
            Save(file);
        }

        public int UpdateFile(File file)
        {
            return Save(file);
        }
    }
}
