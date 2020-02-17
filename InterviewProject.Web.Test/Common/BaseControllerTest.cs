using System.IO;

namespace InterviewProject.Web.Test.Common
{
    public class BaseControllerTest
    {
        protected string GetEmbeddedJson(string resourceName)
        {
            var result = "";
            var assembly = typeof(BaseControllerTest).Assembly;
            using (var reader = new StreamReader(assembly.GetManifestResourceStream($"InterviewProject.Web.Test.Json.{resourceName}")))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
