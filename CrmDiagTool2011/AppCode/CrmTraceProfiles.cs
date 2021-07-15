using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmDiagTool2011.AppCode
{
    public class CrmTraceProfiles
    {
        #region Variables

        /// <summary>
        /// Liste de connexions
        /// </summary>
        List<CrmTraceProfile> profiles;

        #endregion

        #region Propriétés

        /// <summary>
        /// Obtient ou définit la liste des connexions
        /// </summary>
        public List<CrmTraceProfile> Profiles
        {
            get { return profiles; }
            set { profiles = value; }
        }

        #endregion
    }
}
