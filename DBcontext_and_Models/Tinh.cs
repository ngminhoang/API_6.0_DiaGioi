using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_2.DBcontext
{
    [Table("Tinh")]
    public class Tinh
    {
        public Tinh() { }
        [Key, Required]
        public int Tid { get; set; }
        public string Tname { get; set; }
        public string Tdes { get; set; }
    }
}
