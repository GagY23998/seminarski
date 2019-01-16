using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using OnlineShopping.HelperUser;
using Moq;
using Microsoft.Extensions;
using Microsoft.CodeAnalysis.Options;
using OnlineShopping.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OnlineShoppingTestProject.HelperClasses
{
    public class FakeManager: UserManager<AppUser>
    {
        public FakeManager():base(new Mock<IUserStore<AppUser>>().Object, new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<AppUser>>().Object,
                  new IUserValidator<AppUser>[0],
                  new IPasswordValidator<AppUser>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<AppUser>>>().Object)
        {
               
        }

    }
        
}
