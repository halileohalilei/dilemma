using UnityEngine;
using System.Collections;

namespace Assets
{
    public class StartGame : MonoBehaviour
    {
        public void OnClick()
        {
            Debug.Log("buzlu main");
            Application.LoadLevel("BuzluMain");
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
 
}
