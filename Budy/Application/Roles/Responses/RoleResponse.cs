namespace Budy.Application.Roles.Responses
{
    public class RoleResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public RoleResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}