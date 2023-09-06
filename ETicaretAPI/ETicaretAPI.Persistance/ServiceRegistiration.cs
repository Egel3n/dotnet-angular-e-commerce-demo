using ETicaretAPI.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ETicaretAPI.Application.Repositories.Product;
using ETicaretAPI.Persistance.Repositories.Product;
using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Persistance.Repositories.Order;
using ETicaretAPI.Application.Repositories.Customer;
using ETicaretAPI.Persistance.Repositories.Customer;
using FluentValidation;
using ETicaretAPI.Application.Validators.Products;

namespace ETicaretAPI.Persistance
{
    public static class ServiceRegistiration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        { 
            services.AddDbContext<ETicaretApiDbContext>(options => options.UseNpgsql(Configurations.ConnectionString));
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
          
        }

    }
}
