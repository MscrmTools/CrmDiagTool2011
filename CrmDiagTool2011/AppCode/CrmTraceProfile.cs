using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmDiagTool2011.AppCode
{
    public class CrmTraceProfile
    {
        #region Properties

        /// <summary>
        /// Name of the trace profile
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The TraceDirectory registry entry specifies the directory for the 
        /// trace log files. The directory must exist, and the user who starts 
        /// the Microsoft CRMAppPool must have full control over this directory. 
        /// When you install Microsoft CRM, the default user is NT AUTHORITY\NETWORK SERVICE.
        /// </summary>
        public string TraceDirectory { get; set; }

        /// <summary>
        /// The TraceCategories registry entry is a combination of a category,
        /// a feature, and a trace level. You can specify multiple categories, 
        /// features, and trace levels. Separate each combination by using a 
        /// semicolon. For a list of categories, features, and trace levels and
        /// for sample combinations that are valid, see the "Trace level values"
        /// section.
        /// </summary>
        public string TraceCategories { get; set; }

        /// <summary>
        /// If you use a value of 0, the call stack is not included in the trace
        /// file. If you use a value of 1, the call stack is included in the trace
        /// file.
        /// </summary>
        public bool TraceCallStack { get; set; }

        /// <summary>
        /// The TraceFileSizeLimit registry entry specifies the maximum size of 
        /// trace files. New files are created when the limit is reached.
        /// </summary>
        public int TraceFileSizeLimit { get; set; }

        #endregion Properties

        public override string ToString()
        {
            return this.Name;
        }
    }
}
