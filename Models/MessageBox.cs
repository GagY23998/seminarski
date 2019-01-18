using OnlineShopping.HelperUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class MessageBox
    {
        public int MessageBoxID { get; set; }
        public string SenderID { get; set; }
        public AppUser Sender { get; set; }
        public string ReciverID { get; set; }
        public AppUser Reciver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreationDate { get; set; }
        public byte[] Attachment { get; set; }
    }
}
