using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_handler : MonoBehaviour
{
    public Text score_new;
    public Score_Handler score_old;




    private Camera maincam;


    public void Awake()
    {
        maincam = Camera.main;
        maincam.backgroundColor = Color.green;
        score_new.text = score_old.score.text;
        score_old.gameObject.SetActive(false);
    }
}
