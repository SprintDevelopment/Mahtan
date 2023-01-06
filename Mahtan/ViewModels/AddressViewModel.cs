using Mahtan.Models;

namespace Mahtan.ViewModels
{
    public class AddressViewModel
    {
        public Address Address { get; set; }
        public IEnumerable<District> Districts { get; set; }
    }
}
