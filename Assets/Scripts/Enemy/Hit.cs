using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
       if(other.CompareTag("Player")) {
           Debug.Log("Player Hit");
          if(other.TryGetComponent<Health>(out Health health)){
            health.DealDamege(10f);
        }
       }
    }
}
