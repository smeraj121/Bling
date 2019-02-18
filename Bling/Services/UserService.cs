using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using ProfilerApp.Models;
using ProofOfConcept.Models;
using ProofOfConcept.Repository;

namespace ProofOfConcept.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public int AddUser(User user)
        {
            try
            {
                return userRepository.AddUser(user);
            }
            catch(Exception e) { }
            return 0;
        }

        public UserAuth AuthenticateUser(Login user)
        {
            try
            {
                return userRepository.AuthenticateUser(user);
            }
            catch (Exception ex) { }
            return new UserAuth();
        }

        public bool ForgotPassword(string email)
        {
            try
            {
                string guid = Guid.NewGuid().ToString();
                if (userRepository.ForgotPassword(email, guid))
                {
                    SendMail(email, guid);
                    System.Timers.Timer timer = new System.Timers.Timer(20000);
                    timer.Enabled = true;
                    timer.Elapsed += (sender, e) => { ResetForgotKey(email); };
                    //timer.Elapsed += new System.Timers.ElapsedEventHandler(ResetForgotKey);
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
        void ResetForgotKey(string email)
       {
            try { userRepository.ResetForgotKey(email); }
            catch (Exception e) { }
        }
        public bool SendMail(string email,string guid) {
            MailMessage mail = new MailMessage("sabameraj121@gmail.com",email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("sabameraj121@gmail.com", "qwerty@123");
            client.Host = "smtp.gmail.com";
            mail.IsBodyHtml = true;
            mail.Subject = "Profiler : Password Recovery";
            mail.Body = "Hi, Click here to reset your password <br> <a href='localhost:61523/User/SetPassword?guid=" + guid+"&email="+email+"'> Click Here</a>";
            client.Send(mail);
            return true;
        }

        public bool MatchGuid(string guid, string email)
        {
            try
            {
                return userRepository.MatchGuid(guid, email);
            } catch (Exception e) { }
            return false;
        }

        public bool SetPassword(SetPassword Passwordmodel)
        {
            try {
                bool result= userRepository.SetPassword(Passwordmodel);
                return true;
            }
            catch (Exception e) { }
            return false;
        }
        public bool ChangePassword(ChangePassword Passwordmodel, string email)
        {
            try
            {
                userRepository.ChangePassword(Passwordmodel, email);
                return true;
            }
            catch (Exception e) { }
            return false;
        }
    }
}