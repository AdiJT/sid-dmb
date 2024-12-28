using NetTopologySuite.Geometries;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SidDmb.Web.Configurations;

public static class MapsAPIConfiguration
{
    public const string ApiKey = "AIzaSyD-4Cs26qgJwEWf8uDQWInDkul3tgxWQWI";

    public static string MapsEmbedApi(string q, Point center)
    {
        q = Regex.Replace(q, " +, +", ",");
        q = Regex.Replace(q, " ", "+");

        var uri = new Uri($"https://www.google.com/maps/embed/v1/place?key={ApiKey}&q={q}&center={center.Y.ToString("F3", CultureInfo.InvariantCulture)},{center.X.ToString("F3", CultureInfo.InvariantCulture)}");

        return uri.ToString();
    }
}