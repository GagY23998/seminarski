using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppTestProject.HelperTestClasses
{
    public class FakeRoleManager : RoleManager<IdentityRole>
    {
        public FakeRoleManager() :base(new Mock<IRoleStore<IdentityRole>>().Object,new IRoleValidator<IdentityRole>[0],
            new Mock<ILookupNormalizer>().Object,new Mock<IdentityErrorDescriber>().Object,new Mock<ILogger<FakeRoleManager>>().Object)
        {

        }
    }
}
