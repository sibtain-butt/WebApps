using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppEShop.Model.Models
{
    public class CategoryModelClass
    {
        //[Key] //by-Default Id is primaryKey
        public int Id { get; set; }

        //[Required] //already used -> required <- in-line code
        [MaxLength(30)]
        public required string Name { get; set; }

        [Range(1, 100)]
        //[DisplayName("Display Order")]
        public required int DisplayOrder { get; set; }

    }

}
