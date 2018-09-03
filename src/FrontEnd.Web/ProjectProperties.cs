using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Web
{
    public static class ProjectProperties
    {
        /// <summary>
        /// Build identifier
        /// </summary>
        public static string BuildId { get; set; }

        static ProjectProperties()
        {
            BuildId = "#{Build.BuildId}#";
            if ("#{Build.BuildId}#".Equals(BuildId))
                BuildId = "0";
        }
    }
}
