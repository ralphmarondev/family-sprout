using FamilySprout.Core.Utils;

namespace FamilySprout.Core.Model
{
    public class FamilyModel
    {
        public long id { get; set; }
        public string remarks { get; set; }
        public int childCount { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public bool isDeleted { get; set; }

        public FamilyModel()
        {
            id = -1;
            createdBy = SessionManager.CurrentUser.username;
            dateCreated = DateUtils.GetCreateDate();
            isDeleted = false;
        }
    }
}
