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

using Com.AugustCellars.CoAP.Server;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace CoAPtain
{
    /// <summary>
    /// Hosted service for CoAP server.
    /// </summary>
    public class CoAPtainHostedService : IHostedService
    {
        private readonly ILogger<CoAPtainHostedService> logger;
        private readonly IOptions<CoAPtainOptions> options;
        private CoapServer server;

        /// <summary>
        /// Initializes a instance of <see cref="CoAPtainHostedService"/>.
        /// </summary>
        public CoAPtainHostedService(ILogger<CoAPtainHostedService> logger, IOptions<CoAPtainOptions> options)
        {
            this.logger = logger;
            this.options = options;
        }

        /// <inheritdoc/>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting CoAP host service");

            server = new CoapServer();

            foreach (var r in options.Value.Resources)
            {
                server.Add(r.Item1, r.Item2);
                logger.LogTrace($"Registering resource {r.Item2.Name}, path={r.Item2.Path}");
            }

            server.Start();

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Stopping CoAP host service");

            server.Stop();

            return Task.CompletedTask;
        }
    }
}