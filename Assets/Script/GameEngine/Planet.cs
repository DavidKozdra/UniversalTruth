using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Planet : MonoBehaviour
{
    public UIManager UIManager;
    public GameObject Medal,Explosion;
    public string Name;
    public int Reasource, Life, MineCost=50,Farm;
    public bool Owned;
    public string[] Names = { "Gia ", "Gazorpazorp", "Alphabetrium", "Vogsphere ", "Cybertron ", "Dagobah ", "Dirt", "Vegetable", "Proxima Centauri", "Wolf 359#", "Lalande 21185", "Epsilon Eridani", "Tau Ceti", "Gliese 1061", "Gliese 784", "CD Ceti", "AU Microscopii", "Stav","HomeWorld","Hikikomori","Slarf","Sqwanch" };
    public int Cost;
    public static bool Selected;
    public Sprite image;
    public Player Player => FindObjectOfType<Player>();

    public float oldspeed;

    int rand(int Min, int Max)
    {
        return UnityEngine.Random.Range(Min, Max); ;
    }

    // Use this for initialization
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        image = GetComponent<SpriteRenderer>().sprite;
        int r = rand(1, 3);
        if (gameObject.GetComponent<Orbit>() != null)
        {
            oldspeed = gameObject.GetComponent<Orbit>().OrbitSpeed;
        }

        Name = Names[rand(0, Names.Length)];
        name = Name;
        Player.P = null;
        Reasource = rand(70, 700);
        Life =  rand(0, 500);
        
    }

    public void CalculateMass()
    {   
        // fuck broken
        float mass = Reasource - 90;
        if (transform.localScale.x <= (mass /30))
        {
            transform.localScale += new Vector3(.1f, .1f, 0);
            
        }
        else if (transform.localScale.x > (mass) / 29)
        {
            if (transform.localScale.x > 3)
            {
                transform.localScale -= new Vector3(.1f, .1f, 0);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

        CalculateMass();
        if (Cost == 0)
        {
            Cost = Reasource / 2 + rand(0, 20) + Life/20 ;
        }
        if (Player.Timed)
        {
            if (Life >= 2)
            {
                int mod = (int)Life / 2; //breeding
                Life -= (int)Life /4; //breeding
                Life += mod + Farm;
            }
        }
        if (gameObject.GetComponent<Planet>() == UIManager.CurrentPlanet) {
            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) >= 25) {
                Selected = false;
                UIManager.CurrentPlanet = null;
            }
        }
        if (Reasource <= 0)
        {
            //Die
            GameObject.Instantiate(Explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        // on UI elements 
        if (!Selected && !EventSystem.current.IsPointerOverGameObject())
        {
            //pass to UI
            UIManager.CurrentPlanet = gameObject.GetComponent<Planet>();
            Selected = true;
        }
        else if (!EventSystem.current.IsPointerOverGameObject()) {
            UIManager.CurrentPlanet = null;
            Selected = false;
        }
  
    }

    void OnMouseOver()
    {
        if (gameObject.TryGetComponent(out Orbit orbit))
        {
            oldspeed = orbit.OrbitSpeed;
            orbit.OrbitSpeed = 0;
        }
    }
    void OnMouseExit()
    {
        if (gameObject.TryGetComponent(out Orbit orbit))
        {
            orbit.OrbitSpeed = oldspeed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

         if (col.gameObject.tag == "Astroid")
        {   
            Reasource += col.gameObject.GetComponent<Collectable>().Reasource;
            if (Life < 0) { Life = 0; }
            if (Owned)
            {
                if (Reasource != 0)
                {
                    Life -= rand(-2, 20);
                }
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Planet")
        {
            if (col.gameObject.GetComponent<Planet>().Reasource>=Reasource) {
                Destroy(gameObject);
            }
        }
        else if(col.gameObject.tag == "Sun") {
         //   col.gameObject.GetComponent<Planet>().Reasource+=Reasource;
            Destroy(gameObject);
        }
    }
}