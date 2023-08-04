using Microsoft.EntityFrameworkCore;
using Misfits.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misfits.Models.Data

{
    public class ReviewModel
    {
        [Key]
        ///

        public int Id { get; set; }

        public string? ReviewerName { get; set; }

        public string? Review { get; set; }

        public int DogFoodModelId { get; set; }

    }
}
