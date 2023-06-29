using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed=50f; 
    private Rigidbody rb;
    private void Awake() {
        rb=GetComponent<Rigidbody>();
       
    }
    private void Start() {
         rb.velocity=transform.forward*speed;
          Destroy(this.gameObject,5f);
    }
   private void OnTriggerEnter(Collider other) {
       if(other.CompareTag("Inimigo")){
           Destroy(other.gameObject);
       }
    Destroy(this.gameObject);
   }
}
