using System.Collections;
using MyGame;
using UnityEngine;

namespace Game
{
    public class UIManagerAlg : MonoBehaviour
    {
        [SerializeField] private GameOverPanelAlg _gameOverPanel;
        [SerializeField] private GamePlayPanelAlg _gamePlayPanel;


        public GameOverPanelAlg GameOverPanel => _gameOverPanel;
        public GamePlayPanelAlg GamePlayPanel => _gamePlayPanel;
        public static UIManagerAlg Instance { get; private set; }


        private void Awake()
        {
            Instance = this;

        }

        private void OnEnable()
        {
            LevelManagerAlg.GameStarted += GameManagerOnGameStarted;
            LevelManagerAlg.GameOver += LevelManagerOnGameOver;
        }


        private void OnDisable()
        {
            LevelManagerAlg.GameStarted -= GameManagerOnGameStarted;
            LevelManagerAlg.GameOver -= LevelManagerOnGameOver;
        }

        private void LevelManagerOnGameOver()
        {
            StartCoroutine(GameOver());
        }

        IEnumerator GameOver()
        {

            yield return new WaitForSeconds(.5f);
            _gameOverPanel.Show();


        }

        private void GameManagerOnGameStarted()
        {
            GamePlayPanel.Show();
        }
    }


}
