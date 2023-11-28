using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArma : MonoBehaviour
{

    [SerializeField] public GameObject armaMano;
    public Queue<int> _misArmas;
    public GameObject[] armas;
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
        if (other.gameObject.tag == "Arma")
        {
            _misArmas.Enqueue(other.GetComponentInChildren<arma>().id);
            Debug.Log("armas guardadas" + _misArmas.capacity);
            Destroy(other.gameObject);
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