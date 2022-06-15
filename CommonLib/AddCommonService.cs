using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public static class AddCommonService
    {
        public static void AddCommonLibService(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options => options.UseSqlite("Data Source=Product.db"));
            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();
        }
    }
}
