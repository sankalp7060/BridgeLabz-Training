using System;

sealed class ApplianceMain
{
    public static void Start()
    {
        ApplianceUtilityImpl utility = new ApplianceUtilityImpl();
        utility.Utility();
    }
}
