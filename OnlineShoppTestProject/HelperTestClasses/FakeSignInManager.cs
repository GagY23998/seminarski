using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using OnlineShopping.HelperUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppTestProject.HelperTestClasses
{
    public class FakeSignInManager : SignInManager<AppUser>
    {
        public FakeSignInManager():
            base(new Mock<FakeUserManager>().Object,
                  new HttpContextAccessor(),
                  new Mock<IUserClaimsPrincipalFactory<AppUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
new Mock<ILogger<SignInManager<AppUser>>>().Object,new Mock<IAuthenticationSchemeProvider>().Object)
        {

        }
    }
}
