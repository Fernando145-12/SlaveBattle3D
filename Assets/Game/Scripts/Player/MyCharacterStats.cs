using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MyCharacterStats : Stats
{

    public Action<EnemyClass> _hacerDa�o;
    public Action<MyCharacterStats> _attack1;
    public Action<MyCharacterStats> _curar;
    public Action<MyCharacterStats> _recivirDa�o;
    public float score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
          
    }

}
