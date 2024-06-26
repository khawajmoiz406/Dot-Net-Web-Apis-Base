﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YatchMasterWS.Utils.Helper
{
    public class ConfigHelper
    {
        public static IConfiguration? configuration;

        public static string GetConnectionString(string value)
        {
           return configuration.GetConnectionString(value);
        }

        public static string GetAppSettings (string value)
        {
            return configuration?.GetSection("AppSettings")[value] ?? "";
        }

        public static IConfiguration? GetSection(string name)
        {
            return configuration?.GetSection(name) ?? null;
        }
    }
}
