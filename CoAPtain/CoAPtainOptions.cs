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

using Com.AugustCellars.CoAP.Server.Resources;
using System.Collections.Generic;

namespace CoAPtain
{
    /// <summary>
    /// 
    /// </summary>
    public class CoAPtainOptions
    {
        private ICollection<(string, Resource)> resources;

        /// <summary>
        /// List of <see cref="Resource"/>, which will be added to CoAP server
        /// </summary>
        public IEnumerable<(string, Resource)> Resources => resources;

        /// <summary>
        /// Initializes a instance of <see cref="CoAPtainOptions"/>.
        /// </summary>
        public CoAPtainOptions()
        {
            resources = new List<(string, Resource)>();
        }

        /// <summary>
        /// Add a <see cref="Resource"/> to CoAP server.
        /// </summary>
        /// <param name="resource">Resource to add</param>
        public void AddResource(Resource resource)
        {
            AddResource("", resource);
        }

        /// <summary>
        /// Add a <see cref="Resource"/> to CoAP server under specified path.
        /// </summary>
        /// <param name="path">Path to the resource</param>
        /// <param name="resource">Resource to add</param>
        public void AddResource(string path, Resource resource)
        {
            resources.Add((path, resource));
        }
    }
}
