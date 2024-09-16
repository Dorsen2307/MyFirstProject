using Class.TriviaGame.Domain.Dekanat.Models;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IDekanat, Dekanat>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var dekanat = serviceProvider.GetRequiredService<IDekanat>();

dekanat.Start();