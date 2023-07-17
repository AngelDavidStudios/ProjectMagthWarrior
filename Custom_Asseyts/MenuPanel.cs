using System;
using MyGame;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MenuPanel : ShowHidable
    {
        [SerializeField] private Text _bestScoreTxt;
        [SerializeField] private string _bestScorePrefix;

        protected override void OnEnable()
        {
            base.OnEnable();
            _bestScoreTxt.text = $"{_bestScorePrefix}{MyGame.GameManager.BEST_SCORE}";
            
        }

        private void Start()
        {
    
        }
        
        public void OnClickOnePlayer()
        {
            Hide();
            GameManager.LoadGameOnePlayer(new LoadGameData());
        }

        public void OnClickMultiPlayer()
        {
            Hide();
            GameManager.LoadGameMultiplayer(new LoadGameData());
        }

        public void OnClickAlgebra()
        {
            Hide();
            GameManager.LoadGameAlgebra(new LoadGameData());
        }

        public void OnClickAritmetica()
        {
            Hide();
            GameManager.LoadGameAritmetica(new LoadGameData());
        }

        public void OnClickGeometria()
        {
            Hide();
            GameManager.LoadGameGeometria(new LoadGameData());
        }

        public void OnClickTrigo()
        {
            Hide();
            GameManager.LoadGameTrigonometria(new LoadGameData());
        }

        public void OnClickMenu()
        {
            Hide();
            GameManager.LoadScene("Menu");
        }

    }
}