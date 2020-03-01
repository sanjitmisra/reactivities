using System;
using System.Threading;
using MediatR;
using System.Collections.Generic;
using Domain;
using System.Threading.Tasks;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {

        }

        //public class NotificationHandler : INotificationHandler

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext context)
            {
                _dataContext = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _dataContext.Activities.ToListAsync();
                return activities;
            }
        }
    }
}