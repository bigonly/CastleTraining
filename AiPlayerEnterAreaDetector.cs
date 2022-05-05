using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SVS.AI 
{ 
    public class AiPlayerEnterAreaDetector : MonoBehaviour
    {
        [field: SerializeField]

        public bool PlayerInArea { get; private set; }
        public Transform Player { get; private set; }

        [SerializeField]
        private string decetionTag = "Player";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(decetionTag))
            {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(decetionTag))
            {
                PlayerInArea = false;
                Player = null;
            }
        }
    }
}