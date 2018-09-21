// <copyright file="DownloaderResponseMessage.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

namespace MajungaLibrary.Services.Models.MessageQueue
{
    using System;

    /// <summary>
    /// Response message from Downloader Service
    /// </summary>
    public class DownloaderResponseMessage
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
        /// Gets or sets Filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasError
        /// </summary>
        public bool HasError { get; set; }

    }
}
