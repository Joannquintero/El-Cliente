using El_Cliente.Shared.Entities;

namespace El_Cliente.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckBranchsAsync();
            await CheckProductsAsync();
        }

        private async Task CheckBranchsAsync()
        {
            if (!_context.Branchs.Any())
            {
                _context.Branchs.Add(new Branch { Name = "Sucursal Centro El Poblado", City = "Medellín" });
                _context.Branchs.Add(new Branch { Name = "Sucursal Centro Chapinero", City = "Bogotá" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product { Name = "FPV_EL CLIENTE_RECAUDADORA", MinimumAmount = 75000, Category = "FPV" });
                _context.Products.Add(new Product { Name = "FPV_EL CLIENTE_ECOPETROL", MinimumAmount = 125000, Category = "FPV" });
                _context.Products.Add(new Product { Name = "DEUDAPRIVADA", MinimumAmount = 125000, Category = "FIC" });
                _context.Products.Add(new Product { Name = "FDO-ACCIONES", MinimumAmount = 250000, Category = "FIC" });
                _context.Products.Add(new Product { Name = "FPV_EL CLIENTE_DINAMICA", MinimumAmount = 100000, Category = "FPV" });
                await _context.SaveChangesAsync();
            }
        }
    }
}