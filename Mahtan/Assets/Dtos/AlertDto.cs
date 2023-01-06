using Mahtan.Assets.Values.Enums;

namespace Mahtan.Assets.Dtos
{
    public class AlertDto
    {
        public AlertTypes AlertType { get; set; }
        public string Message { get; set; }

        public string AlertClass 
        {
            get 
            {
                return AlertType switch
                {
                    AlertTypes.Secondary => "alert-secondary",
                    AlertTypes.Success => "alert-success",
                    AlertTypes.Info => "alert-info",
                    AlertTypes.Warning => "alert-warning",
                    AlertTypes.Error => "alert-danger",
                    AlertTypes.Dark => "alert-dark",
                    _ => "",
                };
            }
        }
    }
}
