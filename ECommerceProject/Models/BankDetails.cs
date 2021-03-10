using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class BankDetails
    {
        [Key]
        public int BankDetailsId { get; set; }
        
        public string AccountHolderName { get; set; }
        
        public int AccountNumber { get; set; }
        
        public string IFSC_Code { get; set; }
        [StringLength(6,ErrorMessage = "Can't be more than 6 digits")]
        public int UPI_ID { get; set; }

        [Display(Name = "Store")]
        public virtual int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [Display(Name = "Customer")]
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}