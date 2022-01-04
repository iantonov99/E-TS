using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TS.Data.Models
{
    public class TransportLines
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        [ForeignKey("TransportType")]
        public virtual int TransportTypeId { get; set; }

        public virtual TransportType TransportType { get; set; }
    }
}
