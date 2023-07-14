using System.Collections;
using MyGame;
using UnityEngine;

namespace Game
{
    public class UIManagerArithmetic : MonoBehaviour
    {
        [SerializeField] private GameOverpanelArit _gameOverPanel;
        [SerializeField] private GamePlayPanelArit _gamePlayPanel;


        public GameOverpanelArit GameOverPanel => _gameOverPanel;
        public GamePlayPanelArit GamePlayPanel => _gamePlayPanel;
        public static UIManagerArithmetic Instance { get; private set; }


        private void Awake()
        {
            Instance = this;

        }

        private void OnEnable()
        {
            LevelManagerArithmetic.GameStarted += GameManagerOnGameStarted;
            LevelManagerArithmetic.GameOver += LevelManagerOnGameOver;
        }


        private void OnDisable()
        {
            LevelManagerArithmetic.GameStarted -= GameManagerOnGameStarted;
            LevelManagerArithmetic.GameOver -= LevelManagerOnGameOver;
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
