using System.Diagnostics;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
            public DateTime? Date { get; set; }
            public string Description { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext context)
            {
                _dataContext = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities.FindAsync(request.Id);
                if(activity == null)
                {
                    throw new Exception("Item not found.");
                }
                activity.Title = request.Title ?? activity.Title;
                activity.Category = request.Category ?? activity.Category;
                activity.Venue = request.Venue ?? activity.Venue;
                activity.City = request.City ?? activity.City;
                activity.Description = request.Description ?? activity.Description;
                activity.Date = request.Date ?? activity.Date;

                var success = await _dataContext.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Unable to solve changes");
            }
        }
    }
}