//----------------------------------------------------------------------------------------------------------
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

namespace W.Api.Settings
{
    public static class Constants
    {
        public static class Repositories
        {
            public const string POSTGRES = "PostgreSQL";
        }

        public static class Uris
        {
            public static class Local
            {
                public const string API_ROOT = "/api";
                public const string ERROR = "/Error";
            }

            public static class Query
            {
                public const string NAME = "name";
                public const string NAME_SPACE = "namespace";
            }
        }

        public static class Security
        {
            public const string JWT_BEARER = "Bearer";

            public static class Claims
            {
                public const string NAME = "name";
                public const string EMAIL = "emailaddress";
                public const string SCOPE = "scope";
                public const string FQ_NAME = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
                public const string FQ_EMAIL = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
                public const string PROVIDER = "identityprovider";
                public const string IDENTIFIER = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
                public const string FQ_PROVIDER = "http://schemas.microsoft.com/identity/claims/identityprovider";
            }

            public static class Scopes
            {
                //
                // API Scopes are constructed as follows:
                //
                // <API scope component>Api.<read|write>
                //
                // E.g. invoicingApi.read
                //
                // These scopes are configured in the MyTrucking IDP's Client Application(s) configurations
                // and are used to determine API authorisation for a calling API Client.
                //
 
                // Generic scope parts
                public const string API = "Api";
                public const string READ = ".read";
                public const string WRITE = ".write";

                //
                // API scope components                                     Constructed Example
                //
                public const string CACHING = "caching";                  //  cachingApi.read
            }
        }

        public static class Config
        {
            public static readonly string UI_URI = "ui-uri";
            public static readonly string API_URI = "api-uri";

            public static class Sections
            {
                public static readonly string SETTINGS = "Settings";
                public static readonly string SECURITY = "Security";
                public static readonly string DATABASE = "Database";
                public static readonly string AUTO_OBSERVE = "AutoObserve";
                public static readonly string SECURITY_AUTHORITY = "Security:Authority";
            }

            public static class Fields
            {
                public static readonly string QUEUE_FOR = "QueueFor";
                public static readonly string METRIC_ID = "MetricId";
                public static readonly string METRIC_ROLE = "Role";
                public static readonly string METRIC_ARGS = "Args";
                public static readonly string METRIC_RECUR = "Recur";
            }
        }

        public static class RestResponse
        {
            public static readonly string FAILURE = "FAILURE";
            public static readonly string SUCCESS = "SUCCESS";
            public static readonly string FORBIDDEN = "FORBIDDEN";
        }

        public static class HealthCheckResponse
        {
            public static readonly string OK = "HEALTH_OK";
            public static readonly string NOT_OK = "HEALTH_NOT_OK";
        }

        public static class Messages
        {
            public static readonly string MSG__TITLE = "MyTrucking Eventing API";
            public static readonly string MSG__CANNOT_OPEN_CONNECTION = "Failed to open connection";
            public static readonly string MSG__EMAIL_INTRO = "Hi,\n\n";
            public static readonly string MSG__EMAIL_SIGNOFF = "Regards,\n\nThe MyTrucking Business Event Service.";

            public static class Logger
            {
                public static readonly string EMAIL = "EMAIL: ";
            }
        }

        public static class Database
        {
            public static readonly string DEFAULT_TIME = "00:00:00";
        }
    }
}