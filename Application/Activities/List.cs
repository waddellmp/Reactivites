using System;
using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
    public class List
    {
        // To work with List, you will create an instance of the class member Query. Then pass it to mediator Send()
        // The Send() method will invoke the Handler method, which returns a list of Activities
        public class Query : IRequest<List<Activity>> 
        {
            
        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            
            private readonly ILogger<List> _logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken ct)
            {
                var activities = await _context.Activities.ToListAsync();
                // Testing out CancellationToken Implementation
                // try
                // {
                //     for (var i = 0; i < 10; i++)
                //     {
                //         ct.ThrowIfCancellationRequested();
                //         await Task.Delay(1000, ct);
                //         _logger.LogInformation($"Task {i} has completed");
                //     }
                // }
                // catch (Exception ex) when (ex is TaskCanceledException)
                // {
                //     _logger.LogInformation("Task was cancelled");
                // }
                return activities;
            }
        }
    }
}