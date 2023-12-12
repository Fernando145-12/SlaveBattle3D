using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public SpawmEnemys _lista;
    public MyCharacterStats _player;
    void Start()
    {
        _player._hacerDa�o = HacerDa�oAEnemy;
        _lista._enemyCreado = SuscrubirEnemigosASusEventos;
    }
    

    void Update()
    {
        
    }

    private void HacerDa�oAEnemy(EnemyClass enemy)
    {
        Debug.Log("Malo feo" + enemy._vida);
        enemy._vida -= _player._da�o;
    }
 
    private void SuscrubirEnemigosASusEventos(EnemyClass enemys)
    {
        enemys._hacerDa�oAPlayer += HacerDa�oAPlayer;
    }
    public void HacerDa�oAPlayer(MyCharacterStats player, float da�o)
    {
        Debug.Log("Me hicieron da�o" + player._vida);
        player._vida -= da�o;      
    }
    

}
