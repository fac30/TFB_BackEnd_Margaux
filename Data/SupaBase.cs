using System;
using Supabase;

public class SupabaseClient
{
    private readonly Supabase.Client _supabase;

    public SupabaseClient()
    {
        var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");

        if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
        {
            throw new Exception("Supabase URL or Key is not set in the environment variables.");
        }

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

    public Supabase.Client GetClient()
    {
        return _supabase;
    }
}
