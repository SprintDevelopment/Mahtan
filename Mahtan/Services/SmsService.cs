using Mahtan.Assets.Dtos;
using Microsoft.Extensions.Options;
using SmsServiceNamespace;
using System.Threading.Tasks;

namespace Mahtan.Services
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string mobile, string code);
    }
    public class SmsService : ISmsService
    {
        private readonly SmsDto _smsOption;
        public SmsService(IOptions<SmsDto> smsOption)
        {
            _smsOption = smsOption.Value;
        }

        public async Task<bool> SendSmsAsync(string mobile, string code)
        {
            try
            {
                var api = await new SendSMSSoapClient(new SendSMSSoapClient.EndpointConfiguration() { })
                    .SendAsync(_smsOption.Signature, mobile, string.Format(_smsOption.DefaultText, code), "");

                var SendResult = api.Body.SendResult;
                var retStr = api.Body.retStr;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
