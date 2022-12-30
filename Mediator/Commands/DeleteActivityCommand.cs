using ActivitiesCQRS.Services;
using MediatR;
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
    public class DeleteActivityCommand : IRequest<Activity>
    {
        public Guid Id { get; set; }

        public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Activity>
        {
            private readonly IActivityService _activityService;

            public DeleteActivityCommandHandler(IActivityService activityService)
            {
                _activityService = activityService;
            }

            public Task<Activity> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
            {
                Activity activity = _activityService.DeleteById(request.Id);
                return Task.FromResult(activity);
            }

            //public void Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
            //{
            //    _activityService.DeleteById(request.Id);
            //}
        }
    }
}



