using System;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Obstacle : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            rigidbody2D.velocity = new Vector2(0, -GameConstants.FLOW_SPEED);
        }

        public void ResetObstacle()
        {
            var xPos = UnityEngine.Random.Range(-2.5f, 2.5f);
            transform.position = new Vector3(xPos, 5.0f);
        }
    }
}
