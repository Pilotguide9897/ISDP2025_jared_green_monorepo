using idsp2025_jared_green.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace idsp2025_jared_green.Factories
{
    internal class DbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BullseyeContext CreateBullseyeContext()
        {
            return _serviceProvider.GetRequiredService<BullseyeContext>();
        }
    }
}