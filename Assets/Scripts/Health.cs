using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField,Range(0,100)] private float maxHeath;
    public event Action OnTakeDamege;
    public event Action OnDie;
    private float heath;
    private void Start() {
        heath=maxHeath;
    }
    public void  DealDamege(float damage){
       if(heath==0) return;

        heath=Mathf.Max(heath-damage,0);
        OnTakeDamege?.Invoke();
        if(heath==0){
            OnDie?.Invoke();
        }
        Debug.Log(gameObject.name+" heath: "+heath);
    }
}
