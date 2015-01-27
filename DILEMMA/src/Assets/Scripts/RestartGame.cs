using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RestartGame : MonoBehaviour
    {
        private float _player1Score;
        private float _player2Score;

        public Text LeftScoreGui, RightScoreGui;
        // Use this for initialization
        void Start()
        {
            _player1Score = PlayerPrefs.GetFloat("Player1Score");
            _player2Score = PlayerPrefs.GetFloat("Player2Score");

            Debug.Log("Player1Score: " + _player1Score);

            LeftScoreGui.text = _player1Score.ToString("0.0");
            RightScoreGui.text = _player2Score.ToString("0.0");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Jump"))
            {
                Destroy(GameObject.Find("Ship"));
                Application.LoadLevel("BuzluMain");
            }
            else if (Input.GetButton("Cancel"))
            {
                Application.Quit();
            }
        }
    }

}

