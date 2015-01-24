using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Scripts
{
    public class ObstacleCreator : MonoBehaviour
    {
        private float _lastTime;
        public float Threshold = 1.0f;

        [SerializeField]
        public GameObject[] Types;
        // Use this for initialization
        void Start()
        {
            _lastTime = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - _lastTime > Threshold)
            {
                var obstacleIndex = (Random.value < 0.5f) ? 0 : 1;
                GameObject obstacle = Instantiate(Types[obstacleIndex], new Vector3(), Quaternion.identity) as GameObject;
                if (obstacle != null)
                {
                    obstacle.GetComponent<Obstacle>().ResetObstacle();
                    obstacle.transform.parent = transform;
                }
                
                _lastTime = Time.time;
            }
        }
    }
}
