using MetroDelivery.Application.Models.VnPay;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Identity.Services.VnPay
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentInformation model, HttpContext context);
        PaymentResponse PaymentExecute(IQueryCollection collections);
    }
}
