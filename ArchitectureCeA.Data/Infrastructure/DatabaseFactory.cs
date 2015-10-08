using ArchitectureCeA.Data;

namespace ArchitectureCeA.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private ArchitectureCeAEntities dataContext;
    public ArchitectureCeAEntities Get()
    {
        return dataContext ?? (dataContext = new ArchitectureCeAEntities());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
