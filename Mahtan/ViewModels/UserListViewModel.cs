using Mahtan.Assets.Values.Enums;
using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<UserWithProfile> Users { get; set; }
    }

    public class UserWithProfile
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string RegisterDateTime { get; set; }
        public Roles Role { get; set; }
    }
}
