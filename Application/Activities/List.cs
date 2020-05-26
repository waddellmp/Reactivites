using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    /*
        List Overview
        
        The List class following the CQRS (command-query-responsibility-segregation) pattern.
        
        Query
        A class member that implements the mediator interface IRequest<T>. Forms the query part
        of the CQRS pattern.

        Handler
        A class member that implements the mediator interface IRequestHandler<Query, List<Activity>>. This forms the 
        request handler for the query handling.

            Handle(Query request, Cancellation ct)
            A method used to pass in the Query instance and ct and return the result.
        
            Requires params:
                Query request
                CancellationToken ct
    */
    public class List
    {
        // IRequest<T> returns a value
        public class Query : IRequest<List<Activity>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler (DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }
            public async Task<List<Activity>> Handle (Query request, CancellationToken ct)
            {
                var activities = await _context.Activities.ToListAsync ();
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
