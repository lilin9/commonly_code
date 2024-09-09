using Microsoft.AspNetCore.Mvc;
using verifyCodeSending.Repository;

namespace webapi.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestEmailController(IEmailRepository emailRepository): ControllerBase {
        [HttpGet]
        public async Task<bool> Sender(string email) {
            return await emailRepository.SenderEmail(email, GetEmailSubject(), GetEmailBody("6666"));
        }

        /// <summary>
        /// 获取邮件主题
        /// </summary>
        /// <returns></returns>
        private static string GetEmailSubject() {
            return "ebulent.com: Here's your Verification Code";
        }

        /// <summary>
        /// 获取邮件主题
        /// </summary>
        /// <param name="verifyCode"></param>
        /// <returns></returns>
        private string GetEmailBody(string verifyCode) {
            var bodyStr = "<p>If this was you, your verification code is:</p>" +
                          $"<p style=\"background-color: rgb(211, 211, 211); text-align: left; font-size: 20px; font-weight: bold; font-family: &quot;Amazon Ember&quot;, Arial, sans-serif; padding: 15px 1px 10px 10px; border-radius: 10px; --darkreader-inline-bgcolor: #313537;\">{verifyCode}</p> + " +
                          "<p>Don’t share it with others.</p>";

            return bodyStr;
        }
    }
}
