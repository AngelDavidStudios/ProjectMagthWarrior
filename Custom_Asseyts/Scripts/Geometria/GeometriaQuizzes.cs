using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class GeometriaQuizzes : IEnumerable<Model.MathQuiz>
{

    private readonly List<Model.MathQuiz> _quizzes = new List<Model.MathQuiz>();

    public IEnumerator<Model.MathQuiz> GetEnumerator() => _quizzes.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public GeometriaQuizzes()
    {
        GenerateQuestions();
    }

    private void GenerateQuestions()
    {
        GenerateArithmeticQuestions();
    }

    private void GenerateArithmeticQuestions()
    {
        // Preguntas de Geometria
        AddQuestionWithOptions("Area de un triángulo B = 6 cm y A= 4 cm", "12", new[] { "12", "18", "24", "8" });
        AddQuestionWithOptions("Perímetro de un cuadrado L = 5 cm", "20", new[] { "20", "10", "15", "25" });
        AddQuestionWithOptions("Area de un círculo con R= 3 cm", "9π", new[] { "9π", "6π", "12π", "3π" });
        AddQuestionWithOptions("Perímetro de un rectángulo L= 8 cm y A= 3 cm", "22", new[] { "22", "24", "26", "28" });
        AddQuestionWithOptions("Area de un trapecio B= 5 cm, L= 8 cm, y A= 6 cm?", "33", new[] { "33", "20", "28", "40" });
        AddQuestionWithOptions("Perímetro de un triángulo equilátero L= 6 cm?", "18", new[] { "18", "12", "24", "36" });
        AddQuestionWithOptions("Area de un círculo con D= 10 cm", "25π", new[] { "25π", "50π", "100π", "10π" });
        AddQuestionWithOptions("Perímetro de un pentágono regular con L= 7 cm", "35", new[] { "35", "21", "42", "28" });
        AddQuestionWithOptions("Area de un rectángulo L= 12 cm y A= 5 cm", "60", new[] { "60", "17", "30", "72" });
        AddQuestionWithOptions("Perímetro de un círculo con R= 4 cm", "8π", new[] { "8π", "16π", "4π", "32π" });
        AddQuestionWithOptions("Area de un cuadrado con lado de 9 cm", "81", new[] { "81", "18", "27", "72" });
        AddQuestionWithOptions("Area de un círculo R= 6 cm", "36π", new[] { "36π", "12π", "72π", "6π" });
        AddQuestionWithOptions("Area de un trapecio con B= 6 cm y L= 10 cm, y A= 7 cm", "49", new[] { "49", "16", "28", "64" });
        AddQuestionWithOptions("Perímetro de un triángulo equilátero con L= 9 cm", "27", new[] { "27", "18", "36", "54" });
        AddQuestionWithOptions("Area de un círculo D= 14 cm?", "49π", new[] { "49π cm^2", "98π", "196π", "7π" });
        AddQuestionWithOptions("Perímetro de un pentágono regular L= 10 cm", "50", new[] { "50", "25", "100", "20" });
        AddQuestionWithOptions("Area de un rectángulo L= 15 cm y A= 8 cm", "120", new[] { "120", "23", "45", "60" });
        AddQuestionWithOptions("Perímetro de un círculo con R= 5 cm", "10π", new[] { "10π", "20π", "5π", "25π" });


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