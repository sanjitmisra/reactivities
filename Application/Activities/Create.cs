using System.Diagnostics;
using System.Threading;
using System;
using MediatR;
using System.Threading.Tasks;
using Persistence;
using Domain;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
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
                var activity = new Domain.Activity 
                {
                    Id = request.Id,
                    Title = request.Title,
                    Category = request.Category,
                    City = request.City,
                    Date = request.Date,
                    Description = request.Description,
                    Venue = request.Venue
                };
                _dataContext.Activities.Add(activity);
                var success = await _dataContext.SaveChangesAsync() > 0;
                
                if(success) return Unit.Value;

                throw new Exception("Unable to solve changes");
            }
        }

    }
}