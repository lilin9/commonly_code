using System.Net;
using System.Net.Mail;
using System.Text;
using verifyCodeSending.Repository;

namespace verifyCodeSending {
    public class FoxMailRepository: IEmailRepository {
        private const string SmtpServer = "smtp.exmail.qq.com"; //SMTP服务器
        private const string FromEmail = "lin.li@ebulent.com.cn"; //发信邮箱
        private const string AuthPwd = "S22i3BnkDGZMNXhd"; //密码或授权码

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toEmail">要发往的邮箱</param>
        /// <param name="subject">邮箱主题</param>
        /// <param name="msgBody">邮件内容</param>
        /// <returns></returns>
        public async Task<bool> SenderEmail(string toEmail, string subject, string msgBody) {
            if (string.IsNullOrEmpty(SmtpServer) || string.IsNullOrEmpty(FromEmail) ||
                string.IsNullOrEmpty(AuthPwd)) {
                return false;
            }

            using var msg = new MailMessage();
            /*
             * msg.To.Add("b.@b.com");  //可以发送给多个人
             */
            msg.To.Add(toEmail);    //设置收件人

            /*
             * msg.CC.Add("c@c.com");
             * msg.CC.Add("d@d.com"); 可以抄送给多个人
             */

            //3个参数分别是：发件人地址（可以随便写），发件人姓名，编码
            msg.From = new MailAddress(FromEmail, FromEmail, System.Text.Encoding.UTF8);

            msg.Subject = subject; //邮件标题
            msg.SubjectEncoding = Encoding.UTF8; //邮件标题编码
            msg.Body = msgBody; //邮件内容
            msg.BodyEncoding = Encoding.UTF8; //邮件内容编码
            msg.IsBodyHtml = true; //是否是HTML邮件
            msg.Priority = MailPriority.Normal; //邮件优先级

            var client = new SmtpClient(SmtpServer, 587);  //邮件服务器地址和端口号
            client.EnableSsl = true;    //使用 ssl 加密发送
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(FromEmail, AuthPwd); //邮箱账户、密码
            client.Timeout = 6000;  //发送邮件6秒超时

            try {
                await client.SendMailAsync(msg);    //发送邮件
                return true;
            } catch (SmtpException e) {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
