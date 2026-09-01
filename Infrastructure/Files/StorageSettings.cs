using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Files
{
    public class StorageSettings
    {
        /// <summary>"Local" (default, saves to wwwroot/uploads on disk) or "Firebase" (uploads to a Google Cloud Storage / Firebase Storage bucket).</summary>
        public string Provider { get; set; } = "Local";

        // ---- Local provider ----
        public string LocalStoragePath { get; set; } = "wwwroot/uploads";
        public string PublicBaseUrl { get; set; } = "http://localhost:5080";

        // ---- Firebase / Google Cloud Storage provider ----
        public string FirebaseBucketName { get; set; } = string.Empty;
        /// <summary>Path to the Firebase/GCP service-account JSON key file (download from Firebase Console → Project Settings → Service Accounts).</summary>
        public string FirebaseCredentialsJsonPath { get; set; } = string.Empty;
    }
}
