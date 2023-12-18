using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class GAmeController : MonoBehaviour
{
    [SerializeField] public MyCharacterStats player;
    public EnemyClass jefe;
    [SerializeField] public Puntaje1 puntaje1;

    public UnityEvent Win;
    public UnityEvent Inicio;
    public UnityEvent GameOver;
    public Text[] lisRankin;
    public RankinController lisRankinCont;
    private bool isPaused = false;
    void Start()
    {
        Time.timeScale = 0;
    }
    public void PrintRankin()
    {
        for (int i = 0; i < lisRankin.Length; i++)
        {
            lisRankin[i].text = " " + lisRankinCont.maxScore[i].GetScore();
        }
    }
    public void SetPoint()
    {
        puntaje1.SetScore(player.score);
        puntaje1 = lisRankinCont.maxScore[3];
        lisRankinCont.InsertionSort(lisRankinCont.maxScore);
    }
    // Update is called once per frame
    void Update()
    {
        if (jefe._vida <9)
        {
            Debug.Log("ACABOOOOGANA");
            Win?.Invoke();
        }
        if (player._vida <= 0)
        {
            Debug.Log("ACABOOOOPIERDE");
            GameOver?.Invoke();
        }
        PrintRankin();
    }
    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = true;
        }
    }
    public void Play()
    {
            Time.timeScale = 1;      
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
