using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public interface IBaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //TODO
        //public User CreatedBy { get; set; }
        //public User UpdatedBy { get; set; }
    }
}
