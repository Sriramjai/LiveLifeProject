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
    public partial class tblContract
    {
        public int ContractID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Promiser { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Promisee { get; set; }
    }
}