﻿namespace WebApiGonBust.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }

        public TimeSpan TokenLifetime { get; internal set; }
    }
}
