﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SivasSozluk.Api.Application.Features.Commands.Entry.DeleteVote;
using SivasSozluk.Common.Models.RequestModels;
using SivasSozluk.Common.Models;
using SivasSozluk.Api.Application.Features.Commands.EntryComment.DeleteVote;
using Microsoft.AspNetCore.Authorization;

namespace SivasSozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class VoteController : BaseController
    {
        private readonly IMediator mediator;

        public VoteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Entry/{entryId}")]
        public async Task<IActionResult> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
        {
            var result = await mediator.Send(new CreateEntryVoteCommand(entryId, voteType, UserId.Value));

            return Ok(result);
        }

        [HttpPost]
        [Route("EntryComment/{entryCommentId}")]
        public async Task<IActionResult> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
        {
            var result = await mediator.Send(new CreateEntryCommentVoteCommand(entryCommentId, voteType, UserId.Value));

            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteEntryVote/{entryId}")]
        public async Task<IActionResult> DeleteEntryVote(Guid entryId)
        {
            await mediator.Send(new DeleteEntryVoteCommand(entryId, UserId.Value));

            return Ok();
        }

        [HttpPost]
        [Route("DeleteEntryCommentVote/{entryId}")]
        public async Task<IActionResult> DeleteEntryCommentVote(Guid entryCommentId)
        {
            await mediator.Send(new DeleteEntryCommentVoteCommand(entryCommentId, UserId.Value));

            return Ok();
        }
    }
}