using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testdbfirst.Repository.ImplRepository;
using testdbfirst.Repository.IRepository;

namespace testdbfirst.Repository.RepositoryConfig
{
    public static class ConfigRepository
    {
        public static void ConfigRepositoryService(IServiceCollection services)
        {
            //repository cofig
            services.AddTransient<IRefProductCategories, RefProductCategoriesImpl>();
            services.AddTransient<IProduct, ProductImpl>();
            services.AddTransient<ICustomerOrders, CustomerOrdersImpl>();
            services.AddTransient<ICustomer, CustomerImpl>();
            services.AddTransient<IOrderItem, OrderItemImpl>();
        }
    }
}
