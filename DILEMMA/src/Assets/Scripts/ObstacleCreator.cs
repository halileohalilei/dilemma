using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Scripts
{
    public class ObstacleCreator : MonoBehaviour
    {
        private float _lastTime;
        public float Threshold = 1.0f;

        public GameObject TerrainHandlerObject;

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
                int val = Random.Range(0, 3);
                var obstacleIndex = 0;
                switch (val)
                {
                    case 0:
                        obstacleIndex = 0;
                        break;
                    case 1:
                        obstacleIndex = 1;
                        break;
                    case 2:
                        obstacleIndex = 2;
                        break;
                }

                int rotation = Random.Range(0, 4);
                GameObject obstacle = Instantiate(Types[obstacleIndex], new Vector3(), Quaternion.identity) as GameObject;
                if (obstacle != null)
                {
                    TerrainCreator tc = TerrainHandlerObject.GetComponent<TerrainCreator>();
                    float startRange = tc.LastLeftTerrain.renderer.bounds.extents.x * 2;
                    float endRange = tc.LastRightTerrain.renderer.bounds.extents.x * 2;
                    obstacle.GetComponent<Obstacle>().ResetObstacle(-10f + startRange, 10f - endRange);
                    obstacle.transform.parent = transform;
                    obstacle.transform.rotation = Quaternion.Euler(0, 0, 90f*rotation);
                }
                
                _lastTime = Time.time;
            }
        }
    }
}
