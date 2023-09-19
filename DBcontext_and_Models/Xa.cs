using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_6._0_2.DBcontext
{
    [Table("Xa")]
    public class Xa
    {
        
        [Key, Required]
        public int Xid { get; set; }
        public string Xname { get; set; }
        public string Xdes { get; set; }
        [ForeignKey("Huyen")]
        public int Hid { get; set; }
        public virtual Huyen Huyen { get; set; }
    }
}
