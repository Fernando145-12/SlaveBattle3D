using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puntaje", menuName = "ScriptableObject/Score/Puntaje", order = 1)]
public class Puntaje1 : ScriptableObject
{

    [SerializeField] private float _score;

    public void SetScore(float pnt)
    {
        _score = pnt;
    }
    public float GetScore()
    {
        return _score ;
    }
}
