using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;


namespace Model
{
    [System.Serializable]
    public struct MathQuiz
    {
        public string[] quiz;
        public string[] answers;
        public int correctIndex;
        public Vector2Int hardnessRange;
    }

}