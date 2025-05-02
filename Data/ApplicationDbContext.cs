using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC2Programacion.Models;
using System.Collections.Generic;


namespace PC2Programacion.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {  
    }

    public DbSet<Pet> DbSetPet { get; set; }
    public DbSet<Adopter> DbSetAdopter { get; set; }
    public DbSet<Adoption> DbSetAdoption { get; set; }
}
