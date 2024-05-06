﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand
    {

        public string UserId { get; set; }

        public string Disctrick { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
