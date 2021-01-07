using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_DescPannel : MonoBehaviour
{
    public Text DescTexte;

    // Start is called before the first frame update
    public void ChangeInfo(int valeur, int cooldown )
    {
        DescTexte.text = "+ " + valeur + " ressources "+ " en " + cooldown + " s.";
        Debug.Log(valeur + " / " + cooldown);

    }
}
