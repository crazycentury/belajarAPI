using System;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IEmailServices
    {
        void SendEmail(EmailDTO request);
    }
}


