using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOFile
    {
        IList<File> GetFileByFileType(FileType fileType);
        File GetFile(int id);
        IList<File> GetAllFile();
        void DeleteFile(File file);
        int UpdateFile(File file);
        File GetFile(File file);
        File GetFileByFileName(string fileName);
        void DeleteAll();
    }
}
