using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using DummyBinding;

[assembly: FunctionsStartup(typeof(funcapp.Startup))]

namespace funcapp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            
            builder.Services.AddSingleton<IDummyBindingService>((s) => {
                return new DummyBindingServiceImplementation();
            });
        }

        private class DummyBindingServiceImplementation : IDummyBindingService {
        public string GetMessage () {
            return "From the service";
        }
        }
    }
}