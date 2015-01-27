using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class DiarrheaSea : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
            rigidbody2D.velocity = new Vector2(0, -1f);
            //Debug.Log(gameObject.renderer.bounds);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y <= -90f)
                transform.position = new Vector3(0, 90f, 0);
        }
    }

}

