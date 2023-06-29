using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
   [SerializeField] private GameObject heart;
private void Start() {
    StartCoroutine(Spawn());
}
IEnumerator Spawn(){
    yield return new WaitForSeconds(0.5f);
    Instantiate(heart,transform.position+new Vector3(Random.Range(0f,5f),Random.Range(0f,5f),Random.Range(0f,5f))
    ,Random.rotation);
    yield return Spawn();
}

}
