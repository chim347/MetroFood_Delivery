using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Auth.Queries.ResetPassword
{
    public class ResetPasswordQuery : IRequest<string>
    {
        public string Email { get; set; }
    }
}
