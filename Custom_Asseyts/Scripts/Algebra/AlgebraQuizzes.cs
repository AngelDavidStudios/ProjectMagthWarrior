using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class AlgebraQuizzes : IEnumerable<Model.MathQuiz>
{

    private readonly List<Model.MathQuiz> _quizzes = new List<Model.MathQuiz>();

    public IEnumerator<Model.MathQuiz> GetEnumerator() => _quizzes.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public AlgebraQuizzes()
    {
        GenerateQuestions();
    }

    private void GenerateQuestions()
    {
        GenerateArithmeticQuestions();
    }

    private void GenerateArithmeticQuestions()
    {
        // Preguntas de Algebra
        AddQuestionWithOptions("2x + 3x", "5x", new[] { "5x", "6x", "7x", "8x" });
        AddQuestionWithOptions("2x + 5 = 15", "5", new[] { "5", "10", "15", "20" });
        AddQuestionWithOptions("3(x + 2) - 2(2x - 1)", "7", new[] { "7", "12", "5", "10" });
        AddQuestionWithOptions("4x - 2x", "2x", new[] { "2x", "6x", "8x", "10x" });
        AddQuestionWithOptions("3(2x + 1) = 15", "2", new[] { "2", "3", "4", "5" });
        AddQuestionWithOptions("3(2x + 1) = 15", "2", new[] { "2", "3", "4", "5" });
        AddQuestionWithOptions("5(x - 3) = 2(x + 5)", "7", new[] { "7", "8", "9", "10" });
        AddQuestionWithOptions("4(x - 1) + 2 = 18", "5", new[] { "5", "6", "7", "8" });
        AddQuestionWithOptions("5 - 2x = 3x - 1", "1", new[] { "1", "2", "3", "4" });
        AddQuestionWithOptions("2(x + 5) = 3(x - 2)", "16", new[] { "16", "15", "14", "13" });
        AddQuestionWithOptions("5 - 2x = 3x - 1", "1", new[] { "1", "2", "3", "4" });
        AddQuestionWithOptions("2(x + 5) = 3(x - 2)", "16", new[] { "16", "15", "14", "13" });
        AddQuestionWithOptions("3(x - 1) = 2(x + 4)", "11", new[] { "11", "12", "13", "14" });
        AddQuestionWithOptions("5(x - 3) = 2(x + 5)", "7", new[] { "7", "8", "9", "10" });
        AddQuestionWithOptions("3x + 4 = 7", "1", new[] { "1", "2", "3", "4" });
        AddQuestionWithOptions("2(x - 4) = 10", "9", new[] { "9", "10", "11", "12" });
        AddQuestionWithOptions("5 - 2(2x + 3) = 1", "-2", new[] { "-2", "-1", "0", "1" });
        AddQuestionWithOptions("3(x + 2) + 2 = 5x", "-1", new[] { "-1", "0", "1", "2" });
        AddQuestionWithOptions("4 - 3x = 7 + 2x", "-1", new[] { "-1", "0", "1", "2" });

    }

    private void AddQuestionWithOptions(string question, string correctResult, string[] options)
    {
        var answers = new string[options.Length];
        Array.Copy(options, answers, options.Length);
        Array.Sort(answers);

        var correctIndex = Array.IndexOf(answers, correctResult);

        _quizzes.Add(new Model.MathQuiz
        {
            quiz = new[] { question },
            answers = answers,
            correctIndex = correctIndex,
            hardnessRange = new Vector2Int(-1, -1)
        });
    }
}

public partial class AlgebraQuizzes
{
    public const string QUIZZES_FIELD = nameof(_quizzes);
}

