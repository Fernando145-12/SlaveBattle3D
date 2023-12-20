using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos : MonoBehaviour
{
    public int i;
    public Pos next;
    public Pos previus;
    public int siguiente;

    private void Start()
    {
        siguiente = Random.Range(1, 3);
        switch (siguiente)
        {
            case 1:
                siguiente = next.i;
                break;
            case 2:
                siguiente = previus.i;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            siguiente = Random.Range(1, 3);
            switch (siguiente)
            {
                case 1:
                    siguiente = next.i;
                    break;
                case 2:
                    siguiente = previus.i;
                    break;
            }
        }
    }
    public int Siguiente()
    {
        return siguiente;
    }
}
