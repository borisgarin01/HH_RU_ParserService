namespace Data.Repositories.Classes.Base;
public abstract class Repository
{
    public string ConnectionString { get; }
    protected Repository(string connectionString)
    {

        ConnectionString = connectionString;

    }
}
