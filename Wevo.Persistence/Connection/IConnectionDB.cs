using System;
using System.Data;

namespace Wevo.Persistence.Connection
{
    public interface IConnectionDB : IDisposable
    {
        IDbConnection OpenConnection();
        void CloseConnection();
    }
}
