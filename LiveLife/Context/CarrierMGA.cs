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

    public partial class CarrierMGA
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Business Name")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string BusinessAddress { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(10, ErrorMessage = "Phone Number should be 10 digits")]
        public string BusinessPhoneNumber { get; set; }
    }
}