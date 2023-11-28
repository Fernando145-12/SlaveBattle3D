using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MyCharacterStats : Stats
{

    public Action<MyCharacterStats> _hacerDaño;
    public Action<MyCharacterStats> _attack1;
    public Action<MyCharacterStats> _curar;
    public Action<MyCharacterStats> _recivirDaño;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyArma")
        {

        }      
    }

}
