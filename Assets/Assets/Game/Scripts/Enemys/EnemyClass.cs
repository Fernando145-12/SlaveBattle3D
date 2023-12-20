using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyClass : Stats
{
    public int levelEnemy;
    public Transform _objetivo;
    public Action<MyCharacterStats,float> _hacerDa�oAPlayer;
    void Start()
    {
        _vida = 10;
        _da�o = 1;
        _velocidad = 4;
        if (levelEnemy > 0)
        {
            _vida *= levelEnemy;
            _da�o = levelEnemy;
            _velocidad = levelEnemy;
        }
    }
    public void SetLevelEnemy(int lvl,Transform player)
    {
        levelEnemy = lvl;
        _objetivo = player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _hacerDa�oAPlayer?.Invoke(collision.gameObject.GetComponent<MyCharacterStats>(),_da�o);
        }
    }
}
