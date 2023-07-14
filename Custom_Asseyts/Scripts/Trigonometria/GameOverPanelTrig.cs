using System;
using MyGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


namespace Game
{
    public class GameOverPanelTrig : ShowHidable
    {
        [SerializeField] private Button _restartBtn;
        [SerializeField] private TextMeshProUGUI _scoreTxt;
        [SerializeField] private TextMeshProUGUI _bestTxt;

        public void OnClickRestart()
        {
            MyGame.GameManager.LoadGameOnePlayer(new LoadGameData(), false);
        }

        public override void Show(bool animate = true, Action completed = null)
        {
            ShowRestart();

            _scoreTxt.text = LevelManagerTrig.Instance.Score.ToString();
            _bestTxt.text = $"BEST - {GameManager.BEST_SCORE}";

            if (LevelManagerTrig.Instance.BestScoreArchived && RatingPopUp.Available)
            {

            }

            base.Show(animate, completed);
        }


        public void OnClickMenu()
        {
            GameManager.LoadScene("Menu");
        }

        private void ShowRestart()
        {
            _restartBtn.gameObject.SetActive(true);
        }
    }
}

