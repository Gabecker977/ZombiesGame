using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(5f,100f)] float speed=5f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private GameObject gameOverScreen;
    private Animator animator;
    private Rigidbody rb;
    private Health heath;
    private Vector3 movementDirection=new Vector3();
    private void OnEnable() {
        heath=GetComponent<Health>();
        heath.OnTakeDamege+=OnTakeDamege;
        heath.OnDie+=OnDie;
    }
    void Start()
    {
        animator=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if(movementDirection!=Vector3.zero){
        animator.SetBool("Move",true);
      }else{
       animator.SetBool("Move",false);
      }
    }
    private void FixedUpdate() {
      float inputVertical =Input.GetAxis("Vertical");
      float inputHorizontal =Input.GetAxis("Horizontal");
      
      movementDirection=new Vector3(inputHorizontal,0,inputVertical);
      rb.MovePosition(rb.position+(movementDirection*speed*Time.deltaTime));
    
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(ray.origin,ray.direction*100,Color.blue);

      RaycastHit hit;
      if(Physics.Raycast(ray,out hit,100f,layerMask)){
         Vector3 lookRotation=hit.point-transform.position;
          Quaternion rotation= Quaternion.LookRotation(lookRotation,Vector3.up);
          Vector3 rotationEuler=rotation.eulerAngles;
          rotationEuler.x=0;
          transform.rotation=Quaternion.Euler(rotationEuler);
      }
    }
    private void OnTakeDamege(){
      
    }
    private void OnDie(){
      Time.timeScale=0;
      gameOverScreen.SetActive(true);
    }
}
