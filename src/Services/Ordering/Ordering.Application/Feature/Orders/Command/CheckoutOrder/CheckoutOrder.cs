using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Contracts.Persist;
using Ordering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Feature.Orders.Command.CheckoutOrder
{
    public class CheckoutOrderCommand : IRequest<int>//produces an newly created order id
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
    }

    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderUow _orderUow;
        private readonly IMapper _mapper;
        //private readonly IEmailService _emailSvc;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderUow orderUow,
            IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger)//IEmailService emailSvc,
        {
            _orderUow = orderUow;
            _mapper = mapper;
            //_emailSvc = emailSvc;
            _logger = logger;
        }


        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            // entity conversion
            var order = _mapper.Map<Order>(request);
            // Populate base entity fields
            order.CreatedBy = Constants.CurrentUser;
            // create new order
            var newOrder = await _orderUow.AddOrderAsync(order);
            // send email
            //await SendMailAsync(newOrder);
            // return new order id
            return newOrder.Id;
        }

        //private async Task SendMailAsync(Order order)
        //{
        //    var email = new Email() { To = "ezozkme@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

        //    try
        //    {
        //        await _emailSvc.SendEmail(email);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
        //    }
        //}
    }
}
