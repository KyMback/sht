using System;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    [Flags]
    public enum TrackedEntityStates
    {
        Added = 0b1,
        Modified = 0b10,
        Deleted = 0b100,
    }
}