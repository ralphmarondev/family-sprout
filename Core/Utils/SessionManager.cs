using FamilySprout.Core.Model;

namespace FamilySprout.Core.Utils
{
    public static class SessionManager
    {
        public static UserModel CurrentUser { get; set; } = new UserModel();
    }
}
