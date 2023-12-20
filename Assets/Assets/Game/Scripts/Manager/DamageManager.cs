using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public SpawmEnemys[] _lista;
    public EnemyClass jefe;
    public GAmeController game;
    public MyCharacterStats _player;
    void Start()
    {
        _player._hacerDa�o = HacerDa�oAEnemy;
        _lista[0]._enemyCreado = SuscrubirEnemigosASusEventos;
        _lista[1]._enemyCreado = SuscrubirEnemigosASusEventos;
        _lista[2]._enemyCreado = SuscrubirEnemigosASusEventos;
        jefe._hacerDa�oAPlayer = HacerDa�oAPlayer;
    }    

    private void HacerDa�oAEnemy(EnemyClass enemy)
    {
        Debug.Log("Malo feo" + enemy._vida);
        enemy._vida -= _player._da�o;
        if (enemy._vida < 0)
        {
            Destroy(enemy.gameObject);
        }
        if (jefe._vida < 0 && jefe!=null)
        {
            game.Win?.Invoke();
            Destroy(enemy.gameObject);
        }
    }
 
    private void SuscrubirEnemigosASusEventos(EnemyClass enemys)
    {
        enemys._hacerDa�oAPlayer += HacerDa�oAPlayer;

    }
    public void HacerDa�oAPlayer(MyCharacterStats player, float da�o)
    {
        Debug.Log("Me hicieron da�o" + player._vida);
        player._vida -= da�o;
        if (player._vida < 0 && player!=null)
        {
            game.GameOver?.Invoke();
            Destroy(player);
        }
    }
    

}
