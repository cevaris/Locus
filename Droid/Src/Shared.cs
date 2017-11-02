using System;

namespace Locus.Droid
{
    public class Shared : IShared
    {
        public Location GetLocation()
        {
            return new Location();
        }
    }
}
