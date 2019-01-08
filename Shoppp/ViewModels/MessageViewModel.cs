using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels
{
    public class MessageViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRead { get; set; }
        public byte[] Attachment { get; set; }

    }
}
