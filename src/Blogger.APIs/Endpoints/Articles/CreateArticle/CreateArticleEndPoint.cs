﻿using Blogger.APIs.Endpoints;

namespace Blogger.APIs.Endpoints.Articles.CreateArticle;

public class CreateArticleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/articles/", async (
                [FromBody] CreateArticleRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<CreateArticleCommand>(request);
            var response = await mediator.Send(command, cancellationToken);

            return mapper.Map<CreateArticleResponse>(response);
        }).Validator<CreateArticleRequest>()
          .WithTags(EndpointSchema.ArticleTag);
    }
}
