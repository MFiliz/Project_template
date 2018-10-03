using System;

namespace Fountain.Domain.BaseClass
{
    public abstract class BaseDomain
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean IsActive { get; set; }
    }
}