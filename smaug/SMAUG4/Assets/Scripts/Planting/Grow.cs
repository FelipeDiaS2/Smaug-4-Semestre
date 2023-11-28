using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Planting
{
    public class Grow : MonoBehaviour
    {
        public float timeGrow;
        // Update is called once per frame
        void Update()
        {
            timeGrow -= Time.deltaTime;
            if(timeGrow <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}