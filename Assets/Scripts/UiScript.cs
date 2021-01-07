using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public void Test(int fsdfgsefg)
    { }
    public void Show(GameObject ToShow)
    {
        ToShow.SetActive(true);
    }
    public void Hide(GameObject ToShow)
    {
        ToShow.SetActive(false);
    }
    public void HideIfShow(GameObject ToShow)
    {
        
        if (ToShow.active  == false)
        {
            ToShow.SetActive(true);
        }
        else if (ToShow.active  == true)
        {
            ToShow.SetActive(false);
        }
       
    }

    public void Test()
    {
        Debug.Log("Patate");
    }

}
