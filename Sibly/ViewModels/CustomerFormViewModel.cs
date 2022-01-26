using Sibly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customers { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}