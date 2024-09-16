namespace Class.TriviaGame.Infrastructure.DB.Models;

public static class PreMadeQuestions
{
    public static readonly List<Question> Questions =
    [
        new Question(
            1,
            "What is the capital of France?",
            ["London", "Berlin", "Madrid", "Paris"],
            "Paris",
            1),
        new Question(
            2,
            "What is 5 + 3?",
            ["6", "8", "9", "10"],
            "8",
            1),
        new Question(
            3,
            "Which animal makes the sound \"meow\"?",
            ["Dog", "Cow", "Cat", "Horse"],
            "Cat",
            1),
        new Question(
            4,
            "What is the longest river in the world?",
            ["Mississippi", "Amazon", "Yangtze", "Nile"],
            "Amazon",
            1),
        new Question(
            5,
            "Which of these colors is primary?",
            ["Green", "Purple", "Blue", "Orange"],
            "Blue",
            1),
        new Question(
            6,
            "Which gas is necessary for breathing?",
            ["Nitrogen", "Oxygen", "Hydrogen", "Carbon dioxide"],
            "Oxygen",
            1),
        new Question(
            7,
            "How many days are in a leap year?",
            ["364", "366", "365", "367"],
            "366",
            1),
        new Question(
            8,
            "Which ocean is the largest?",
            ["Atlantic", "Indian", "Pacific", "Arctic"],
            "Pacific",
            1),
        new Question(
            9,
            "Who wrote \"Hamlet\"?",
            ["Charles Dickens", "Leo Tolstoy", "William Shakespeare", "Jane Austen"],
            "William Shakespeare",
            1),
        new Question(
            10,
            "Which metal is the lightest?",
            ["Iron", "Aluminium", "Gold", "Copper"],
            "Aluminium",
            1),
    ];
}