using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TAMKShooter.Systems;
using DG.Tweening;
using System;


namespace TAMKShooter.GUI
{ 

    public class WinGameIndicator : MonoBehaviour
    {
        [SerializeField] private Text _winText;
        [SerializeField] private Image _backgroundImage;

        private Coroutine _rotateCoroutine;
        private Color _indicatorImageColor;
        private List<Tweener> _tweeners = new List<Tweener>();

        public void Init()
        {
            gameObject.SetActive(false);
            Global.Instance.GameManager.GameStateChanging +=
                HandleGameStateChanging;
            
            _indicatorImageColor = _winText.color;
        }

        protected void OnDestroy()
        {
            Global.Instance.GameManager.GameStateChanging -=
                HandleGameStateChanging;
            
        }

        

        private void TweenCompleted()
        {
            foreach (var tweener in _tweeners)
            {
                if (tweener.IsPlaying())
                {
                    tweener.Kill(true);
                }
            }

            _tweeners.Clear();

            gameObject.SetActive(false);
        }

        private void HandleGameStateChanging(GameStateType obj)
        {
            gameObject.SetActive(true);
         
        }

       
    }
}

