using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    public class TerrainCreator : MonoBehaviour
    {
        [SerializeField] public Transform[] LeftTerrainObjects;
        [SerializeField] public Transform[] RightTerrainObjects;

        private float _lastTime;
        public float Threshold = 1.0f;

        public GameObject LastLeftTerrain, LastRightTerrain;


        // Use this for initialization
        void Start()
        {
            /*
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
            if (LastLeftTerrain.transform.position.y <= 3f)
            {
                var yPos = LastLeftTerrain.transform.position.y + LastLeftTerrain.rigidbody2D.velocity.y*Time.deltaTime +
                           7.5f;
                //Transform newLeftTerrain = Instantiate(Prefab, new Vector2(-10f, yPos), Quaternion.identity) as Transform;
                Transform newLeftTerrain = Instantiate(LeftTerrainObjects[Random.Range(0, LeftTerrainObjects.Length)],
                    new Vector2(-10f, yPos), Quaternion.identity) as Transform;
                if (newLeftTerrain != null)
                {
                    //newLeftTerrain.GetComponent<SpriteRenderer>().sprite = LeftTerrains[Random.Range(0, LeftTerrains.Length)];
                    //var col = newLeftTerrain.gameObject.AddComponent<PolygonCollider2D>();
                    //col.isTrigger = true;
                    //newLeftTerrain.transform.SetParent(LastLeftTerrain.transform);
                    //newLeftTerrain.localPosition = new Vector3(0, 7.2f, 0);
                    newLeftTerrain.rigidbody2D.velocity = new Vector2(0, -GameConstants.FLOW_SPEED);
                    //newLeftTerrain.parent = null;
                }

                Transform newRightTerrain = Instantiate(RightTerrainObjects[Random.Range(0, RightTerrainObjects.Length)], new Vector2(10f, yPos), Quaternion.identity) as Transform;

                if (newRightTerrain != null)
                {
                    //newRightTerrain.GetComponent<SpriteRenderer>().sprite = RightTerrains[Random.Range(0, RightTerrains.Length)];
                    //var col = newRightTerrain.gameObject.AddComponent<PolygonCollider2D>();
                    //col.isTrigger = true;
                    //newRightTerrain.transform.SetParent(LastRightTerrain.transform);
                    //newRightTerrain.localPosition = new Vector3(0, 7.2f, 0);
                    newRightTerrain.rigidbody2D.velocity = new Vector2(0, -GameConstants.FLOW_SPEED);
                    //newRightTerrain.parent = null;
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
