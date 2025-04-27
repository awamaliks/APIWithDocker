using UsersServices;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();

                // Your custom Kestrel config
                webBuilder.ConfigureKestrel(options =>
                {
                    options.ListenAnyIP(80);
                });
            });
}


//Docker build -t user1:v1 - f UsersServices / Dockerfile.
//Docker build -t pro1:v6 - f ProductsServices / Dockerfile.

//docker run -p 8080:5067 yourimagename