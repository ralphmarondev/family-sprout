using FamilySprout.Core.Model;

namespace FamilySprout.Features.FamilyDetails.DB
{
    public static class DBFamilyDetails
    {
        public static FamilyModel GetFamilyDetails(long id)
        {
            FamilyModel family = new FamilyModel();

            return family;
        }

        public static ParentModel GetParentDetails(long famId)
        {
            ParentModel parent = new ParentModel();

            return parent;
        }

        public static void UpdateFamilyDetails(FamilyModel family)
        {

        }

        public static void UpdateParentDetails(ParentModel parent)
        {
        }

        public static void DeleteFamilyDetails(long famId)
        {
        }
    }
}
