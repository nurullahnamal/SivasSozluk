﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using SivasSozluk.Api.Application.Interfaces.Repositories;
using SivasSozluk.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivasSozluk.Api.Application.Features.Queries.SearchBySubject
{
    public class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryViewModel>>
    {
        private readonly IEntryRepository entryRepository;

        public SearchEntryQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
        {
            // TODO validation, request.SearchText length should be checked

            var result = entryRepository
                .Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
                .Select(i => new SearchEntryViewModel()
                {
                    Id = i.Id,
                    Subject = i.Subject,
                });

            return await result.ToListAsync(cancellationToken);
        }
    }
}
