namespace TFB_BackEnd_Margaux.Configurations
{
    public class SustainableFashionConfig
    {
        public List<string> AllowedTopics { get; set; } =
            new List<string>
            {
                "upcycling",
                "thrifting",
                "donating clothes",
                "swapping clothes",
                "charity shops",
                "kilo sales",
                "sustainable fashion events",
            };

        public string DefaultResponse { get; set; } =
            "I can help you with sustainable fashion choices like upcycling, thrifting, donating clothes, swapping clothes, and more!";
    }
}
