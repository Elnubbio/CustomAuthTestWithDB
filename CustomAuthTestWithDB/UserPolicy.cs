namespace CustomAuthTestWithDB;

public class UserPolicy
{
    public const string VIEW_WEATHER = "VIEW_WEATHER";
    public const string VIEW_COUNTER = "VIEW_COUNTER";

    public static List<string> GetPolicies()
    {
        return new List<string>()
        {
            VIEW_WEATHER,
            VIEW_COUNTER
        };
    }
}