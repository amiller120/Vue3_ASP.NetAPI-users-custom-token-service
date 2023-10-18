namespace fastEndpointTeamplateTest.Endpoints.Test
{
    public class Test : EndpointWithoutRequest<string>
    {
        public override void Configure()
        {
            Get("/api/test");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Response = "Fast Endpoints is working.";
        }

    }
}
