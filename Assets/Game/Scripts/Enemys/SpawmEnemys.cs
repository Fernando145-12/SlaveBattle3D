using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawmEnemys : MonoBehaviour
{
    public ListaSimple<EnemyClass> ListaEnemigos;
    public float intervaloSpawm;
    public GameObject PrefabEnemy;
    public bool MiPiso;
    public Transform objetivo;
    public int levelEnemigo;
    public Action<EnemyClass> _enemyCreado;
    void Start()
    {
        ListaEnemigos = new ListaSimple<EnemyClass>();
        StartCoroutine(Spamear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spamear()
    {
        GameObject tmp =  Instantiate(PrefabEnemy, transform.position, Quaternion.identity);
        tmp.GetComponent<EnemyClass>().SetLevelEnemy(levelEnemigo, objetivo);
        _enemyCreado?.Invoke(tmp.GetComponent<EnemyClass>());
        ListaEnemigos.AddOndeStart(tmp.GetComponent<EnemyClass>());
        yield return new WaitForSecondsRealtime(intervaloSpawm);
        Debug.Log(ListaEnemigos.count);
        if (objetivo.transform.position.y > 15)
        {
            MiPiso = false;
        }
        if (MiPiso==true)
        {
            StartCoroutine(Spamear());
        }
        
    }
}
public class ListaSimple<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
    Node Head { get; set; }
    public int count = 0;

    //Agrega un valor a la lista
    public void AddOndeStart(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            count++;
        }
        else if (Head != null)
        {
            Node tmp = Head;
            Head = newNode;
            Head.Next = tmp;
            count++;
        }
    }
    public void AddOndeEnd(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            count++;
        }
        else if (Head != null)
        {
            Node tmp = Head;
            Head = newNode;
            Head.Next = tmp;
            count++;
        }
    }
    public void AddAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddOndeStart(value);
        }
        else if (position == count)
        {
            AddOndeEnd(value);
        }
        else if (position > count)
        {
            Debug.Log("excedes");
        }
        else
        {
            int currentPosition = 0;
            Node tmp = Head;
            while (currentPosition < position - 1)
            {
                tmp = tmp.Next;
                currentPosition++;
            }
            tmp.Value = value;
            Node nodeATPosition = tmp.Next;
            Node newNode = new Node(value);
            tmp.Next = newNode;
            newNode.Next = nodeATPosition;

            count--;
        }
    }
    public T GetNodeAtStart()
    {
        if (Head == null)
        {
            Debug.Log("excedes");
            return Head.Value;
        }
        else
        {
            return Head.Value;
        }
    }
    public T GetNodeAtEnd()
    {
        if (Head == null)
        {
            Debug.Log("excedes");
            return Head.Value;
        }
        else
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            return tmp.Value;
        }
    }
    public T GetNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return GetNodeAtStart();
        }
        else if (position == count - 1)
        {
            return GetNodeAtEnd();
        }
        else if (position > count)
        {
            Debug.Log("excedes");
            return Head.Value;

        }
        else
        {
            int iterator = 0;
            Node tmp = Head;
            while (iterator < position)
            {
                iterator++;
                tmp = tmp.Next;
            }
            return tmp.Value;
        }
    }
    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            Debug.Log("Nose ");
        }
        else
        {
            Head.Value = value;

        }
    }
    public void ModifyAtEnd(T value)
    {
        Node tmp = Head;
        while (tmp != null)
        {
            tmp = tmp.Next;
        }
        tmp.Value = value;
    }
    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == count)
        {
            ModifyAtEnd(value);
        }
        else if (position > count)
        {
            Debug.Log("Esno se puede hacer");
        }
        else
        {
            int iterator = 0;
            Node tmp = Head;
            while (iterator < position)
            {
                iterator++;
                tmp = tmp.Next;
            }
            tmp.Value = value;
        }
    }
    public void RemoveAtStart()
    {
        if (Head == null)
        {
            Debug.Log("Eso no se pede");
        }
        else
        {
            Node newHead = Head.Next;
            Head.Next = null;
            Head = null;
            Head = newHead;
            count--;
        }
    }
    public void RemoveAtEnd()
    {
        Node tmp = Head;
        while (tmp.Next.Next != null)
        {
            tmp = tmp.Next;
        }
        Node finalNode = tmp.Next;
        finalNode = null;
        tmp.Next = null;
    }
    public void RemoveNodeAtPosition(int position)
    {
        if (position == 0)
        {
            RemoveAtStart();
        }
        else if (position == count - 1)
        {
            RemoveAtEnd();
        }
        else if (position > count)
        {
            Debug.Log("Eso no se puede haer");
        }
        else
        {
            int iterator = 0;
            Node previousNode = Head;
            while (iterator < position - 1)
            {
                previousNode = previousNode.Next;
                iterator = iterator + 1;
            }
            Node currentNode = previousNode.Next;
            Node nextNode = currentNode.Next;
            currentNode.Next = null;
            currentNode = null;
            previousNode.Next = null;
            previousNode.Next = nextNode;
            count--;
        }
    }
    //Encuentra el valor siguiente al nodo que buscamos
    public void ValueNodoNext(T value)
    {
        if (Head != null)
        {
            Node tmp = Head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                {
                    Debug.Log("El valor del nodo siguiente es :  " + tmp.Next.Value);
                }
                tmp = tmp.Next;
            }
        }
    }
    public void EncontrarValue(T value)
    {
        bool comprobar = false;
        if (Head != null)
        {
            Node tmp = Head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                {
                    Debug.Log("Se encontró el elemento " + (value));
                    comprobar = true;
                }
                tmp = tmp.Next;
            }
            if (comprobar != true)
            {
                Debug.Log("No se encontró el elemento: " + value);
            }

        }
    }
    //Retorna la capacidad actual de la lista
    public int CapacityList()
    {
        return count;
    }

    public void PrintAllNode()
    {
        Node tmp = Head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
    }
}