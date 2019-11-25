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
    public Sprite Icon;

}


public class Planet : MonoBehaviour
{

    public GameObject Medal, Highlight;
    public string Name;
    public int Reasource;
    [SerializeField] Event[] Events;
    public bool Owned;
    public static bool Selected;
    public Player p => FindObjectOfType<Player>();

    int rand(int Min, int Max)
    {
        return UnityEngine.Random.Range(Min, Max); ;
    }

    // Use this for initialization
    void Start()
    {
        //Display = GameObject.Find("PDis");
        //NameText = GameObject.Find("Name").GetComponent<Text>(); 
        //InfoText = GameObject.Find("Info").GetComponent<Text>(); 
        if (Reasource == 0) {
            Reasource = rand(1, 200);
        }
        if (Owned) {
            Buy();
        }
    }

    public void Buy()
    {

        p.OwnedPlanets.Add(gameObject);
        Owned = true;

    }


    // Update is called once per frame
    void Update()
    {

        foreach (Event e in Events)
        {

        }

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