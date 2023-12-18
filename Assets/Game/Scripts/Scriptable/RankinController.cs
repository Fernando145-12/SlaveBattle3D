using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RankinController", menuName = "ScriptableObject/Score/RankinController", order = 2)]

public class RankinController : ScriptableObject
{
    [SerializeField] public Puntaje1[] maxScore;
    public void InsertionSort(Puntaje1[] maxScore)
    {
        //int tmp;
        Puntaje1 listaRankin = new Puntaje1(); // +1 
        int j;
        for (int i = 0; i < maxScore.Length; ++i) // +1 +n(1+Interna+2)
        {
            j = i;
            //tmp = maxScore[i];
            listaRankin.SetScore(maxScore[i].GetScore());//+2
            while (j > 0 && maxScore[j - 1].GetScore() > listaRankin.GetScore())
            {
                maxScore[j].SetScore(maxScore[j - 1].GetScore());
                j--;
            }
            maxScore[j].SetScore(listaRankin.GetScore());
        }
    }

 


}
