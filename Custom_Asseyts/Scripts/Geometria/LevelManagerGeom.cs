using System;
using System.Collections;
using System.Linq;
using Model;
using MyGame;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LevelManagerGeom : MonoBehaviour
    {
        public static LevelManagerGeom Instance { get; private set; }
        public static event Action GameStarted;
        public static event Action GameOver;

        [SerializeField] private QuizTile[] _quizs = new QuizTile[1];
        [SerializeField] private AnswerTile[] _answers = new AnswerTile[4];
        [SerializeField] private float _answerTime = 10;
        [SerializeField] private Animator _resultAnim;
        [SerializeField] private AudioClip _correctClip, _wrongClip;

        private static readonly int WrongHash = Animator.StringToHash("Wrong");
        private static readonly int RightHash = Animator.StringToHash("Right");

        public int Score { get; private set; }

        public bool BestScoreArchived => Score >= GameManager.BEST_SCORE;

        public State CurrentState { get; private set; }
        public GameType GameType { get; private set; }

        public MathQuiz MathQuiz { get; set; }
        public bool HasShownNewQuiz { get; private set; }
        public float Timer { get; private set; }

        public float AnswerTime => _answerTime;

        private void Awake()
        {
            Instance = this;
            var loadGameData = GameManager.LoadGameData;
            GameType = loadGameData.GameType;
            Score = loadGameData.Score;

            foreach (var answerTile in _answers)
            {
                answerTile.Clicked += AnswerTileOnClicked;
            }

            StartCoroutine(ShowNextQuiz());
        }

        private void AnswerTileOnClicked(AnswerTile tile)
        {
            StartCoroutine(tile.Answer == MathQuiz.answers[MathQuiz.correctIndex] ? OnAnswerRight() : OnAnswerWrong());
        }

        private IEnumerator OnAnswerRight()
        {
            PlayClipIfCan(_correctClip);
            HasShownNewQuiz = false;
            Score += 10;
            _resultAnim.SetBool(RightHash, true);
            yield return new WaitForSeconds(0.3f);
            yield return ShowNextQuiz();
        }

        private IEnumerator ShowNextQuiz()
        {
            _resultAnim.SetBool(RightHash, false);
            _resultAnim.SetBool(WrongHash, false);
            MathQuiz = GetQuiz();

            for (var i = 0; i < MathQuiz.quiz.Length; i++)
            {
                _quizs[i].Text = MathQuiz.quiz[i];
            }

            for (var i = 0; i < MathQuiz.answers.Length; i++)
            {
                _answers[i].Answer = MathQuiz.answers[i];
            }

            _answers.ForEach(tile => tile.Intractable = false);
            _answers.ForEach(tile => tile.TriggerShowAnim());
            yield return new WaitForSeconds(0.3f);
            _answers.ForEach(tile => tile.Intractable = true);
            Timer = AnswerTime;
            HasShownNewQuiz = true;
        }

        private void PlayClipIfCan(AudioClip clip, float volume = 0.35f)
        {
            if (clip && AudioManager.IsSoundEnable)
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }

        private IEnumerator OnAnswerWrong()
        {
            PlayClipIfCan(_wrongClip);

            OverTheGame();
            _resultAnim.SetBool(WrongHash, true);

            yield return new WaitForSeconds(1);
        }

        public MathQuiz GetQuiz()
        {
            return ResourceManager.QuizzesGeom.GetRandom().Randomize();
        }

        public void StartTheGame()
        {
            CurrentState = State.Playing;
            GameManager.TOTAL_GAME_COUNT++;

            GameStarted?.Invoke();
        }

        private void Update()
        {
            if (CurrentState == State.GameOver)
                return;

            if (HasShownNewQuiz)
            {
                Timer = Mathf.Clamp(Timer - Time.deltaTime, 0, Mathf.Infinity);
                if (Timer <= 0)
                    OverTheGame();
            }
        }

        private void OverTheGame()
        {
            if (CurrentState == State.GameOver)
                return;

            CurrentState = State.GameOver;

            if (GameManager.BEST_SCORE < Score)
            {
                GameManager.BEST_SCORE = Score;
            }
            GameOver?.Invoke();
        }

        public enum State
        {
            None,
            Playing,
            GameOver
        }
    }
}

public struct ScoreInfoGeom
{
    public int Score { get; set; }
}