using System.Collections;
using MyGame;
using UnityEngine;

namespace Game
{
    public class UIManagerGeom : MonoBehaviour
    {
        [SerializeField] private GameOverPanelGeom _gameOverPanel;
        [SerializeField] private GamePlayPanelGeom _gamePlayPanel;


        public GameOverPanelGeom GameOverPanel => _gameOverPanel;
        public GamePlayPanelGeom GamePlayPanel => _gamePlayPanel;
        public static UIManagerGeom Instance { get; private set; }


        private void Awake()
        {
            Instance = this;

        }

        private void OnEnable()
        {
            LevelManagerGeom.GameStarted += GameManagerOnGameStarted;
            LevelManagerGeom.GameOver += LevelManagerOnGameOver;
        }


        private void OnDisable()
        {
            LevelManagerGeom.GameStarted -= GameManagerOnGameStarted;
            LevelManagerGeom.GameOver -= LevelManagerOnGameOver;
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

