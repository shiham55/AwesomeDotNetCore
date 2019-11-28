using System;
using System.Collections.Generic;

namespace AwesomeDotNetCore.Data.Models
{
    public partial class AwbuildVersion
    {
        public byte SystemInformationId { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string TestingField { get; set; }
    }
}
