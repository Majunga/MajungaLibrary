// <copyright file="IMessageQueuing.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

namespace MajungaLibrary.BusinessLogic.Services.Interfaces
{
    using RabbitMQ.Client.Events;
    using System;

    /// <summary>
    /// Message Queue Interface
    /// </summary>
    public interface IMessageQueuing : IDisposable
    {
        /// <summary>
        /// Queue Message
        /// </summary>
        /// <param name="serialisedMessage">Message to send</param>
        void QueueMessage(string serialisedMessage);

        /// <summary>
        /// Queue Message
        /// </summary>
        /// <typeparam name="T">Generic Message Type</typeparam>
        /// <param name="message">Message to send</param>
        void QueueMessage<T>(T message);

        /// <summary>
        /// Create consumer to read messages
        /// </summary>
        /// <param name="consumer">Consumer Event</param>
        void CreateConsumer(EventingBasicConsumer consumer);

        /// <summary>
        /// Count the number of messages in the Queue
        /// </summary>
        /// <returns>Count of messages</returns>
        uint ReadQueueCount();

        /// <summary>
        /// Destroy a queue
        /// </summary>
        void Destroy();
    }
}
