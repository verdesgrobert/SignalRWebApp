using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SignalRWebApp.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Customer : EntityBase
    {
        [DataMember]
        [Display(Name = "ID")]
        public Int32 CustomerID { get; set; }

        [DataMember]
        [Display(Name = "Name")]
        public String FirstName { get; set; }

        [DataMember]
        [Display(Name = "Last name")]
        public String LastName { get; set; }
        
    }
}