// <copyright file="RabbitMQService.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

namespace MajungaLibrary.BusinessLogic.Services
{
    using System.Text;
    using MajungaLibrary.BusinessLogic.Services.Interfaces;
    using MajungaLibrary.BusinessLogic.Services.Models.MessageQueue;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    /// <summary>
    /// RabbitMQ Service
    /// <inheritdoc/>
    /// </summary>
    public class RabbitMQService : IMessageQueuing
    {
        private readonly IConnection rabbitMQConnection;
        private readonly MQConnection mqConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMQService"/> class.
        /// </summary>
        /// <param name="connection">MQ Connection Details</param>
        public RabbitMQService(MQConnection connection)
        {
            this.mqConnection = connection;

            var factory = new ConnectionFactory() { HostName = connection.Host };
            this.rabbitMQConnection = factory.CreateConnection();
            this.Channel = this.rabbitMQConnection.CreateModel();
            this.Channel.QueueDeclare(
                queue: this.mqConnection.Channel,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        /// <summary>
        /// Gets channel to use
        /// </summary>
        public IModel Channel { get; }

        /// <inheritdoc/>
        public void QueueMessage(string serialisedMessage)
        {
            var body = Encoding.UTF8.GetBytes(serialisedMessage);

            this.Channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: this.mqConnection.RoutingKey,
                    basicProperties: null,
                    body: body);
        }

        /// <inheritdoc/>
        public void QueueMessage<T>(T message)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            this.Channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: this.mqConnection.RoutingKey,
                    basicProperties: null,
                    body: body);
        }

        /// <inheritdoc/>
        public void CreateConsumer(EventingBasicConsumer consumer)
        {
            this.Channel.BasicConsume(
                queue: this.mqConnection.Channel,
                autoAck: true,
                consumer: consumer);
        }

        /// <inheritdoc/>
        public uint ReadQueueCount()
        {
            return this.Channel.MessageCount(queue: this.mqConnection.Channel);
        }

        /// <inheritdoc/>
        public void Destroy()
        {
            this.Channel.QueueDelete(this.mqConnection.Channel);
        }

        /// <summary>
        /// Dispose of RabbitMQ
        /// </summary>
        public void Dispose()
        {
            this.Channel.Dispose();
            this.rabbitMQConnection.Dispose();
        }
    }
}
