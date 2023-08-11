using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppEShop.Model.Models
{
    public class ProductModelClass
    {
        //[Key] //by-Default Id is primaryKey
        public int Id { get; set; }
        [Required] // if i use this [Required] then why i also need to add inline "required"
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public string? Author { get; set; }
        
        //[DisplayName("List Price")] // both syntax are same to show display name
        [Required, Display(Name ="List Price"), Range(1,1000)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double? ListPrice { get; set; }
        //ListPrice.ToString("C") is changed to this ->
        //line->    @String.Format("{0:C}", Model.ListPrice) e.g. $123.45
        
        [Required, DisplayName("Price for 1-50"), Range(1, 1000)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double? Price { get; set; }

        [Required]
        [DisplayName("Price for 50+")]
        //[RegularExpression(@"^\$(\d{1,3},?(\d{3},?)*\d{3}(\.\d{0,2})|\d{1,3}(\.\d{2})|\.\d{2})$", ErrorMessage = "Invalid price format by regex")]
        [Range(1, 1000)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double? Price50 { get; set; }

        [Required]
        [DisplayName("Price for 100+")]
        [Range(1, 1000)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double? Price100 { get; set; }
        
        public string? ImageUrl { get; set; } // i replacing required with nullcheck?

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        //FK should not be repeat and should match CategoryId like 1015,1016.. so on.
        //but check the seed CategoryId data has only 3 ids like 1,2,3 this make conflicts
        //with foreign key
        //Solve: i remove this error either Create a new table CatetegoryTable OR 
        //(worked) Delete all the data inside CategoryTable then i run the command
        //add-migration AddForeignKeyOfCategoryIdInProductTable => No Errors
        //update-database => No Errors
        public CategoryModelClass? CategoryModelClass { get; set; }

    }
}
