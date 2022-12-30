using ActivitiesCQRS.Data;
using ActivitiesCQRS.Models;
using ActivitiesCQRS.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ActivitiesCQRS.Mediator.Commands
{
    public class CreateActivityCommand : IRequest<Activity>
    {
        public string? Title { get; set; }

        public DateTime? Date { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? City { get; set; }

        public string? Venue { get; set; }


        public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Activity>
        {

            private readonly IActivityService _activityService;

            public CreateActivityCommandHandler(IActivityService activityService)
            {
                _activityService = activityService;
            }

            public Task<Activity> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
            {
               
                    var activity = new Activity()
                    {
                        Id = Guid.NewGuid(),
                        Title = request.Title,
                        Date = DateTime.UtcNow,
                        Description = request.Description,
                        Category = request.Category,
                        City = request.City,
                        Venue = request.Venue
                    };
                    Activity result = _activityService.Create(activity);
                    return Task.FromResult(result);
                
                
            }
        }
       
    }
}
