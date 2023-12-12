using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArma : MonoBehaviour
{

    [SerializeField] public GameObject armaMano;
    public Queue<int> _misArmas;
    public GameObject[] armas;
    public MyCharacterStats _player;
    void Start()
    {
        _misArmas = new Queue<int>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 direccion = new Vector3(other.transform.position.x - transform.position.x, other.transform.position.y, other.transform.position.z - transform.position.z);
            other.gameObject.GetComponent<Rigidbody>().velocity = direccion*5;
            _player._hacerDaño?.Invoke(other.gameObject.GetComponent<EnemyClass>());
        }
    }
 

    public class Queue<T>
    {
        public class Node
        {
            public T value { get; set; }
            public Node Next { get; set; }
            public Node Previus { get; set; }
            public Node(T value)
            {
                this.value = value;
                Next = null;
                Previus = null;
            }
        }
        public Node Head;//primer nodo
        public Node Tail;//ultimo nodo
        public int capacity;
        public void Enqueue(T value)
        {
            if (Tail == null)
            {
                Node newNode = new Node(value);
                Head = newNode;
                Tail = newNode;
                capacity++;
            }
            else
            {
                Node newNOde = new Node(value);
                Tail.Next = newNOde;
                newNOde.Previus = Tail;
                Tail = newNOde;
                capacity++;

            }
        }
        public void Dequeue()
        {
            if (Tail == null)
            {
                Debug.Log("No hay nodos a eliminar");
            }
            else
            { 
                if(Head.Next == null)
                {
                    Head = Tail;
                    Tail = null;
                    capacity--;
                }
                else
                {
                    Node tmp = Head.Next;
                    Head.Next = null;
                    tmp.Previus = null;
                    Head = tmp;
                    capacity--;
                }
                
            }
        }
        public void PrintTail()
        {
            Node tmp = Head;
            while (tmp != null)
            {

                tmp = tmp.Next;
            }
        }
    }
}