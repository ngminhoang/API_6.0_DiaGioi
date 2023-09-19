using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_2.DBcontext
{
    [Table("Huyen")]
    public class Huyen
    {
        public Huyen() { }
        [Key, Required]
        public int Hid { get; set; }
        public string Hname { get; set; }
        public string Hdes { get; set;}
        [ForeignKey("Tinh")]
        public int Tid { get; set; }
        public virtual Tinh Tinh { get; set; }
    }
}
