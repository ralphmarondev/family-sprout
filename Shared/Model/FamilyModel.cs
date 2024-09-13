using System.Collections.Generic;

namespace FamilySprout.Shared.Model
{
    public class FamilyModel
    {
        public long id { get; set; }
        public string husband { get; set; }
        public string husbandFrom { get; set; }
        public string wife { get; set; }
        public string wifeFrom { get; set; }
        public string remarks { get; set; }
        public string createdBy { get; set; }
        public string createDate { get; set; }
        public List<ChildModel> childrens { get; set; }

        public FamilyModel()
        {
            childrens = new List<ChildModel>();
        }
    }
}
