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

        public void ResetObstacle(float start, float end)
        {
            var xPos = UnityEngine.Random.Range(start + renderer.bounds.extents.x, end - renderer.bounds.extents.x);
            transform.position = new Vector3(xPos, 10f);
        }

    }


}
