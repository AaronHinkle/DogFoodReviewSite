using Microsoft.EntityFrameworkCore;
using Misfits.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misfits.Models.Data
{
    public class DogFoodModel
    {
        [Key]

        public int Id { get; set; }

        public string DogFoodName { get; set; }


        public string Description { get; set; }

        public string ImageURL { get; set; }

        public string Ingredients { get; set; }

        public string ProductionCompany { get; set; }

        public virtual IEnumerable<ReviewModel>? Reviews { get; set; }

    }
}
