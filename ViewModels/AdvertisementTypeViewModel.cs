using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineShopping.ViewModels
{
    public class AdvertisementTypeViewModel
    {
        [BindRequired]
        [StringLength(15,MinimumLength =4,ErrorMessage ="Field can't be empty")]
        public string AdvertisementType { get; set; }
    }
}
