using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIManager : MonoBehaviour
{
    public Text score;
    public Text life;
    public MyCharacterStats _miplayer;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: ppp ";
        life.text = "Life : " + _miplayer._vida; 
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:"+(int)_miplayer.score;
        life.text = "Life : " + _miplayer._vida;
    }
}
