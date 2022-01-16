﻿using System;
using MediatR;

namespace Budy.Application.Balances.Queries
{
    public class GetBalanceQuery : IRequest<BalanceResponse>
    {
        public DateTime? BalanceDateTime { get; set; }

        public GetBalanceQuery(DateTime? balanceDateTime)
        {
            BalanceDateTime = balanceDateTime;
        }
    }
}