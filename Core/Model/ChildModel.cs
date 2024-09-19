using FamilySprout.Core.Utils;

namespace FamilySprout.Core.Model
{
    public class ChildModel
    {
        public long id { get; set; }
        public long famId { get; set; }
        public string name { get; set; }
        public string bday { get; set; }
        public string baptism { get; set; }
        public string hc { get; set; }
        public string obitus { get; set; }
        public string matrimony { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public bool isDeleted { get; set; }

        public ChildModel(
            long _id,
            long _famId,
            string _name,
            string _bday,
            string _baptism,
            string _hc,
            string _obitus,
            string _matrimony,
            string _createdBy,
            string _createDate)
        {
            id = _id;
            famId = _famId;
            name = _name;
            bday = _bday;
            baptism = _baptism;
            hc = _hc;
            obitus = _obitus;
            matrimony = _matrimony;
            createdBy = _createdBy;
            dateCreated = _createDate;
        }

        public ChildModel()
        {
            id = -1;
            famId = -1;
            createdBy = SessionManager.CurrentUser.username;
            dateCreated = DateUtils.GetCreateDate();
            isDeleted = false;
        }
    }
}
