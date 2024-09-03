using System.Collections.Generic;

namespace FamilySprout.Core.Model
{
    internal class FamilyModel
    {
        public int id { get; set; }
        public string husband { get; set; }
        public string husbandFrom { get; set; }
        public string wife { get; set; }
        public string wifeFrom { get; set; }
        public string remarks { get; set; }
        public List<Children> childrens { get; set; } = new List<Children>();

        public string createdBy { get; set; }
        public string createDate { get; set; }

        public FamilyModel() { }

        public FamilyModel(
            int _id,
            string _husband,
            string _husbandFrom,
            string _wife,
            string _wifeFrom,
            string _remarks,
            string _createdBy,
            string _createDate,
            List<Children> _childrens
            )
        {
            this.id = _id;
            this.husband = _husband;
            this.husbandFrom = _husbandFrom;
            this.wife = _wife;
            this.wifeFrom = _wifeFrom;
            this.remarks = _remarks;
            this.childrens = _childrens;
            this.createdBy = _createdBy;
            this.createDate = _createDate;
        }
    }

    internal class Children
    {
        public int id { get; set; }
        public int famId { get; set; }
        public string name { get; set; }
        public string bday { get; set; }
        public string baptism { get; set; }
        public string hc { get; set; }
        public string matrimony { get; set; }
        public string obitus { get; set; }
        public string createdBy { get; set; }
        public string createDate { get; set; }

        public Children() { }

        public Children(
            int id,
            int famId,
            string _name,
            string _bday,
            string _baptism,
            string _hc,
            string _matrimony,
            string _obitus,
            string _createdBy,
            string _createDate
            )
        {
            this.id = id;
            this.famId = famId;
            this.name = _name;
            this.bday = _bday;
            this.baptism = _baptism;
            this.hc = _hc;
            this.matrimony = _matrimony;
            this.obitus = _obitus;
            this.createdBy = _createdBy;
            this.createDate = _createDate;
        }
    }
}
