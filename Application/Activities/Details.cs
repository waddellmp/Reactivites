using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id  { get; set; }

            public class Handler : IRequestHandler<Query, Activity>
            {
                private readonly DataContext _context;
                
                private readonly ILogger<List> _logger;

                public Handler(DataContext context, ILogger<List> logger)
                {
                    _context = context;
                    _logger = logger;
                }
                public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
                {
                    var activity = await _context.Activities.FindAsync(request.Id);
                    return activity;
                }
            }
        }
    }
}