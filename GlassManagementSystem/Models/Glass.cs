using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlassManagementSystem.Models
{
    public class Glass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Quoted Amount")]
        public decimal QuotedAmount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime DateOrdered { get; set; }

        [Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }

        [Display(Name = "Glass Ordered?")]
        public string Ordered { get; set; }

        public string JobStatus { get; set; }

        [Display(Name = "Payed?")]
        public string Payed { get; set; }
       
        public string Comments { get; set; }

        public DateTime DateCreated { get; set; }


    }
}
