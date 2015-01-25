using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class RestartGame : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Jump"))
            {
                Application.LoadLevel("BuzluMain");
            }
            else if (Input.GetButton("Cancel"))
            {
                Application.Quit();
            }
        }
    }

}

