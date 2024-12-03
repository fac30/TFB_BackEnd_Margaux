using Supabase;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

public class ClothingItemService
{
    private readonly Supabase.Client _supabaseClient;
    private readonly string _bucketName = "your-bucket-name";
    private readonly string _supabaseUrl;

    public ClothingItemService(Supabase.Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
        _supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL") ?? 
            throw new ArgumentNullException("SUPABASE_URL not set");
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            stream.Position = 0;
            
            var fileBytes = stream.ToArray();
            var options = new Supabase.Storage.FileOptions
            {
                ContentType = file.ContentType
            };

            await _supabaseClient.Storage
                .From(_bucketName)
                .Upload(fileBytes, fileName, options);
        }

        return GeneratePhotoLink(fileName);
    }

    public string GeneratePhotoLink(string fileName)
    {
        return $"{_supabaseUrl}/storage/v1/object/public/{_bucketName}/{fileName}";
    }

    public async Task AddClothingItemAsync(ClothingItem item, IFormFile file)
    {
        item.PhotoLink = await UploadFileAsync(file);
        // Add database context logic here
    }
}
