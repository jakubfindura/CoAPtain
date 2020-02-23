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

using Com.AugustCellars.CoAP.Net;
using Com.AugustCellars.CoAP.Server.Resources;
using System;
using System.Collections.Generic;

namespace CoAPtain
{
    /// <summary>
    /// 
    /// </summary>
    public class CoAPtainOptions
    {
        private readonly ICollection<(string, Resource)> resources;
        private readonly ICollection<IEndPoint> endpoints;

        /// <summary>
        /// List of <see cref="Resource"/>, which will be added to CoAP server
        /// </summary>
        public IEnumerable<(string, Resource)> Resources => resources;

        /// <summary>
        /// List of <see cref="IEndPoint"/>, which will be used by the CoAP server.
        /// </summary>
        public IEnumerable<IEndPoint> EndPoints => endpoints;

        /// <summary>
        /// Initializes a instance of <see cref="CoAPtainOptions"/>.
        /// </summary>
        public CoAPtainOptions()
        {
            resources = new List<(string, Resource)>();
            endpoints = new List<IEndPoint>();
        }

        /// <summary>
        /// Add a <see cref="Resource"/> to CoAP server.
        /// </summary>
        /// <param name="resource">Resource to add</param>
        public void AddResource(Resource resource)
        {
            if (resource == null) throw new ArgumentNullException($"resource cannot be null");
            AddResource("", resource);
        }

        /// <summary>
        /// Add a <see cref="Resource"/> to CoAP server under specified path.
        /// </summary>
        /// <param name="path">Path to the resource</param>
        /// <param name="resource">Resource to add</param>
        public void AddResource(string path, Resource resource)
        {
            if (resource == null) throw new ArgumentNullException($"resource cannot be null");
            resources.Add((path, resource));
        }

        /// <summary>
        /// Add a <see cref="IEndPoint"/> to CoAP server.
        /// </summary>
        /// <param name="endPoint">End point to add</param>
        public void AddEndPoint(IEndPoint endPoint)
        {
            if (endPoint == null) throw new ArgumentNullException($"endpoint cannot be null");
            endpoints.Add(endPoint);
        }

    }
}
