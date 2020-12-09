using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_options : MonoBehaviour
{
    public GameObject instructions;
    public Animator m_Animator;
    //public void Awake()
    //{
    //   // instructions.SetActive(false);
    //    if(PlayerPrefs.GetString("TouchControls")!= "On"  && PlayerPrefs.GetString("TouchControls")!= "Off")
    //        PlayerPrefs.SetString("TouchControls", "On");
    //    transform.GetComponentInChildren<Text>().text = PlayerPrefs.GetString("TouchControls");


    //}
    //public void ToggleControlls()
    //{
    //    if (transform.GetComponentInChildren<Text>().text == "On")
    //    {
    //        PlayerPrefs.SetString("TouchControls", "Off");
    //        transform.GetComponentInChildren<Text>().text = "Off";
    //    }
    //    else if (transform.GetComponentInChildren<Text>().text == "Off")
    //    {
    //        PlayerPrefs.SetString("TouchControls", "On");
    //        transform.GetComponentInChildren<Text>().text = "On";         
    //    }

    //}
    public void Instructions()
    {
        m_Animator.SetTrigger("anim");
    }

}
