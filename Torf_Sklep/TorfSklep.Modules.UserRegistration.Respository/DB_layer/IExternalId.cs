using System;
using System.Collections.Generic;
using System.Linq;
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
            List<User> result = GetAllUsers();
            if (result.Any(x => String.IsNullOrEmpty(x.external_id)))
                return true;
            return false;
        }
    }
}
