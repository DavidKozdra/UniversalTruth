using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[Serializable]
public class Event
{

    public string Description;
    public int Cost;
    public Image Icon;

}


public class Planet : MonoBehaviour
{

    public GameObject Medal, Highlight,Display, BuyDisplay, MineB, EnslaveB, TradeB, HarvestB, MainDisplay,Dyson;
    public string Name;
    public int Reasource, Life;
    public bool Owned,renew;
    public string[] Names = { "Gia " , "Gazorpazorp", "Alphabetrium", "Vogsphere ", "Cybertron ", "Dagobah ", "Dirt","Vegetable" };
    public int Cost;
    public static bool Selected;
    public Player p => FindObjectOfType<Player>();
    public Text Costtext, Resouces,NameText;

    int rand(int Min, int Max)
    {
        return UnityEngine.Random.Range(Min, Max); ;
    }

    // Use this for initialization
    void Start()
    {

            Name = Names[rand(0,Names.Length)];
        
        p.P = null;
        // BuyDisplay = GameObject.Find("Buy");
        //MainDisplay = GameObject.Find("MainDisplay");
        //NameText = GameObject.Find("Name").GetComponent<Text>(); 
        //InfoText = GameObject.Find("Info").GetComponent<Text>(); 
        if (Reasource == 0)
        {
            Reasource = rand(1, 200);
            Life = rand(0, rand(0, 200));
        }
        if (Owned)
        {
            Medal.SetActive(Owned);
            BuyDisplay.SetActive(false);
        }
    }

    public void Buy()
    {
        if (p.Currency >= Cost)
        {
            p.Currency -= Cost;
            p.AddText.gameObject.SetActive(true);
            p.AddText.text = "-" + Cost;
            p.OwnedPlanets.Add(gameObject);
            BuyDisplay.SetActive(false);
            Owned = true;
            CalculateButtons();
            MainDisplay.SetActive(true);
        }
        else {
            p.AddText.gameObject.SetActive(true);
            p.AddText.text = "Not enough Money";
        }
        CalculateButtons();
    }

    public void CalculateButtons()
    {

        if (Owned)
        {
            if (p.P != null)
            {
                if (gameObject.name == p.P.name)
                {
                    MineB.SetActive(true);
                    HarvestB.SetActive(true);
                    EnslaveB.SetActive(true);

                }
            }
            else {
                MineB.SetActive(false);
                HarvestB.SetActive(false);
                EnslaveB.SetActive(false);
            }
        }
 
    }
    public void Enslave()
    {
        if (Life >= 1)
        {
            if (p.P != null)
            {
                p.P.Life -= 1;
                p.EarningRate += 2;
               
            }
        }
        CalculateButtons();
    }
    public void BuyMine()
    {
        if (Reasource >= 50 && p.Currency >=25)
        {
            if (p.P!= null) {
                p.P = gameObject.GetComponent<Planet>();
                p.P.Reasource -= 50;
                p.Currency -= 25;
                p.EarningRate += 2;
                p.AddText.gameObject.SetActive(true);
                p.AddText.text = "-" + 50;
            }
            else { print( " am null"); }
        }
        CalculateButtons();

    }
    public void Renew()
    {
        if (Reasource >= 100 && p.Currency >=100)
        {
            if (p.P != null)
            {
                p.P = gameObject.GetComponent<Planet>();
                p.Currency -= 100;
                p.AddText.gameObject.SetActive(true);
                p.AddText.text = "-" + 100;
            }
            else { print(" am null"); }
        }
        CalculateButtons();
    }
    public void CalculateMass()
    {
        int mass = Reasource - 90;
        if (transform.localScale.x <= (mass) / 2)
        {
            if (transform.localScale.x <= 11)
            {
                transform.localScale += new Vector3(.1f, .1f, 0);
            }
        }
        else if (transform.localScale.x >= (mass) / 2)
        {
            if (transform.localScale.x >= 3)
            {
                transform.localScale -= new Vector3(.1f, .1f, 0);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Cost== 0) {
            Cost = Reasource / 2 + rand(0,50);
        }
        if (p.Timer <= .1f)
        {
            if (Life >= 2) {
                Life++;
                print("add life");
            }
        }
        CalculateMass();


        if (Reasource <= 0)
        {
            //Died
            Destroy(gameObject);
            print("Die");
        }
        Costtext.text = "Cost:" + Cost; 
        Medal.SetActive(Owned);
        Resouces.text = "Reasoces:" + Reasource + " Life forms " + Life;
        NameText.text = Name;
    }

    private void OnMouseDown()
    {
        // on UI elements 
        if (!Selected)
        {
            Display.SetActive(!Display.activeSelf);
            p.P = gameObject.GetComponent<Planet>();
            Selected = true;
        }
        else {
            if (p.P == gameObject.GetComponent<Planet>())
            {
                Selected = false;
                p.P = null;
                Display.SetActive(false);
            }
            else if(p.P != gameObject.GetComponent<Planet>()) {
                if (p.P !=null) {
                    p.P.Display.SetActive(false);
                } 
                print("Different");
                Selected = false;
                p.P = gameObject.GetComponent<Planet>();
                p.P.Display.SetActive(true);
            }
        }
    }


    void OnMouseOver()
    {
        Highlight.SetActive(true);

    }
    void OnMouseExit()
    {
        Highlight.SetActive(false);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Planet")
        {
            Destroy(col.gameObject);
            print("test");
        }
    }
}