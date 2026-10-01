using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdnLesson12.Models
{
    [Table("PdnProduct")]
    public class PdnProduct
    {
        [Key]
        public int PdnId { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm không được vượt quá 150 ký tự")]
        [Column(TypeName = "nvarchar(150)")]
        public string PdnName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string PdnImage { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public float PdnPrice { get; set; }

        public float PdnSalePrice { get; set; }
        public byte PdnStatus { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả sản phẩm không được vượt quá 1000 ký tự")]
        [Column(TypeName = "ntext")]
        public string PdnDescription { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        public int PdnCategoryId { get; set; }

        public DateTime CreatedDate { get; set; }
        public PdnCategory PdnCategory { get; set; }

    }   
}