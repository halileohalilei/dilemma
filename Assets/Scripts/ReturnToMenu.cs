using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class ReturnToMenu : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
           
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Cancel"))
            {
                
                Application.LoadLevel("Main menu");
            }
        }
    }

}

