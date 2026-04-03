public class EmployeeMain
{
    public static void Start()
    {
        IEmployee utility = new EmployeeUtilityImpl();
        EmployeeMenu menu = new EmployeeMenu(utility);

        menu.ShowMenu();
    }
}
