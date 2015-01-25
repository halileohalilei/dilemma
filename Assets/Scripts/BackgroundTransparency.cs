using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class BackgroundTransparency : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

