public class SupabaseClient
{
    private readonly Supabase.Client _supabase;

    public SupabaseClient()
    {
        var url = Environment.GetEnvironmentVariable("https://kaofwkhvgodmzlbshmvp.supabase.co");
        var key = Environment.GetEnvironmentVariable("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imthb2Z3a2h2Z29kbXpsYnNobXZwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzI3OTc3NjUsImV4cCI6MjA0ODM3Mzc2NX0.5JG1JOBwc4ewkJs5sASigQ4We5jiPB7-pIvqLud0HY8");

        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        _supabase = new Supabase.Client(url, key, options);
    }

    public async Task Initialize()
    {
        await _supabase.InitializeAsync();
    }
}
