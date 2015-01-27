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

        private bool? _onLeftSide;
        private bool? _lastHitOnLeft;

        private int _hitCounter;

        public float RightPlayerScore
        {
            get { return _rightPlayerScore; }
            set { _rightPlayerScore = value; }
        }

        public float LeftPlayerScore
        {
            get { return _leftPlayerScore; }
            set { _leftPlayerScore = value; }
        }

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
                _onLeftSide = false;
                _rightPlayerScore += Time.deltaTime * (8 - playerPosX);
                RightScoreGui.text = _rightPlayerScore.ToString("0.0");
            }
            else if (playerPosX < 0)
            {
                _onLeftSide = true;
                _leftPlayerScore += Time.deltaTime * (8 + playerPosX);
                LeftScoreGui.text = _leftPlayerScore.ToString("0.0");
            }
            else
            {
                _onLeftSide = null;
            }

        }

        public void HitObstacle()
        {
            if (_onLeftSide.HasValue)
            {
                if (_onLeftSide.Value) _leftPlayerScore -= (_hitCounter * 10f);
                else _rightPlayerScore -= (_hitCounter * 10f);

                if (_lastHitOnLeft == null || _lastHitOnLeft.Value == _onLeftSide.Value)
                {
                    _hitCounter++;
                }
                else
                {
                    _hitCounter = 1;
                    _lastHitOnLeft = _onLeftSide;
                }
                _lastHitOnLeft = _onLeftSide;
            }
        }
    }
}
