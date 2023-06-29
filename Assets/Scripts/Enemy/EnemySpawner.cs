using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnTime = 5f;
    private float time=0;
    private void Update() {
        time+=Time.deltaTime;
        if(time>spawnTime){
            Instantiate(enemy,transform.position,transform.rotation);
            time=0;
        }
    }
}
