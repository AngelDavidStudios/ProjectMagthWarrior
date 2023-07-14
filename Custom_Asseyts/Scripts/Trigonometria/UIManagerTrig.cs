using System.Collections;
using MyGame;
using UnityEngine;

namespace Game
{
    public class UIManagerTrig : MonoBehaviour
    {
        [SerializeField] private GameOverPanelTrig _gameOverPanel;
        [SerializeField] private GamePlayPanelTrig _gamePlayPanel;


        public GameOverPanelTrig GameOverPanel => _gameOverPanel;
        public GamePlayPanelTrig GamePlayPanel => _gamePlayPanel;
        public static UIManagerTrig Instance { get; private set; }


        private void Awake()
        {
            Instance = this;

        }

        private void OnEnable()
        {
            LevelManagerTrig.GameStarted += GameManagerOnGameStarted;
            LevelManagerTrig.GameOver += LevelManagerOnGameOver;
        }


        private void OnDisable()
        {
            LevelManagerTrig.GameStarted -= GameManagerOnGameStarted;
            LevelManagerTrig.GameOver -= LevelManagerOnGameOver;
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

