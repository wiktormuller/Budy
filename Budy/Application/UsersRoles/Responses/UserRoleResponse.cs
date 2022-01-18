namespace Budy.Application.UsersRoles.Responses
{
    public class UserRoleResponse
    {
        public string Name { get; private set; }

        public UserRoleResponse(string name)
        {
            Name = name;
        }
    }
}