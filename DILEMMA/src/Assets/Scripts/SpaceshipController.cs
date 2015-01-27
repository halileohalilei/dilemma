using System;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class SpaceshipController : MonoBehaviour
    {
        public float Rotation;
        public float Damage;
        public GameObject LeftEngine, RightEngine, Popo;
        private GameData _gameData;
        public AudioClip HitRocksClip, HitTerrainClip, SailClip;

        private Transform _healthBar, _emptyHealthBar;

        private AudioSource _hitRocks, _hitTerrain, _sail;

        private PropellerController _leftPropellerController, _rightPropellerController;


        private void Awake()
        {
            _hitRocks = AddAudioSource(HitRocksClip, false, false, 1.0f);
            _hitTerrain = AddAudioSource(HitTerrainClip, false, false, 1.0f);
            _sail = AddAudioSource(SailClip, true, true, 0.5f);
        }

        private AudioSource AddAudioSource(AudioClip clip, bool loop, bool playOnAwake, float volume)
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.playOnAwake = playOnAwake;
            audioSource.volume = volume;

            return audioSource;
        }

        // Use this for initialization
        private void Start()
        {
            _leftPropellerController = LeftEngine.GetComponent<PropellerController>();
            _rightPropellerController = RightEngine.GetComponent<PropellerController>();
            _healthBar = Popo.transform.FindChild("nohealth");
            _emptyHealthBar = Popo.transform.FindChild("fullhealth");
            _gameData =  GameObject.Find("GameDataContainer").GetComponent<GameData>();

            _sail.Play();
        }

        private void FixedUpdate()
        {
            var leftEngineActive = Input.GetButton("Fire1");
            var rightEngineActive = Input.GetButton("Fire2");
            if (Input.touchCount > 0)
            {
                foreach (var touch in Input.touches)
                {
                    if (touch.position.x > Screen.width / 2f)
                    {
                        rightEngineActive = true;
                    }
                    else
                    {
                        leftEngineActive = true;
                    }
                }
            }
            _leftPropellerController.Speed += (leftEngineActive ? 0.1f : -1f);
            _rightPropellerController.Speed += (rightEngineActive ? 0.1f : -1f);
            var leftSpeed = _leftPropellerController.Speed;
            var rightSpeed = _rightPropellerController.Speed;

            var difference = leftSpeed - rightSpeed;
            if (!difference.Equals(0))
            {
                if (leftEngineActive && rightEngineActive)
                {
                    if (Rotation > 0)
                    {
                        Rotation += -1f;
                    }
                    else if (Rotation < 0)
                    {
                        Rotation += 1f;
                    }

                    _leftPropellerController.Speed += -1f;
                    _rightPropellerController.Speed += -1f;
                }
                else
                {
                    Rotation += difference;  
                }
            }
            else
            {
                if (Rotation > 0)
                {
                    Rotation += -1f;
                } 
                else if (Rotation < 0)
                {
                    Rotation += 1f;
                }

                _leftPropellerController.Speed += -1f;
                _rightPropellerController.Speed += -1f;
            }
            Rotation = Mathf.Clamp(Rotation, -45, 45);
            transform.rotation = Quaternion.Euler(0, 0, -Rotation);
            Popo.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += new Vector3(Rotation * 0.001f, 0);

            GameConstants.FLOW_SPEED = Mathf.Cos(Mathf.Deg2Rad * Rotation) * GameConstants.DEFAULT_SPEED;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name.Contains("Obstacle"))
            {
                _hitRocks.PlayOneShot(_hitRocks.clip);
                _gameData.HitObstacle();
                _healthBar.localScale = new Vector3(_healthBar.localScale.x - Damage, _healthBar.localScale.y);
                if (_healthBar.localScale.x <= 0)
                {
                    EndGame();
                }
            }
            else if (other.name.Contains("Ice") || other.name.Contains("Forest"))
            {
                _hitTerrain.PlayOneShot(_hitTerrain.clip);
                EndGame();
            }
        }

        private void EndGame()
        {
            DontDestroyOnLoad(gameObject);
            _sail.Stop();
            PlayerPrefs.SetFloat("Player1Score", _gameData.LeftPlayerScore);
            PlayerPrefs.SetFloat("Player2Score", _gameData.RightPlayerScore);
            Application.LoadLevel("GameOver");
        }

        // Update is called once per frame
        private void Update()
        {
           
        }
    }
}