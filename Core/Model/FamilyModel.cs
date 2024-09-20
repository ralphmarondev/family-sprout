using FamilySprout.Core.Utils;

namespace FamilySprout.Core.Model
{
    public class FamilyModel
    {
        /// <summary>
        /// id = id of family
        /// husband, wife = id from parents table [it is here for easy retrieval]
        /// husbandName, wifeName = names from parents table [it is here for ease retrieval]
        /// childCount = increment or decrement depending on operation [adding or removing child/ren]
        /// remarks = usually created on creating new family. Bu default it is set to 'No Remarks.'
        /// createdBy = username of the current-user, if not exists, default is 'System'
        /// dateCreated = creation date of family
        /// isDeleted = we are not deleting permanently families, we are just setting this as flag. we have a trash 
        ///         feature, there we can opt to restore or permanently delete the family.
        /// </summary>
        public long id { get; set; }
        public long husband { get; set; }
        public string husbandName { get; set; }
        public long wife { get; set; }
        public string wifeName { get; set; }
        public int childCount { get; set; }
        public string hometown { get; set; }
        public string remarks { get; set; }
        public string createdBy { get; set; }
        public string dateCreated { get; set; }
        public bool isDeleted { get; set; }

        public FamilyModel()
        {
            createdBy = SessionManager.CurrentUser.username;
            dateCreated = DateUtils.GetCreateDate();
        }
    }
}
