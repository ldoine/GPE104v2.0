using UnityEngine;

namespace Assets.Scripts
{
    public class Checkpoint : MonoBehaviour
    {
        public bool checkpointReached;
       

        // Update is called once per frame
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                checkpointReached = true; 
            }
        }
    }
}
