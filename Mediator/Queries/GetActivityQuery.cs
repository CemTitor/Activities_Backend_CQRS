using MediatR;
using System;
using ActivitiesCQRS.Models;
using ActivitiesCQRS.Services;

namespace ActivitiesCQRS.Mediator.Queries
{
    public class GetActivityByIdQuery : IRequest<Activity>
    {
        public Guid Id { get; set; }

        public class GetActivityByIdQueryHandler : IRequestHandler<GetActivityByIdQuery, Activity>
        {

            private readonly IActivityService _activityService;

            public GetActivityByIdQueryHandler(IActivityService activityService)
            {
                _activityService = activityService;
            }
            public Task<Activity> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
            {

                Activity activity = _activityService.GetById(request.Id);

            
                return Task.FromResult(activity);

            
            }
        }

    }
}
