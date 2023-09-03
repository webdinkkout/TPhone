using CellPhoneS.Models.DomainModels;
using Newtonsoft.Json;

namespace CellPhoneS.Common;

public static class UserLogin
{
    public static User? GetCurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        var currentUserJson = httpContextAccessor.HttpContext?.Session.GetString("CURRENT_USER");
        if (string.IsNullOrEmpty(currentUserJson))
        {
            return null;
        }

        var currentUser = JsonConvert.DeserializeObject<User>(currentUserJson);

        if (currentUser == null)
        {
            return null;
        }

        return currentUser;
    }
}