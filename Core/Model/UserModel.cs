namespace FamilySprout.Core.Model
{
    public class UserModel
    {
        public long id { get; set; }
        public string fullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string createdBy { get; set; }
        public string createDate { get; set; }


        public UserModel()
        {

        }
    }
}
