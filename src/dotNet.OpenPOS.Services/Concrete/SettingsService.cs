using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Services.Interfaces;

namespace dotNet.OpenPOS.Services.Concrete
{
    public class SettingsService : ISettingsService
    {
        private readonly IDatabaseContext _context;

        public SettingsService(IDatabaseContext context)
        {
            _context = context;
        }

        public void RefreshDatabaseContext()
        {
            _context.Initialize();
        }
    }
}
