using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdnLesson12.Models
{
    [Table("PdnCategory")]
    public class PdnCategory
    {
        [Key]
        public int PdnId { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        public string PdnName { get; set; }
        [Column(TypeName = "tinyint")]
        public byte PdnStatus { get; set; }
            
        public DateTime CreatedDate { get; set; }

        public ICollection<PdnProduct>? PdnProducts { get; set; }
    }
}
