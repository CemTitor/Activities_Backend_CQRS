using ActivitiesCQRS.Models;
using ActivitiesCQRS.Data;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesCQRS.Services;

public class ActivityService : IActivityService
{

   
    private readonly ActivityContext _context;

    ///When the ActivityService instance is created, a ActivityContext will be injected as a dependency.


    public ActivityService(ActivityContext context)
    {
        _context = context;
    }

    public ActivityService()
    {

    }

    ///The Activitys collection contains all the rows in the Activitys table.

    ///All of the Activitys are returned with ToList.

    public IEnumerable<Activity> GetAll()
    {
        return _context.Activitys
            .AsNoTracking()
            .ToList();
    }

    public Activity? GetById(Guid id)
    {
        
        return _context.Activitys
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    ///The Add method adds the newActivity entity to EF Core's object graph.
    public Activity Create(Activity newActivity)
    {
        _context.Activitys.Add(newActivity);
        _context.SaveChanges();

        return newActivity;
    }

    public Activity? DeleteById(Guid id)
    {
        ///The Find method retrieves a 
        ///Activity by the primary key (in this case, Id).

        var ActivityToDelete = _context.Activitys.Find(id);
        if (ActivityToDelete is not null)
        {
            _context.Activitys.Remove(ActivityToDelete);
            _context.SaveChanges();
            
        }
        return ActivityToDelete;
    }

    public Activity? Update(Activity updatedActivity)
    {
        _context.Activitys.Update(updatedActivity);
        _context.SaveChanges();

        return updatedActivity;
    }

   
}