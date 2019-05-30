using System.Linq;
using Wevo.Infrastructure.CrossCutting.Utilities.Extension;

namespace Wevo.Infrastructure.CrossCutting.Utilities
{
    public static class SequenceHelper
    {
        public static string GetSequenceName<T>(T entity)
        {
            return ((SqlFilter)entity.GetType().GetCustomAttributes(typeof(SqlFilter), true).First()).SequenceName;
        }
    }
}
