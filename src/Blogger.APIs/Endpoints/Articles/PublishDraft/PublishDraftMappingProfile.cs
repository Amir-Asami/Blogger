﻿namespace Blogger.APIs.Endpoints.Articles.PublishDraft;

public class PublishDraftMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<PublishDraftRequest, PublishDraftCommand>()
                   .Map(x => x.DraftId, src => ArticleId.Create(src.DraftId));
    }
}
