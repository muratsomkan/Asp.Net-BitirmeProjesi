namespace Shoppica.MVC
{
    public static class GlobalConfig // static olmasının sebebi tek bir instance alınabilsin diye, her işlem onun üzerinden ilerlesin diye.
    {
        public static HttpClient webClient = new HttpClient();

        static GlobalConfig()
        {
            webClient.BaseAddress = new Uri("https://localhost:7113/api/");
            webClient.DefaultRequestHeaders.Clear();
            webClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
        }
    }
}
