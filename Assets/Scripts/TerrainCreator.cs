using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    public class TerrainCreator : MonoBehaviour
    {
        [SerializeField]
        public Sprite[] LeftTerrains;
        [SerializeField]
        public Sprite[] RightTerrains;

        private float _lastTime;
        public float Threshold = 1.0f;

        public GameObject LastLeftTerrain, LastRightTerrain;

        public Transform Prefab;

        private int counter;

        // Use this for initialization
        void Start()
        {/*
            Transform object1 = Instantiate(Prefab, new Vector2(-10, 0), Quaternion.identity) as Transform;

            if (object1 != null)
            {
                object1.GetComponent<SpriteRenderer>().sprite = RightTerrains[0];
                Debug.Log(LeftTerrains.Length);
                object1.transform.position = new Vector3(-10, 0);
                object1.gameObject.AddComponent<PolygonCollider2D>();
            }
            Debug.Log(LeftTerrains.Length);
          * */
        }

        void FixedUpdate()
        {
            if (LastLeftTerrain.transform.position.y <= 2.4f)
            {
                var watch = Stopwatch.StartNew();
                Transform newLeftTerrain = Instantiate(Prefab, new Vector2(-10f, LastLeftTerrain.transform.position.y + 7.2f), Quaternion.identity) as Transform;
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Debug.Log(elapsedMs);
                if (newLeftTerrain != null)
                {
                    
                    newLeftTerrain.GetComponent<SpriteRenderer>().sprite = RightTerrains[0];
                    
                    //newLeftTerrain.transform.position = new Vector3(-10f, 9.6f);
                    
                    //PolygonCollider2D comp = newLeftTerrain.gameObject.AddComponent<PolygonCollider2D>();
                    //comp.isTrigger = true;
                    newLeftTerrain.gameObject.AddComponent<PolygonCollider2D>();
                    
                    Debug.Log("Left Terrain: " + Time.deltaTime);
                }

                Transform newRightTerrain = Instantiate(Prefab, new Vector2(10f, LastLeftTerrain.transform.position.y + 7.2f), Quaternion.identity) as Transform;

                if (newRightTerrain != null)
                {
                    newRightTerrain.GetComponent<SpriteRenderer>().sprite = LeftTerrains[0];
                    //newRightTerrain.transform.position = new Vector3(10f, 9.6f);
                    newRightTerrain.gameObject.AddComponent<PolygonCollider2D>();
                    Debug.Log("Right Terrain: " + Time.deltaTime);
                }
                LastLeftTerrain = newLeftTerrain.gameObject;
                LastRightTerrain = newRightTerrain.gameObject;
            }
            /*if (Time.time - _lastTime > Threshold)
            {
                var obstacleIndex = (Random.value < 0.5f) ? 0 : 1;
                GameObject obstacle = Instantiate(Types[obstacleIndex], new Vector3(), Quaternion.identity) as GameObject;
                if (obstacle != null)
                {
                    obstacle.GetComponent<Obstacle>().ResetObstacle();
                    obstacle.transform.parent = transform;
                }

                _lastTime = Time.time;
            }*/
        }

        // Update is called once per frame
        /*void Update()
        {
            if (LastLeftTerrain.transform.position.y <= 2.4f)
            {

                Transform newLeftTerrain = Instantiate(Prefab, new Vector2(-10f, 9.6f), Quaternion.identity) as Transform;

                if (newLeftTerrain != null)
                {
                    newLeftTerrain.GetComponent<SpriteRenderer>().sprite = LeftTerrains[0];
                    //newLeftTerrain.transform.position = new Vector3(-10f, 9.6f);
                    newLeftTerrain.gameObject.AddComponent<PolygonCollider2D>();
                }

                Transform newRightTerrain = Instantiate(Prefab, new Vector2(10f, 9.6f), Quaternion.identity) as Transform;

                if (newRightTerrain != null)
                {
                    newRightTerrain.GetComponent<SpriteRenderer>().sprite = RightTerrains[0];
                    //newRightTerrain.transform.position = new Vector3(10f, 9.6f);
                    newRightTerrain.gameObject.AddComponent<PolygonCollider2D>();
                }
                LastLeftTerrain = newLeftTerrain.gameObject;
                LastRightTerrain = newRightTerrain.gameObject;
            }
            /*if (Time.time - _lastTime > Threshold)
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
        }*/
    }
}
