using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class NicerSizer : MonoBehaviour
    {
        Resolution _resolution;
        float _windowAspect, _oldAspect;
        // Use this for initialization
        void Start()
        {
            _windowAspect = Camera.main.aspect;
            Camera.main.orthographicSize = (GameConstants.GAME_WIDTH / _windowAspect) / 2f;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
