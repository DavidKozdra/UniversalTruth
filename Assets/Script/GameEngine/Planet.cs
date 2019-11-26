using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject Medal, Highlight,BuyDisplay,MineB,Enslave,Trade,Harvest, MainDisplay;
    public string Name;
    public int Reasource,Life;
    [SerializeField] List<Event> Events = new List<Event>();
    public bool Owned;
    public int Cost;
    public static bool Selected;
    public Player p => FindObjectOfType<Player>();
    public Text Costtext;

    int rand(int Min, int Max)
    {
        return UnityEngine.Random.Range(Min, Max); ;
    }

    // Use this for initialization
    void Start()
    {

        foreach (Event e in Events)
        {

        }

        //Display = GameObject.Find("PDis");
        //NameText = GameObject.Find("Name").GetComponent<Text>(); 
        //InfoText = GameObject.Find("Info").GetComponent<Text>(); 
        if (Reasource == 0)
        {
            Reasource = rand(1, 200);
            Life = rand(0,rand(0,200));
        }
        if (Owned)
        {
            Buy();
        }
    }

    public void Buy()
    {
        if (p.Currency>= Cost) {
            p.Currency -= Cost;
            p.AddText.gameObject.SetActive(true);
            p.AddText.text = "-" + Cost;
            Medal.SetActive(Owned);
            p.OwnedPlanets.Add(gameObject);
            Owned = true;
        }

    }
    public void Mine() {
        if (Reasource>=50) {
            MineB.SetActive(true);
            Reasource -= 50;
        }

    }

    public void CalculateMass(){
        int mass = Reasource - 90;
        if (transform.localScale.x <= (mass)/2)
        {
            if (transform.localScale.x <= 11)
            {
                transform.localScale += new Vector3(.1f, .1f, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (p.Timer<=0&&Life>=2) {
            Life++;
        }
        CalculateMass();
        MainDisplay.SetActive(!BuyDisplay.activeSelf);

        if (Reasource <= 0) {
            //Died
            print("Die");
        }
        Medal.SetActive(Owned);

    }

    private void OnMouseDown()
    {
     
        if (!Selected)
        {
            p.P = gameObject.GetComponent<Planet>();
            Selected = true;
        }
        else {
            Selected = false;
            p.P = null;
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
        if (col.gameObject.tag == "Planet") {
            Destroy(col.gameObject);
            print("test");
        }
    }
}