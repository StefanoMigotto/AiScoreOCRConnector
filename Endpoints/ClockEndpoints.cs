using AiScoreOCRConnector.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AiScoreOCRConnector.Endpoints
{
    public static class ClockEndpoints
    {
        public static Clock CurrentClock { get; set; }
        public static IEndpointRouteBuilder MapClockEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/clock");

            group.MapGet("/", GetDataClock);
            group.MapPost("/", InsertDataClock);

            return app;
        }
        public static Results<Ok<Clock>, ProblemHttpResult> GetDataClock()
        {
            return TypedResults.Ok(CurrentClock);
        }
        public static void InsertDataClock([FromBody]Clock payload)
        {
            CurrentClock = payload;
        }
    }
}
