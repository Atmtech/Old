namespace ATMTECH.Services.Interface
{
    public interface IDatabaseService
    {
        string ExecuteSql(string sql, EnumDatabaseVendor enumDatabaseVendor);
        string CreateMssqlBackup(string BackUpLocation, string BackUpFileName, string DatabaseName);
        string RestoreMssqlBackup(string BackUpLocation, string BackUpFileName, string DatabaseName);
        string GetServerName();
        string RestaurerFichierSauvegarde(string fichier, string nomBaseDonnee);
        string CreationFichierSauvegarde(string repertoireSauvegarde, string nomBaseDonnee);
    }
    public enum EnumDatabaseVendor
    {
        Mssql = 1
    }
}
