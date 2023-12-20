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
        _player._hacerDaño = HacerDañoAEnemy;
        _lista[0]._enemyCreado = SuscrubirEnemigosASusEventos;
        _lista[1]._enemyCreado = SuscrubirEnemigosASusEventos;
        _lista[2]._enemyCreado = SuscrubirEnemigosASusEventos;
        jefe._hacerDañoAPlayer = HacerDañoAPlayer;
    }    

    private void HacerDañoAEnemy(EnemyClass enemy)
    {
        Debug.Log("Malo feo" + enemy._vida);
        enemy._vida -= _player._daño;
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
        enemys._hacerDañoAPlayer += HacerDañoAPlayer;

    }
    public void HacerDañoAPlayer(MyCharacterStats player, float daño)
    {
        Debug.Log("Me hicieron daño" + player._vida);
        player._vida -= daño;
        if (player._vida < 0 && player!=null)
        {
            game.GameOver?.Invoke();
            Destroy(player);
        }
    }
    

}
