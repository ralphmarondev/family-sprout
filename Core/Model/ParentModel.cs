using FamilySprout.Core.Utils;

namespace FamilySprout.Core.Model
{
    public class ParentModel
    {
        public long id { get; set; }
        public long famId { get; set; }
        public string name { get; set; }
        public string hometown { get; set; }
        public int role { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public bool isDeleted { get; set; }

        public ParentModel()
        {
            id = -1;
            famId = -1;
            createdBy = SessionManager.CurrentUser.username;
            dateCreated = DateUtils.GetCreateDate();
            isDeleted = false;
        }
    }
}
