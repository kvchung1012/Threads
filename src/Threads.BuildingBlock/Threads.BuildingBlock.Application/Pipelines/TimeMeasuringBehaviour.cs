using MediatR;
using Serilog;
using System.Diagnostics;

namespace Threads.BuildingBlock.Application.Pipelines
{
    public class TimeMeasuringBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public TimeMeasuringBehaviour()
        {
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
        {
            var stopWatch = Stopwatch.StartNew();
            var result = await next.Invoke();
            var timeSpent = stopWatch.ElapsedMilliseconds;
            Log.Information("Execute request: {@RequestName} spent: {@TimeSpent} ms!", typeof(TRequest).Name, timeSpent);
            return result;
        }
    }
}
