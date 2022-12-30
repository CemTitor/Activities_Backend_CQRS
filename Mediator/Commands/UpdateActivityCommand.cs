using ActivitiesCQRS.Services;
using MediatR;
using ActivitiesCQRS.Models;


namespace ActivitiesCQRS.Mediator.Commands
{
    public class UpdateActivityCommand : IRequest<Activity>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }

        public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Activity>
        {
            private readonly IActivityService _activityService;

            public UpdateActivityCommandHandler(IActivityService activityService)
            {
                _activityService = activityService;
            }

            public Task<Activity> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
            {

                var activity = new Activity()
                {
                    Id = request.Id,
                    Title = request.Title,
                    Date = DateTime.UtcNow,
                    Description = request.Description,
                    Category = request.Category,
                    City = request.City,
                    Venue = request.Venue
                };

                Activity result = _activityService.Update(activity);
                return Task.FromResult(result);
                
            }
        }
    }
}


