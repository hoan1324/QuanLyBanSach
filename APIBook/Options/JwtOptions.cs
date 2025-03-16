﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBook.Options
{
    public class JwtOptions
    {
        public required string Secret { get; set; }
        public required string Audience { get; set; }
        public required string Issuer { get; set; }
        public int AccessTokenExpireMinutes { get; set; }
        public int ExpireTokenExpireDays { get; set; }
    }
}
