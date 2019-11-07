using System;
using System.Collections.Generic;
using System.Text;

namespace Torf_Sklep.Infrastructure.EmailSystem
{
    public interface ISendEmail
    {
        bool SendEmail(string email_adres);
    }
}
