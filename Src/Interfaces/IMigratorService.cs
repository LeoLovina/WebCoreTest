namespace WebCoreTest.Interfaces
{
    public interface IMigratorService
    {
        string MigrateUp();
        string MigrateDown(long version);
    }
}
