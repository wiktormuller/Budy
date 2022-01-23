using System.Collections.Generic;
using Budy.Application.Entries.Responses;
using MediatR;

namespace Budy.Application.Entries.Queries
{
    public class GetAllEntriesQuery : IRequest<List<EntryResponse>>
    {
    }
}