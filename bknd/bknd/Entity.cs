using System;

namespace bknd
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}