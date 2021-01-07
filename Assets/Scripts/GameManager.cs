using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int ressources { get; set; }

    public int clickValue = 1;

    public int betterClickCost = 0;

    [Space(10)]

    public Text RessourcesText;
    public Text ManualTextValue;
    public Text IncomeText;

    //public List<GameObject> DescPannels = new List<GameObject>();

    [Space(10)]

    public Text FabriqueButtonText;
    public Text UsineButtonText;
    public Text ComplexeIndustrielButtonText;

    [Space(10)]

    public Text FabriquePriceText;
    public Text UsinePriceText;
    public Text ComplexeIndustrielPriceText;
    public Text BetterClickPriceText;

    [Space(10)]

    public List<string> Names = new List<string>();
    public List<int> Numbers = new List<int>();
    public List<int> Cost = new List<int>();
    public List<int> Cooldown = new List<int>();
    public List<int> Rates = new List<int>();
    private List<float> Counters = new List<float>() { 0, 0, 0 };




    void Start()
    {
        ressources = 0;
        UptadeRessourcesText();


        FabriquePriceText.text = Cost[0].ToString();
        UsinePriceText.text = Cost[1].ToString();
        ComplexeIndustrielPriceText.text = Cost[2].ToString();
        BetterClickPriceText.text = betterClickCost.ToString();
        ManualTextValue.text = clickValue.ToString();

    }


    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            Counters[i] += Time.deltaTime;
            if (Counters[i] >= Cooldown[i])
            {
                int total = Rates[i] * Numbers[i];
                Increment(total);
                Counters[i] -= Cooldown[i];

            }

            
        }
        Income();

    }

    public void Increment(int value)
    {
        ressources += value;
        UptadeRessourcesText();
    }

    public void ClickForRessouces()
    {
        Increment(clickValue);
    }

    public void AddMachine(int machineNb)
    {
        if (ressources >= Cost[machineNb])
        {
            ressources -= Cost[machineNb];
            UptadeRessourcesText();
            Numbers[machineNb]++;
            AugmentePrix(machineNb);
            switch (machineNb)
            {
                case 0: FabriqueButtonText.text = Names[machineNb] + " : " + Numbers[machineNb]; break;
                case 1: UsineButtonText.text = Names[machineNb] + " : " + Numbers[machineNb]; break;
                case 2: ComplexeIndustrielButtonText.text = Names[machineNb] + " : " + Numbers[machineNb]; break;
            }

        }
    }

    public void BetterClick(int value)
    {
        if (ressources >= betterClickCost)
        {
            ressources -= betterClickCost;
            UptadeRessourcesText();
            clickValue += value;
            ManualTextValue.text = clickValue.ToString();
            BetterClickAugmentePrice();
        }
    }

    public void BetterClickAugmentePrice()
    {
        betterClickCost += betterClickCost / 2;
        BetterClickPriceText.text = betterClickCost.ToString();
    }

    public void AugmentePrix(int machineNb)
    {
        Cost[machineNb] += Cost[machineNb] / 2;

        switch (machineNb)
        {
            case 0: FabriquePriceText.text = Cost[machineNb].ToString(); break;
            case 1: UsinePriceText.text = Cost[machineNb].ToString(); break;
            case 2: ComplexeIndustrielPriceText.text = Cost[machineNb].ToString(); break;
        }
    }

    public void DisplayPannel(GameObject InfoPannel)
    {
        InfoPannel.SetActive(true);
    }

    int infoValue;
    public void PannelChangeInfo(Scr_DescPannel script)
    {
        script.ChangeInfo(Rates[infoValue], Cooldown[infoValue]);
    }
    
    public void ChangeValue (int Value) { infoValue = Value; }

    public void HideInfo(GameObject InfoPannel)
    {
        InfoPannel.SetActive(false);
    }

    public void UptadeRessourcesText()
    {
        RessourcesText.text = ressources.ToString();
    }


    int totalIncome;
    public void Income()
    {
        totalIncome = (Rates[0] * Numbers[0])/Cooldown[0] + (Rates[1] * Numbers[1])/Cooldown[1] + (Rates[2] * Numbers[2]) / Cooldown[2];
        IncomeText.text = totalIncome.ToString() + " /SEC";
    }
}
