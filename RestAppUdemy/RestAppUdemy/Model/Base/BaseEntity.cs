using System.ComponentModel.DataAnnotations.Schema;

namespace RestAppUdemy.Model.Base
{
    //[DataContract]
    public class BaseEntity
    {
        [Column("Id")]
        public long? Id { get; set; }
    }
}
