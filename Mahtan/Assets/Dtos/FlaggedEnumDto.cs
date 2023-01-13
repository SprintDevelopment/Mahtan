namespace Mahtan.Assets.Dtos
{
    public class FlaggedEnumDto : EnumDto
    {
        public bool IsSelected { get; set; }

        public FlaggedEnumDto(object value, string description, bool isSelected) : base(value, description)
        {
            IsSelected = isSelected;
        }

        public FlaggedEnumDto()
        {
        }
    }
}
