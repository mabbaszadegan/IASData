namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HttpLog")]
    public partial class HttpLog
    {
        public int HttpLogId { get; set; }

        [StringLength(250)]
        public string APPL_MD_PATH { get; set; }

        [StringLength(250)]
        public string APPL_PHYSICAL_PATH { get; set; }

        [StringLength(250)]
        public string AUTH_PASSWORD { get; set; }

        [StringLength(250)]
        public string AUTH_TYPE { get; set; }

        [StringLength(250)]
        public string AUTH_USER { get; set; }

        [StringLength(250)]
        public string CERT_COOKIE { get; set; }

        [StringLength(250)]
        public string CERT_FLAGS { get; set; }

        [StringLength(250)]
        public string CERT_ISSUER { get; set; }

        [StringLength(250)]
        public string CERT_KEYSIZE { get; set; }

        [StringLength(250)]
        public string CERT_SECRETKEYSIZE { get; set; }

        [StringLength(250)]
        public string CERT_SERIALNUMBER { get; set; }

        [StringLength(250)]
        public string CERT_SERVER_ISSUER { get; set; }

        [StringLength(250)]
        public string CERT_SERVER_SUBJECT { get; set; }

        [StringLength(250)]
        public string CERT_SUBJECT { get; set; }

        [StringLength(250)]
        public string CONTENT_LENGTH { get; set; }

        [StringLength(250)]
        public string CONTENT_TYPE { get; set; }

        [StringLength(250)]
        public string GATEWAY_INTERFACE { get; set; }

        [StringLength(250)]
        public string HTTP_HeaderName { get; set; }

        [StringLength(250)]
        public string HTTP_ACCEPT { get; set; }

        [StringLength(250)]
        public string HTTP_ACCEPT_LANGUAGE { get; set; }

        [StringLength(800)]
        public string HTTP_COOKIE { get; set; }

        [StringLength(250)]
        public string HTTP_REFERER { get; set; }

        [StringLength(800)]
        public string HTTP_USER_AGENT { get; set; }

        [StringLength(250)]
        public string HTTPS { get; set; }

        [StringLength(250)]
        public string HTTPS_KEYSIZE { get; set; }

        [StringLength(250)]
        public string HTTPS_SECRETKEYSIZE { get; set; }

        [StringLength(250)]
        public string HTTPS_SERVER_ISSUER { get; set; }

        [StringLength(250)]
        public string HTTPS_SERVER_SUBJECT { get; set; }

        [StringLength(250)]
        public string INSTANCE_ID { get; set; }

        [StringLength(250)]
        public string INSTANCE_META_PATH { get; set; }

        [StringLength(250)]
        public string LOCAL_ADDR { get; set; }

        [StringLength(250)]
        public string LOGON_USER { get; set; }

        [StringLength(250)]
        public string PATH_INFO { get; set; }

        [StringLength(250)]
        public string PATH_TRANSLATED { get; set; }

        [StringLength(250)]
        public string QUERY_STRING { get; set; }

        [StringLength(250)]
        public string REMOTE_ADDR { get; set; }

        [StringLength(250)]
        public string REMOTE_HOST { get; set; }

        [StringLength(250)]
        public string REMOTE_USER { get; set; }

        [StringLength(250)]
        public string REQUEST_METHOD { get; set; }

        [StringLength(250)]
        public string SCRIPT_NAME { get; set; }

        [StringLength(250)]
        public string SERVER_NAME { get; set; }

        [StringLength(250)]
        public string SERVER_PORT { get; set; }

        [StringLength(250)]
        public string SERVER_PORT_SECURE { get; set; }

        [StringLength(250)]
        public string SERVER_PROTOCOL { get; set; }

        [StringLength(250)]
        public string SERVER_SOFTWARE { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        public int? USER_ID { get; set; }

        public int? SubSystemId { get; set; }

        public DateTime? HttpLogDateTime { get; set; }

        [StringLength(16)]
        public string HttpLogDateTimeSolar { get; set; }

        public int? CustomerId { get; set; }
    }
}
