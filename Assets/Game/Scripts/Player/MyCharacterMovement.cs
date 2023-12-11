using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class MyCharacterMovement : MonoBehaviour
{
    public GameObject aim;
    public float velocity;
    public Rigidbody rgb;
    public CinemachineVirtualCamera miCamara;
    private bool miro;
    private Vector3 punteroMouse;
    private MyArma _myarma;

    private void Awake()
    {
        _myarma = GetComponent<MyArma>();
    }
    private void Start()
    {
        Debug.Log("Estamos");
    }
 
    public void OnMove(InputAction.CallbackContext value)
    {
        Debug.Log("OnMove");
        if (value.performed)
        {
            Vector2 tmp = value.ReadValue<Vector2>();
            Debug.Log(value);
            rgb.velocity = new Vector3(tmp.x,transform.position.y,tmp.y)*velocity;
            transform.LookAt(new Vector3(transform.position.x + tmp.x, transform.position.y, transform.position.z+tmp.y));
        }
        else
        {
            rgb.velocity = Vector3.zero;
        }
    }
    public void Attack1(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Attack1");

            Debug.Log("armas guardadas" + _myarma._misArmas.capacity);
        }

    }
    public void Attack2(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Attack2");
            _myarma._misArmas.Dequeue();
            _myarma.armaMano.GetComponent<SpriteRenderer>().sprite = _myarma.armas[_myarma._misArmas.Head.value].GetComponent<SpriteRenderer>().sprite;
            Debug.Log("armas guardadas" + _myarma._misArmas.capacity);

        }
    }
    public void Aim(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            miro = true;
            Vector2 tmp = value.ReadValue<Vector2>();
            //Debug.Log(tmp) ;
            //punteroMouse = new Vector3( transform.position.x- tmp.x , transform.position.y, transform.position.z - tmp.y);
            punteroMouse = new Vector3( tmp.x, transform.position.y,tmp.y);

        }
    }
    private void Update()
    {
        //transform.LookAt(punteroMouse);
    }
}
