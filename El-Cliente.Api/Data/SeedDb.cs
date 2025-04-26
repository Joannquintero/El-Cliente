using El_Cliente.Shared.Entities;
using Microsoft.EntityFrameworkCore;

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
            await CheckAvailabilityAsync();
            await CheckPRegistrationsAsync();
        }

        private async Task CheckBranchsAsync()
        {
            if (!_context.Branchs.Any())
            {
                _context.Branchs.Add(new Branch { Name = "Sucursal Centro El Poblado", City = "Medellín" });
                _context.Branchs.Add(new Branch { Name = "Sucursal Centro Chapinero", City = "Bogotá" });
                _context.Branchs.Add(new Branch { Name = "Sucursal Oriente Cali", City = "Cali" });
                _context.Branchs.Add(new Branch { Name = "Sucursal Centro Bucaramanga", City = "Bucaramanga" });
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

        private async Task CheckAvailabilityAsync()
        {
            if (!_context.Availability.Any())
            {
                var branch = _context.Branchs.FirstOrDefaultAsync(x => x.Id == 1);
                var productFirt = _context.Products.FirstOrDefaultAsync(x => x.Id == 1);
                var productSecund = _context.Products.FirstOrDefaultAsync(x => x.Id == 2);
                var productTree = _context.Products.FirstOrDefaultAsync(x => x.Id == 3);
                var productFour = _context.Products.FirstOrDefaultAsync(x => x.Id == 4);
                var productFive = _context.Products.FirstOrDefaultAsync(x => x.Id == 5);

                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productFirt.Result! });
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productTree.Result! });
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productFive.Result! });
                await _context.SaveChangesAsync();

                branch = _context.Branchs.FirstOrDefaultAsync(x => x.Id == 2);
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productTree.Result! });
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productFour.Result! });
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productFive.Result! });
                await _context.SaveChangesAsync();

                branch = _context.Branchs.FirstOrDefaultAsync(x => x.Id == 3);
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productFirt.Result! });
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productSecund.Result! });
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productFour.Result! });
                await _context.SaveChangesAsync();

                branch = _context.Branchs.FirstOrDefaultAsync(x => x.Id == 4);
                _context.Availability.Add(new Availability { Branch = branch.Result!, Product = productSecund.Result! });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPRegistrationsAsync()
        {
            if (!_context.Customers.Any())
            {
                var customer = new Customer { Name = "Juan", Surnames = "Sotelo Rodriguez", City = "Medellín" };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                if (customer.Id > 0)
                {
                    var product = _context.Products.FirstOrDefaultAsync(x => x.Id == 1);
                    _context.Registrations.Add(new Registration { Customer = customer, Product = product.Result!, IsActive = true });
                    _context.Balances.Add(new Balance { Customer = customer, Amount = 500000 });
                    await _context.SaveChangesAsync();
                }

                customer = new Customer { Name = "Andres", Surnames = "Macias Restrepo", City = "Bogotá" };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                if (customer.Id > 0)
                {
                    var product = _context.Products.FirstOrDefaultAsync(x => x.Id == 2);
                    _context.Registrations.Add(new Registration { Customer = customer, Product = product.Result!, IsActive = true });
                    _context.Balances.Add(new Balance { Customer = customer, Amount = 500000 });
                    await _context.SaveChangesAsync();
                }

                customer = new Customer { Name = "Maria", Surnames = "Pedroza Santos", City = "Cali" };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                if (customer.Id > 0)
                {
                    var product = _context.Products.FirstOrDefaultAsync(x => x.Id == 4);
                    _context.Registrations.Add(new Registration { Customer = customer, Product = product.Result!, IsActive = true });
                    _context.Balances.Add(new Balance { Customer = customer, Amount = 500000 });
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}