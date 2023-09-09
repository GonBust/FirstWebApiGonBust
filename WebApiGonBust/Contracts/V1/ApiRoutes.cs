﻿namespace WebApiGonBust.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = $"{Root}/{Version}";
        public static class Forecasts
        {
            public const string GetAll = Base + "/forecasts";

            public const string Get = Base + "/forecasts/{forecastId}";

            public const string Update = Base + "/forecasts/{forecastId}";

            public const string Create = Base + "/forecasts";

            public const string Delete = Base + "/forecasts/{forecastId}";
        }
    }
}