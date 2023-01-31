using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Ms.User.Consumers;
using System;
using System.Reflection;

namespace Ms.User.MassTransitConfiguration
{
    public static class MassTransitConfiguration
    {

        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
        {

            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserCreatedConsumer>();
                x.AddConsumer<UserUpdateConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Username("guest");
                    });

                    cfg.ReceiveEndpoint("UserCreated", endpoint =>
                    {
                        endpoint.BindQueue = true;
                        endpoint.PrefetchCount = 10;
                        endpoint.UseMessageRetry(r => r.Interval(2, 100));
                        endpoint.ConfigureConsumer<UserCreatedConsumer>(provider);
                    });

                    cfg.ReceiveEndpoint("UserUpdated", endpoint =>
                    {
                        endpoint.BindQueue = true;
                        endpoint.PrefetchCount = 10;
                        endpoint.UseMessageRetry(r => r.Interval(2, 100));
                        endpoint.ConfigureConsumer<UserUpdateConsumer>(provider);
                    });


                    cfg.ReceiveEndpoint("UserDelete", endpoint =>
                    {
                        endpoint.BindQueue = true;
                        endpoint.PrefetchCount = 10;
                        endpoint.UseMessageRetry(r => r.Interval(2, 100));
                        endpoint.ConfigureConsumer<UserDeleteConsumer>(provider);
                    });

                }));
            }).AddMassTransitHostedService();

            return services;
        }
    }
}
