// <copyright file="DownloaderRequestMessage.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

namespace MajungaLibrary.Services.Models.MessageQueue
{
    using System;

    /// <summary>
    /// Message sent to Downloader Service
    /// </summary>
    public class DownloaderRequestMessage
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets Url
        /// </summary>
        public Uri Url { get; set; }
    }
}
