//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveLife.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblAdvisor
    {
        public int AdvisorID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(10, ErrorMessage = "Phone Number should be 10 digits")]
        public string PhoneNumber { get; set; }
        public string HealthStatus { get; set; }
    }
}
