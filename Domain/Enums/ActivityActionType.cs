namespace EasyReach_Domain.Enums
{
    /// <summary>
    /// Admin/Manager activity log er jonno - ke ki action nilo seta track korte.
    /// </summary>
    public enum ActivityActionType
    {
        Create = 1,
        Update = 2,
        Delete = 3,
        Login = 4,
        Logout = 5,
        StatusChange = 6,
        PermissionChange = 7
    }
}
