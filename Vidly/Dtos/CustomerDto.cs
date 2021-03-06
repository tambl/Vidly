﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToCustomer { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}