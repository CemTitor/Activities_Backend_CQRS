namespace ActivitiesCQRS.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ActivityContext>();
                ///EnsureCreated creates a new database if one doesn't exist. 
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
            }
        }
    }
}