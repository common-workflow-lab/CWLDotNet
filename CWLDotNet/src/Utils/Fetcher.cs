// Code implemented after https://github.com/common-workflow-language/schema_salad/blob/main/schema_salad/fetcher.py
public interface Fetcher
{
    string FetchText(string uri);
    bool CheckExists(string uri);
    string Urljoin(string baseUrl, string url);
    static string[] schemes = new string[] { "file", "http", "https", "mailto" };
}

public class DefaultFetcher : Fetcher
{

    private HttpClient client;

    public DefaultFetcher()
    {
        this.client = new HttpClient();
    }
    public DefaultFetcher(HttpClient client)
    {
        this.client = client;
    }
    public bool CheckExists(string uri)
    {
        throw new NotImplementedException();
    }

    public string FetchText(string uri)
    {
        var split = new Uri(uri);
        var scheme = split.Scheme;
        if (Fetcher.schemes.Contains(scheme))
        {
            if ((new[] { "http", "https" }).Contains(scheme))
            {
                try
                {
                    var response = client.GetAsync(uri).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    throw new ValidationException($"Error fetching {uri}: {e.Message} ");
                }
            }
            else if (scheme == "file")
            {
                try
                {
                    var fileContent = System.IO.File.ReadAllText(split.AbsolutePath);
                    return fileContent;
                }
                catch (Exception e)
                {
                    throw new ValidationException($"Error reading file {uri}: {e.Message} ");
                }
            }
        }

        throw new ValidationException($"Unsupported scheme {scheme} in url: {uri}");
    }

    public string Urljoin(string baseUrl, string url)
    {
        if (url.StartsWith("_:"))
        {
            return url;
        }
        var baseUri = new Uri(baseUrl);
        var uri = new Uri(url, UriKind.Relative);

        return new Uri(baseUri, url).ToString();
    }
}