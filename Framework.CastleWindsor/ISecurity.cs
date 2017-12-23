using System.Collections.Generic;

namespace Framework.CastleWindsor
{
    public interface ISecurity
    {
        IEnumerable<string> GetUserGroup(long userId);
    }
}
