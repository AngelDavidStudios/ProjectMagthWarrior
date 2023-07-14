using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class ArithmeticQuizzes : IEnumerable<Model.MathQuiz>
{

    private readonly List<Model.MathQuiz> _quizzes = new List<Model.MathQuiz>();

    public IEnumerator<Model.MathQuiz> GetEnumerator() => _quizzes.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public ArithmeticQuizzes()
    {
        GenerateQuestions();
    }

    private void GenerateQuestions()
    {
        GenerateArithmeticQuestions();
    }

    private void GenerateArithmeticQuestions()
    {
        // Preguntas de Aritmetica
        AddQuestionWithOptions("8 + 5 × 2 = ?", "18", new[] { "18", "16", "20", "23" });
        AddQuestionWithOptions("12 ÷ 3 + 4 = ?","8", new[] { "8", "9", "10", "12" });
        AddQuestionWithOptions("3 × (4 + 2) = ?","18", new[] { "18", "12", "24", "36" });
        AddQuestionWithOptions("7 - 2 + 3 = ?","8", new[] { "8", "7", "10", "6" });
        AddQuestionWithOptions("15 ÷ 5 × 3 = ?", "9", new[] { "9", "3", "6", "15" });
        AddQuestionWithOptions("2 + 3 × 4 - 5 = ?","9", new[] { "9", "7", "11", "13" });
        AddQuestionWithOptions("20 - (6 + 3) = ?","11", new[] { "11", "14", "17", "8" });
        AddQuestionWithOptions("4 × (8 ÷ 2) = ?", "16", new[] { "16", "12", "8", "24" });
        AddQuestionWithOptions("1/4 + 1/2 = ?", "3/4", new[] { "3/4", "1/6", "3/8", "5/8" });
        AddQuestionWithOptions("5/8 - 1/4 = ?", "3/8", new[] { "3/8", "1/8", "7/8", "1/4" });
        AddQuestionWithOptions("3/5 × 2/3 = ?", "2/5", new[] { "2/5", "1/3", "2/9", "6/15" });
        AddQuestionWithOptions("20% de 80 = ?", "16",  new[] { "16", "8", "20", "40" });
        AddQuestionWithOptions("30% de $50 = ?", "$15", new[] { "$15", "$10", "$20", "$30" });
        AddQuestionWithOptions("(10 + 4) × (6 - 3) = ?","42", new[] { "42", "24", "23", "20" });
        AddQuestionWithOptions("Raiz cuadrada de 225 ?","15", new[] { "15", "20", "5", "25" });
        AddQuestionWithOptions("4^2 ÷ 2 + 3 × 2 = ?","14", new[] { "14", "18", "20", "24" });
        AddQuestionWithOptions("(8 + 2) × (5 - 3) = ?","20", new[] { "20", "16", "24", "30" });
        AddQuestionWithOptions("Cual es x: 2x + 3 = 11","4", new[] { "4", "2", "6", "7" });
        AddQuestionWithOptions("Promedio de 10, 12, y 17.","13", new[] { "13", "11", "17", "14" });
        AddQuestionWithOptions("Raiz cuadrada de 144.", "12", new[] { "12", "9", "16", "18" });

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