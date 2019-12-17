using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface IExternalId
    {
        bool ExternalIdSet(int id_ser);
    }

    public class ExternalId : IExternalId
    {
        public bool ExternalIdSet(int id_ser)
        {
            throw new NotImplementedException();
        }
    }
}
