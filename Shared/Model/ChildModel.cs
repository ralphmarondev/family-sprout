namespace FamilySprout.Shared.Model
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
        public string createDate { get; set; }

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
            createDate = _createDate;
        }
    }
}
