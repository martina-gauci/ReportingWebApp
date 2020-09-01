using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace NEMESYS.Models{
    public class NemesysContext : DbContext{ //This inheritance specifies that we are using EF Core

        //In the parameter we have to pass which database provider we are using and the corresponding connection string
        //To pass a value to this parameter, dependency injection is used
        public NemesysContext(DbContextOptions<NemesysContext> options) : base(options){
        }

        //We are using just one context class for all the model classes, since all are related to each other
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Investigation> Investigations { get; set; }
        public DbSet<Upvote> Upvotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Setting composite key of Upvote table
            modelBuilder.Entity<Upvote>()
                .HasKey(upvote => new { upvote.ReportId, upvote.UserId });

            //If we delete a row, we don't want to delete rows related to it in other tables (cascading deletes)
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }//end of NemesysContext class
}//end of namespace class
