using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameData : MonoBehaviour
    {
        public GameObject Player;
        private float _leftPlayerScore, _rightPlayerScore;
        public Text LeftScoreGui, RightScoreGui;
        // Use this for initialization
        void Start()
        {
            _leftPlayerScore = _rightPlayerScore = 0;
        }

        // Update is called once per frame
        void Update()
        {
            var playerPosX = Player.transform.position.x;
            if (playerPosX > 0)
            {
                _rightPlayerScore += Time.deltaTime * playerPosX;
                RightScoreGui.text = _rightPlayerScore.ToString("0.0");
            }
            else
            {
                _leftPlayerScore += Time.deltaTime * -playerPosX;
                LeftScoreGui.text = _leftPlayerScore.ToString("0.0");
            }

        }
    }
}
