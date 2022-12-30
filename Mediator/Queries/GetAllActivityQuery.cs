using MediatR;
using ActivitiesCQRS.Services;
using ActivitiesCQRS.Models;

namespace ActivitiesCQRS.Mediator.Queries
{
    public class GetAllActivityQuery : IRequest<IEnumerable<Activity>>
    {

        public class GetAllActivityQueryHandler : IRequestHandler<GetAllActivityQuery, IEnumerable<Activity>>
        {
            private readonly IActivityService _activityService;

            public GetAllActivityQueryHandler(IActivityService activityService)
            {
                _activityService = activityService;
            }

            public Task<IEnumerable<Activity>> Handle(GetAllActivityQuery request, CancellationToken cancellationToken)

            {
                IEnumerable<Activity> activities = _activityService.GetAll();



                return Task.FromResult(activities);
            }

        }
    }
}
