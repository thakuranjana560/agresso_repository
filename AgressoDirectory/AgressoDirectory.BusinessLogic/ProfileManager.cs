using AgressoDirectory.Common.Model;
using AgressoDirectory.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgressoDirectory.BusinessLogic
{
    public class ProfileManager
    {
        public Profile GetProfileById(string profileId)
        {
            ProfileRepository dataAccess = new ProfileRepository();
            Profile datatable = dataAccess.GetProfileById(profileId);
            return datatable;
        }

        public void UpdateUserProfile(Profile userProfile)
        {
            ProfileRepository dataAccess = new ProfileRepository();
            dataAccess.UpdateUserProfile(userProfile);
        }
        
        public DataSet GetDesignationType()
        {
            ProfileRepository dataaccess = new ProfileRepository();
            DataSet datatable = dataaccess.GetDesignationType();
            return datatable;
        }
    }
}
