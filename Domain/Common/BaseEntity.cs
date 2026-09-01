using System;

namespace EasyReach_Domain.Common
{
    /// <summary>
    /// Shob entity er jonno common base class.
    /// Primary key (Id) ekhane thakbe.
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
