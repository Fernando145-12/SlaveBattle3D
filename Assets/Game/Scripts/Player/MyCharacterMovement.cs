using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCharacterMovement : MonoBehaviour
{
    public GameObject aim;
    public float velocity;
    public Rigidbody rgb;
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
            Vector3 tmp = new Vector3(value.ReadValue<Vector2>().x, Camera.main.transform.position.y, value.ReadValue<Vector2>().y);
            punteroMouse = Camera.main.ScreenToWorldPoint(tmp);
        }
    }
    private void Update()
    {
        if (miro)
        {
            Vector3 tmp =  punteroMouse ;
            float anguloRadianes = Mathf.Atan2(tmp.z - transform.position.z, tmp.x - transform.position.x);
            float anguloGrados = (180 / Mathf.PI) * anguloRadianes+ 90;
            //Debug.Log("tmp.z "+tmp.z);
            //Debug.Log("transform.position.z "+transform.position.z);
            //Debug.Log("tmp.x " + tmp.x);
            //Debug.Log("transform.position.x " + transform.position.x);
            transform.rotation = Quaternion.Euler(0, anguloGrados, 0);
        }
    }
}
