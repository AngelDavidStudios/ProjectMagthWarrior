using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class TrigonometriaQuizzes : IEnumerable<Model.MathQuiz>
{

    private readonly List<Model.MathQuiz> _quizzes = new List<Model.MathQuiz>();

    public IEnumerator<Model.MathQuiz> GetEnumerator() => _quizzes.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public TrigonometriaQuizzes()
    {
        GenerateQuestions();
    }

    private void GenerateQuestions()
    {
        GenerateArithmeticQuestions();
    }

    private void GenerateArithmeticQuestions()
    {
        // Preguntas de Trigonometria
        AddQuestionWithOptions("Seno (30°) = ?", "1/2", new[] { "1/2", "√3/2", "√2/2", "√6/2" });
        AddQuestionWithOptions("Coseno (45°) = ?", "1/√2", new[] { "√2/2", "1/√2", "√3/2", "√6/2" });
        AddQuestionWithOptions("Tangente (60°) = ?", "√3", new[] { "√3", "1/√3", "1", "2" });
        AddQuestionWithOptions("Seno (45°) = ?", "√2/2", new[] { "√2/2", "1/2", "1", "√3/2" });
        AddQuestionWithOptions("Coseno (60°) = ?", "1/2", new[] { "1/2", "√3/2", "1", "√2/2" });
        AddQuestionWithOptions("Tangente (30°) = ?", "1/√3", new[] { "1/√3", "√3", "1", "2" });
        AddQuestionWithOptions("Seno (90°) = ?", "1", new[] { "1", "0", "1/2", "√2/2" });
        AddQuestionWithOptions("Coseno (90°) = ?", "0", new[] { "0", "1", "1/2", "√2/2" });
        AddQuestionWithOptions("Tangente (90°) = ?", "∞", new[] { "∞", "1", "1/2", "√2/2" });
        AddQuestionWithOptions("Seno (0°) = ?", "0", new[] { "0", "1", "1/2", "√2/2" });
        AddQuestionWithOptions("Coseno (0°) = ?", "1", new[] { "1", "0", "1/2", "√2/2" });
        AddQuestionWithOptions("Tangente (0°) = ?", "0", new[] { "0", "1", "1/2", "√2/2" });
        AddQuestionWithOptions("Seno (60°) = ?", "√3/2", new[] { "√3/2", "1/2", "1", "√2/2" });
        AddQuestionWithOptions("Coseno (60°) = ?", "1/2", new[] { "1/2", "√3/2", "1", "√2/2" });
        AddQuestionWithOptions("Tangente (45°) = ?", "1", new[] { "1", "1/√3", "√2/2", "√6/2" });
        AddQuestionWithOptions("Seno (120°) = ?", "√3/2", new[] { "√3/2", "1/2", "1", "√2/2" });
        AddQuestionWithOptions("Coseno (150°) = ?", "-√3/2", new[] { "-√3/2", "1/2", "1", "√2/2" });
        AddQuestionWithOptions("Tangente (135°) = ?", "-1", new[] { "-1", "1/√3", "1", "√2/2" });
        AddQuestionWithOptions("Seno (180°) = ?", "0", new[] { "0", "1", "1/2", "√2/2" });
        AddQuestionWithOptions("Coseno (270°) = ?", "0", new[] { "-1", "0", "1/2", "√2/2" });



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

