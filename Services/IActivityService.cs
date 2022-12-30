using ActivitiesCQRS.Models;

namespace ActivitiesCQRS.Services
{
    public interface IActivityService
    {
        Activity Create(Activity newActivity);
        Activity? DeleteById(Guid id);
        IEnumerable<Activity> GetAll();
        Activity? GetById(Guid id);
        Activity? Update(Activity activity);
    }
}
