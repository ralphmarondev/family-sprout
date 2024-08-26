using System.Collections.Generic;

namespace FamilySprout.Core.Model
{
    internal class FamilyModel
    {
        public string husband { get; set; }
        public string husbandFrom { get; set; }
        public string wife { get; set; }
        public string wifeFrom { get; set; }
        public List<Children> childrens { get; set; } = new List<Children>();
    }

    internal class Children
    {
        public string name { get; set; }
        public string bday { get; set; }
        public string baptism { get; set; }
        public string hc { get; set; }
        public string matrimony { get; set; }
        public string obitus { get; set; }
    }
}
