
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ms.Person.MassTransit
{
    public static class MassTransitConfiguration
    {
        public static IServiceCollection configureMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {

                    config.Host(new Uri("rabbitmq://localhost/"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                }));
               
            }).AddMassTransitHostedService();
            return services;
        }

    }
}
