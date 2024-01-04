namespace Webjar.Application.Utitlies
{
    public class NameGenerator
    {
        public static string GenerateUniqueCode()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "");
            string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day;

            return guid + "_" + date;
        }
    }
}
