/*
 * MIT License
 * 
 * Copyright(c) 2020 Jakub Findura
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 */

using CoAPtain;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/> interface.
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Register CoAPtain to <see cref="IServiceCollection"/>
        /// </summary>
        public static IServiceCollection AddCoAPtain(this IServiceCollection services, Action<CoAPtainOptions> action)
        {
            services.AddHostedService<CoAPtainHostedService>();

            services.Configure(action);

            return services;
        }
    }
}
