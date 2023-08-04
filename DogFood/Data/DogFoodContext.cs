using Microsoft.EntityFrameworkCore;
using Misfits.Models.Data;
using System;
namespace DogFood.Data;

public class DogFoodContext : DbContext
{
	public DbSet<DogFoodModel> DogFoods { get; set; }

	public DbSet<ReviewModel>Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DogFoodLibrary7;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    //hello 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<DogFoodModel>().HasData(
            new DogFoodModel()
            {
                Id = 1,
                DogFoodName = "Purina Pro Plan: Chicken and Rice Recipe",
                Description = "Chicken Recipe, made with love",
                Ingredients = "Chicken, Rice, Whole Grain Wheat, Poultry By-Product, Soybean Meal",
                ImageURL = "https://s7d2.scene7.com/is/image/PetSmart/5135727?$CLEARjpg$",
                ProductionCompany = "Purina",
                

                //hello 

            },

            new DogFoodModel()
            {
                Id = 2,
                DogFoodName = "Canidae: Salmon and Sweet Potato",
                Description = "Candiae, also made with love",
                Ingredients = "Salmon, Barley, Salmon Meal, Lentils, Sweet Potato, Garbanzo beans",
                ImageURL = "https://img.cdn4dd.com/cdn-cgi/image/fit=contain,width=1200,height=672,format=auto/https://doordash-static.s3.amazonaws.com/media/photosV2/478f1454-4f23-43f0-96b9-d68b45008397-retina-large.jpg",
                ProductionCompany = "Canidae",
                
            },
            new DogFoodModel()
            {
                Id = 3,
                DogFoodName = "4Health: Salmon and Potato",
                Description = "Keep your dog healthy, happy and full with the 4health with Wholesome Grains Adult Salmon and Potato Formula Dry Dog Food. The wholesome, carefully selected ingredients provide optimal nutrition for adult dogs of any breed",
                Ingredients = "Salmon, ocean fish meal, potatoes, peas, cracked pearled barley, pea flour, egg product, canola oil",
                ImageURL = "https://media.tractorsupply.com/is/image/TractorSupplyCompany/1424210?wid=456&hei=456&fmt=jpeg&qlt=100,0&resMode=sharp2&op_usm=0.9,1.0,8,0",
                ProductionCompany = "Diamond Pet Foods Inc",
                
            });
        modelBuilder.Entity<ReviewModel>().HasData(
            new ReviewModel()
            {
                Id = 1,
                ReviewerName = "Steve Smith",
                Review = "This dog food sucks, it killed my dog!",
                DogFoodModelId = 1
             
            },
            new ReviewModel()
            {
                Id = 2,
                ReviewerName = "Roger Rabbit",
                Review = "This dog food is the best, it brought my dog back to life!",
                DogFoodModelId = 2
            },
            new ReviewModel()
            {
                Id = 3,
                ReviewerName = "Tim Horton",
                Review = "My vet says potatoes are a Very Common allergy.My dogs now have bald spots.",
                DogFoodModelId = 3
            },
            new ReviewModel()
            {
                Id = 4,
                ReviewerName = "Jackass666",
                Review = "When the bag got delivered to the house, it had a RIP in it, and the DOG FOOD WAS REAL CRUNMBLY it just looked like it was STALE.",
                DogFoodModelId = 1
            });






    }


}
