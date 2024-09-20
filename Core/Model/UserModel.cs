using FamilySprout.Core.Utils;

namespace FamilySprout.Core.Model
{
    public class UserModel
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; } = 1;
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public bool isDeleted { get; set; }

        public UserModel()
        {
            createdBy = "System";
            dateCreated = DateUtils.GetCreateDate();
        }
    }
}
