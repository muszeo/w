//----------------------------------------------------------------------------------------------------------
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Collections.Generic;
#endregion

namespace W.Api.Repository.Configured
{
    public class SettingsModel
    {
        public string QueueFor { get; set; }
        public IDictionary<string, (string, string, string)> AutoObserve { get; set; }
    }
}