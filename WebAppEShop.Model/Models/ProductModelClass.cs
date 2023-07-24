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
        //[Required] // if i use this [Required] then why i also need to add inline "required"
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public string? Author { get; set; }
        
        //[DisplayName("List Price")] // both syntax are same to show display name
        [Display(Name ="List Price")]
        [Range(1, 1000)]
        public double? ListPrice { get; set; }
        
        [DisplayName("Price for 1-50")]
        [Range(1, 1000)]
        public double? Price { get; set; }
        
        [DisplayName("Price for 50+")]
        [Range(1, 1000)]
        public double? Price50 { get; set; }
        
        [DisplayName("Price for 100+")]
        [Range(1, 1000)]
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
