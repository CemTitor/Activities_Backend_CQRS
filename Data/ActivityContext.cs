using Microsoft.EntityFrameworkCore;
using ActivitiesCQRS.Models;

namespace ActivitiesCQRS.Data;

public class ActivityContext : DbContext
{
    public ActivityContext(DbContextOptions<ActivityContext> options)
        : base(options)
    {
    } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }


    public DbSet<Activity> Activitys { get; set; }




}