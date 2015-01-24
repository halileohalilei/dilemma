using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class PropellerController : MonoBehaviour
    {
        private float _speed;

        public float Speed
        {
            get { return _speed; }
            set { _speed = Mathf.Clamp(value, 0, GameConstants.MAX_PROPELLER_FORCE); }
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
