using MediatR;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class Create 
    {
        public class Command : IRequest{
            public Activity newActivity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
        
        public Handler(DataContext context){
            _context = context;
            
        }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                 _context.Activities.Add(request.newActivity);
                 await _context.SaveChangesAsync();
                 return Unit.Value;
            }
        }
    }
}