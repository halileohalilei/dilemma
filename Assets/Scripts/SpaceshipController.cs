using System;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class SpaceshipController : MonoBehaviour
    {
        public float Rotation;
        public GameObject LeftEngine, RightEngine, Popo;

        private PropellerController _leftPropellerController, _rightPropellerController;
        // Use this for initialization
        private void Start()
        {
            _leftPropellerController = LeftEngine.GetComponent<PropellerController>();
            _rightPropellerController = RightEngine.GetComponent<PropellerController>();
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
            //LeftEngine.renderer.enabled = leftEngineActive;
            //RightEngine.renderer.enabled = rightEngineActive;
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
            //Debug.Log(Screen.height);
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}