using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public SpawmEnemys _lista;
    public MyCharacterStats _player;
    void Start()
    {
        _player._hacerDaño = HacerDañoAEnemy;
        _lista._enemyCreado = SuscrubirEnemigosASusEventos;
    }
    

    void Update()
    {
        
    }

    private void HacerDañoAEnemy(EnemyClass enemy)
    {
        Debug.Log("Malo feo" + enemy._vida);
        enemy._vida -= _player._daño;
    }
 
    private void SuscrubirEnemigosASusEventos(EnemyClass enemys)
    {
        enemys._hacerDañoAPlayer += HacerDañoAPlayer;
    }
    public void HacerDañoAPlayer(MyCharacterStats player, float daño)
    {
        Debug.Log("Me hicieron daño" + player._vida);
        player._vida -= daño;      
    }
    

}
