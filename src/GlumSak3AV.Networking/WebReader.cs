namespace GlumSak3AV.Networking
{
    public static class WebReader
    {
        public static async Task<IEnumerable<string>> ReadFromUrl(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                return lines;
            }
            else
            {
                throw new Exception($"Failed to fetch data from {url}. Status code: {response.StatusCode}");
            }
            
        }
    }
}