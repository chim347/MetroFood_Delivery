using MediatR;

namespace MetroDelivery.Application.Features.Withdraws.Queries.GetByUserId
{
    public class GetByUserIdCommand : IRequest<List<WithdrawResponse>>
    {
        public string UserId { get; set; } = null!;
    }
}
