using System;
using ArchitectureCeA.Data;

namespace ArchitectureCeA.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ArchitectureCeAEntities Get();
    }
}
