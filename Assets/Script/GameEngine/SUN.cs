using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUN : Planet
{

    // Use this for initialization
    void Start()
    {
        if (Owned)
        {
            Buy();
        }
        sun = true;
    }

    public void Buy()
    {
        if (p.Currency >= Cost)
        {
            p.Currency -= Cost;
            p.AddText.gameObject.SetActive(true);
            p.AddText.text = "-" + Cost;
            Medal.SetActive(Owned);
            p.OwnedPlanets.Add(gameObject);
            CalculateButtons();
            BuyDisplay.SetActive(false);
            Owned = true;
        }
    }
    public void C()
    {

        if (Owned)
        {
            if (MainDisplay != null)
            {
                MainDisplay.SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Costtext.text = "Cost:" + Cost;
        Medal.SetActive(Owned);
        NameText.text = Name;
        Resouces.text = "Reasoces:" + Reasource + " Life forms " + Life;
        CalculateMass();
    }


}
