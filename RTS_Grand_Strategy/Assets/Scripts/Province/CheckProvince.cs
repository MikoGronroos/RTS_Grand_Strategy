public class CheckProvince
{

    public static bool CheckForDivisions(ProvinceHolder holder)
    {
        if (holder.GetProvinceDivisions().HasDivision())
        {
            return true;
        }
        return false;
    }

    public static bool CheckForEnemyDivisions(ProvinceHolder holder, string id)
    {
        if (holder.GetProvinceDivisions().HasEnemyDivision(id))
        {
            return true;
        }
        return false;
    }

    public static bool CheckIfDivisionOwnerIsOwnerOfTheProvince(ProvinceHolder holder, string id)
    {
        return holder.ThisProvince.ProvinceOwnerID == id;
    }

}
