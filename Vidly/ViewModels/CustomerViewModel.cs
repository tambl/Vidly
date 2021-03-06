﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToCustomer { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public DateTime BirthDate { get; set; }
    }
}