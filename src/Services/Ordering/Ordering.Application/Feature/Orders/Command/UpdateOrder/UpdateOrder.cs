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

namespace Ordering.Application.Feature.Orders.Command.UpdateOrder
{
    public class UpdateOrderCommand : IRequest//produces no specific output
    {
        public int Id { get; set; }
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

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderUow _orderUow;
        private readonly IMapper _mapper;
        //private readonly IEmailService _emailSvc;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderUow orderUow,
            IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)//IEmailService emailSvc,
        {
            _orderUow = orderUow;
            _mapper = mapper;
            //_emailSvc = emailSvc;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            // get the order from db
            var order = await _orderUow.GetOrderByIdAsync(request.Id);
            if (order == null)
            {
                _logger.LogError($"Order with Id:{request.Id} is not found.");
                //throw new NotFoundException(nameof(Order), request.Id);
            }
            // map/conversion
            _mapper.Map(request, order, typeof(UpdateOrderCommand), typeof(Order));
            // update & persist
            await _orderUow.UpdateOrderAsync(order);

            return Unit.Value;

        }
    }
}
