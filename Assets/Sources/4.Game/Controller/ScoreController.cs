using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ScoreController : MonoBehaviour,IGameScoreListener
    {
        private Text scoreText;
        // Use this for initialization
        void Start()
        {
            scoreText = GetComponent<Text>();
            Contexts.sharedInstance.game.CreateEntity().AddGameScoreListener(this);
        }

        public void OnGameScore(GameEntity entity, int score)
        {
            scoreText.text = score.ToString();
        }
    }

}

