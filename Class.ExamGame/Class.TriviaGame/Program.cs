using Class.TriviaGame.Domain.Dekanat.Models;
using Class.TriviaGame.Infrastructure.DB.DataBases;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IQuestionDb, QuestionDb>();
serviceCollection.AddSingleton<IStatementDb, StatementDb>();
serviceCollection.AddSingleton<IDekanat, Dekanat>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var dekanat = serviceProvider.GetRequiredService<IDekanat>();

dekanat.Start();