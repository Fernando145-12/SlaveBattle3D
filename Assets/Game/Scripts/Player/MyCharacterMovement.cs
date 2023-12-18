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
    public Animator animator;
    public CinemachineVirtualCamera miCamara;
    private bool miro;
    public Vector3 punteroMouse;
    public MyArma _myarma;

    private void Start()
    {
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Vector2 input = value.ReadValue<Vector2>();
            Debug.Log(value);
            rgb.velocity = new Vector3(input.x, transform.position.y, input.y) * velocity;
            animator.SetFloat("Velocity", input.magnitude);
            //transform.LookAt(new Vector3(transform.position.x + tmp.x, transform.position.y, transform.position.z + tmp.y));
        }
        else
        {
            animator.SetFloat("Velocity", 0);
            rgb.velocity = Vector3.zero;
        }
    }
    public void Attack1(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (_myarma._misArmas.capacity <= 0)
            {
                _myarma.armaMano.SetActive(false);
            }
            else
            {
                animator.SetTrigger("Attack1");
                _myarma.armaMano.SetActive(true);
            }
            StartCoroutine(Atacar1());
            Debug.Log("armas guardadas" + _myarma._misArmas.capacity);
        }
    }
    IEnumerator Atacar1()
    {
        _myarma.GetComponent<Collider>().isTrigger = true;
        _myarma.armaMano.transform.localScale = new Vector3(2.007037f, 1.043961f, 1f);
        yield return new WaitForSecondsRealtime(0.2f);
        _myarma.armaMano.transform.localScale = new Vector3(0.1911578f, 0.7326044f, 1f);
        _myarma.GetComponent<Collider>().isTrigger = false;
    }
    public void Attack2(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (_myarma._misArmas.capacity <= 0)
            {
                _myarma.armaMano.SetActive(false);
            }
            else
            {
                animator.SetTrigger("Attack2");
                _myarma.armaMano.SetActive(true);
            }
            StartCoroutine(Atacar2());
            _myarma._misArmas.Dequeue();
            if (_myarma._misArmas.capacity <= 0)
            {
                _myarma.armaMano.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                _myarma.armaMano.GetComponent<SpriteRenderer>().sprite = _myarma.armas[_myarma._misArmas.Head.value].GetComponent<SpriteRenderer>().sprite;
            }

            Debug.Log("armas guardadas" + _myarma._misArmas.capacity);

        }
    }
    IEnumerator Atacar2()
    {
        _myarma.GetComponent<Collider>().isTrigger = true;
        _myarma.armaMano.transform.localScale = new Vector3(4.124477f, 2.206971f, 1f);
        yield return new WaitForSecondsRealtime(0.2f);
        _myarma.armaMano.transform.localScale = new Vector3(0.1911578f, 0.7326044f, 1f);
        _myarma.GetComponent<Collider>().isTrigger = false;
    }
    public void Aim(InputAction.CallbackContext value)
    {       
            miro = true;
            Vector2 input = value.ReadValue<Vector2>();
            // Calcula la diferencia entre la posición del puntero y la posición del GameObject
            Vector3 miposicion = new Vector3(transform.position.x, 0f, transform.position.z);

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(input.x+ miposicion.x, input.y + miposicion.z, transform.position.y));

            punteroMouse = worldPoint;

    }
    private void Update()
    {
        transform.LookAt(new Vector3(punteroMouse.x, transform.position.y, punteroMouse.z));
        aim.gameObject.transform.position = new Vector3(punteroMouse.x, transform.position.y, punteroMouse.z);

        if (_myarma._misArmas.capacity <= 0)
        {
            animator.SetBool("Armado", false);
        }
        else
        {
            animator.SetBool("Armado", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arma")
        {
            _myarma._misArmas.Enqueue(other.GetComponentInChildren<arma>().id);
            Debug.Log("armas guardadas" + _myarma._misArmas.capacity);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Level")
        {
            transform.position = new Vector3(0.5f, 21, 26.6f);
        }
    }
}
