using ElectronNET.API;

namespace backend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddElectron();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // Serve static files from wwwroot/browser at the root URL
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapApiEndpoints();
                endpoints.MapFallbackToFile("index.html"); // Fallback to index.html for Angular routes
            });

            if (HybridSupport.IsElectronActive)
            {
                CreateElectronWindow();
            }
        }


        public async void CreateElectronWindow()
        {
            var options = new ElectronNET.API.Entities.BrowserWindowOptions
            {
                Width = 800,
                Height = 600,
                Show = true
            };
            var window = await Electron.WindowManager.CreateWindowAsync(options);

            window.OnClosed += () => Electron.App.Quit();

            window.WebContents.OpenDevTools(); // Open Developer Tools
        }
    }
}