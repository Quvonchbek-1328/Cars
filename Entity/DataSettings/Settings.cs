using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityContext.DataSettings
{
    public static class Settings
    {
        public static string? ConnectionString { get; set; }
        public static string? redisConnectionString { get; set; }

        public static bool IsProduct { get; set; }
        /// <summary>
        /// appsettings fayilidan LocalHostConnection string malumotini oladi
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string DataSettingClassLocalHostConnection(this IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("LocalConnection");
            IsProduct = Convert.ToBoolean(configuration.GetSection("IsProduct").Value);

            return ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string DataSettingClassRedisConnection(this IConfiguration configuration)
        {
            redisConnectionString = configuration.GetSection("Redis").GetSection("ConnectionStringRedis").Value;
            return redisConnectionString;
        }

    }

}
