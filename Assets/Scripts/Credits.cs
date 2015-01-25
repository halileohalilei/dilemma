using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Credits : MonoBehaviour
    {

        public void OnClick()
        {
            Application.LoadLevel("CreditsScreen");
        }
    }
}

