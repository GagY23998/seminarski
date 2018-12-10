using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.HelperUser
{
    public static class HelpSession
    {
        public static void SetUser(this ISession session, AppUser user)
        {
            session.SetString("user", JsonConvert.SerializeObject(user));
            var a = session.GetString("user");
        }
        public static AppUser GetUser(this ISession session)
        {
            var JsonString = session.GetString("user");
            return JsonString == null ? null : JsonConvert.DeserializeObject<AppUser>(JsonString);
        }
    }
}
