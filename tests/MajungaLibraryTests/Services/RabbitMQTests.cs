// <copyright file="RabbitMQTests.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

namespace MajungaLibraryTests.Services
{
    using System;
    using System.Text;
    using System.Threading;
    using MajungaLibrary.BusinessLogic.Services;
    using MajungaLibrary.BusinessLogic.Services.Models.MessageQueue;
    using MajungaLibrary.Services.Models.MessageQueue;
    using Newtonsoft.Json;
    using RabbitMQ.Client.Events;
    using Xunit;

    /// <summary>
    /// Rabbit MQ Tests
    /// </summary>
    public class RabbitMQTests
    {
        [Fact]
        public void QueueMessageString()
        {
            var connection = new MQConnection
            {
                Host = "localhost",
                Channel = "QueueMessageString",
                RoutingKey = "QueueMessageString"
            };

            using (var mq = new RabbitMQService(connection))
            {
                mq.QueueMessage("Test");
                Thread.Sleep(500);

                Assert.True(mq.ReadQueueCount() > 0);

                mq.Destroy();
            }
        }

        [Fact]
        public void QueueMessageObject()
        {
            var connection = new MQConnection
            {
                Host = "localhost",
                Channel = "QueueMessageObject",
                RoutingKey = "QueueMessageObject"
            };

            using (var mq = new RabbitMQService(connection))
            {
                mq.QueueMessage(new { test = "test" });
                Thread.Sleep(500);

                Assert.True(mq.ReadQueueCount() > 0);

                mq.Destroy();
            }
        }

        [Fact]
        public void ReadQueuedMessageString()
        {
            var connection = new MQConnection
            {
                Host = "localhost",
                Channel = "ReadQueuedMessageString",
                RoutingKey = "ReadQueuedMessageString"
            };

            var message = "test";
            var value = string.Empty;

            using (var mq = new RabbitMQService(connection))
            {
                mq.QueueMessage(message);
                Thread.Sleep(500);

                Assert.True(mq.ReadQueueCount() > 0);

                var consumer = new EventingBasicConsumer(mq.Channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    value = Encoding.UTF8.GetString(body);
                };

                mq.CreateConsumer(consumer);

                Thread.Sleep(500);

                Assert.True(mq.ReadQueueCount() == 0);
                Assert.Equal(message, value);

                mq.Destroy();
            }
        }

        [Fact]
        public void ReadQueuedMessageObject()
        {
            var connection = new MQConnection
            {
                Host = "localhost",
                Channel = "ReadQueuedMessageObject",
                RoutingKey = "ReadQueuedMessageObject"
            };

            var message = new DownloaderRequestMessage
            {
                Id = Guid.NewGuid(),
                Url = new Uri("https://google.co.uk"),
                UserId = "test"
            };
            DownloaderRequestMessage value = null;

            using (var mq = new RabbitMQService(connection))
            {
                mq.QueueMessage(message);
                Thread.Sleep(500);

                Assert.True(mq.ReadQueueCount() > 0);

                var consumer = new EventingBasicConsumer(mq.Channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    value = JsonConvert.DeserializeObject<DownloaderRequestMessage>(Encoding.UTF8.GetString(body));
                };

                mq.CreateConsumer(consumer);

                Thread.Sleep(500);

                Assert.True(mq.ReadQueueCount() == 0);
                Assert.Equal(message.Id, value.Id);

                mq.Destroy();
            }
        }
    }
}
