using System.Threading.Tasks;

namespace Net.Ysolution.Maarfi.Template.Core.Interfaces;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}
