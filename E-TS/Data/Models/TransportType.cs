using System.ComponentModel.DataAnnotations;

namespace E_TS.Data.Models
{
    public class TransportType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

    }
}
