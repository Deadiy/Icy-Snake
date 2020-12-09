using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Handler : MonoBehaviour
{
    public Text score;
    public GameObject player;

    private void FixedUpdate()
    {
        score.text = player.GetComponent<PlayerController>().score.ToString();
    }

}
