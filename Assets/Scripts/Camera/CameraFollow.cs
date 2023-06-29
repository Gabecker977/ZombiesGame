using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    //[SerializeField,Range(5f,50f)] private float height;
    private Vector3 position;
    private void Start() {
        position=transform.position-target.position;
    }
    private void Update() {
        //transform.Translate((target.position+position));
        transform.position=target.position+position;
    }
}
