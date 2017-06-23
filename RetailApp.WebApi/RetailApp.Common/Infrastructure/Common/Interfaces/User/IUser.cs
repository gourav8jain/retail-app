using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.User
{
    public interface IUser
    {
        UserModel GetOrders(UserModel userModel);
    }
}