namespace EasyReach_Domain.Enums
{
    /// <summary>
    /// System e kon type er user login korbe seta define kore.
    /// Customer = shudhu shopping korbe.
    /// Manager = limited permission niye admin panel operate korbe.
    /// Admin/SuperAdmin = full access.
    /// </summary>
    public enum UserType
    {
        Customer = 1,
        Manager = 2,
        Admin = 3,
        SuperAdmin = 4
    }
}
