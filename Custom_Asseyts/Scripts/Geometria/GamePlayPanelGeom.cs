using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GamePlayPanelGeom : ShowHidable
    {
        [SerializeField] private Text _scoreTxt;
        [SerializeField] private string _scorePrefix = "";
        [SerializeField] private Slider _timerSlider;

        private LevelManagerGeom LevelManager => LevelManagerGeom.Instance;



        public override void Show(bool animate = true, Action completed = null)
        {

            base.Show(animate, completed);
        }

        private void Update()
        {
            if (_scoreTxt != null)
                _scoreTxt.text = $"{_scorePrefix}{LevelManager.Score}";

            _timerSlider.normalizedValue = LevelManager.Timer / LevelManager.AnswerTime;
        }

    }
}
