namespace IASData.Utility
{
    public static class Constants
    {
        public const string AttachmentServiceUrl = "http://82.99.218.100:8080/Services/";
    }
    public static class ConfigReader {
        public static string ReferenceSeverUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["ReferenceSeverUrl"];
   
    }
}
