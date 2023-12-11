using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterMovement : MonoBehaviour
{
   
    public bool veoPlayer;
    public bool patrullo;
    public Pos[] positionNodes;
    public int posActual;
    private EnemyClass _enemyclass;
    private Rigidbody rgbEnemy;
    
    void Start()
    {
        patrullo = true;
        _enemyclass = GetComponent<EnemyClass>();
        rgbEnemy = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_enemyclass.levelEnemy > 0)
        {
            if (veoPlayer ==true)
            {
                transform.LookAt(_enemyclass._objetivo);
                Vector3 direccion = new Vector3(_enemyclass._objetivo.position.x - transform.position.x, _enemyclass._objetivo.position.y - transform.position.y, _enemyclass._objetivo.position.z - transform.position.z);
                rgbEnemy.velocity = direccion.normalized * _enemyclass._velocidad;
            }
            else
            {
                if (patrullo == true)
                {
                    transform.LookAt(positionNodes[posActual].transform.position);
                    Vector3 direccion = new Vector3(positionNodes[posActual].transform.position.x - transform.position.x, positionNodes[posActual].transform.position.y - transform.position.y, positionNodes[posActual].transform.position.z - transform.position.z);
                    rgbEnemy.velocity = direccion.normalized * _enemyclass._velocidad;
                }
                else
                {
                    rgbEnemy.velocity = Vector3.zero;
                }
            }
        }
        else
        {
            transform.LookAt(_enemyclass._objetivo);
            Vector3 direccion = new Vector3(_enemyclass._objetivo.position.x-transform.position.x, _enemyclass._objetivo.position.y - transform.position.y, _enemyclass._objetivo.position.z - transform.position.z);
            rgbEnemy.velocity = direccion.normalized * _enemyclass._velocidad;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pos")
        {
            StartCoroutine(Descanso());
            posActual = collision.gameObject.GetComponent<Pos>().Siguiente();
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            veoPlayer = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            veoPlayer = true;
        }
       
    }
    IEnumerator Descanso()
    {
        patrullo = false;
        yield return new WaitForSecondsRealtime(2);
        patrullo = true;
    }
}
