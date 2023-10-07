namespace UnoWASMnet80
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded; 
        }

        Task Res;
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Res = Load();
        }

        async Task Load()
        {
            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Get, "https://worldtimeapi.org/api/timezone/Etc/GMT.txt");
            string ans = null;
            try
            {
                var res = await client.SendAsync(req);
                ans = await res.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                ans = ex.Message;
            }

            (Content as StackPanel).Children.Add(new TextBlock { Text = ans });
        }
    }
}
