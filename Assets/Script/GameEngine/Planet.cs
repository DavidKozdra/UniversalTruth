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
    public int Reasource, Life, MineCost=50,Farm, FarmCost=25,FactoryCost=500,school = 0,schoolcost =100;
    public bool Owned;
    public string[] Names = { "Gia ", "Gazorpazorp", "Alphabetrium", "Vogsphere ", "Cybertron ", "Dagobah ", "Dirt", "Vegetable", "Proxima Centauri", "Wolf 359#", "Lalande 21185", "Epsilon Eridani", "Tau Ceti", "Gliese 1061", "Gliese 784", "CD Ceti", "AU Microscopii", "Stav","HomeWorld","Hikikomori","Slarf","Sqwanch" };
    public int Cost;
    public static bool Selected;
    public Sprite image;
    public AudioClip[] clips;
    private Player player;
    public float oldspeed;

    private void playsound(int index)
    {
        gameObject.GetComponent<AudioSource>().clip = clips[index];
        gameObject.GetComponent<AudioSource>().Play();
    }

    int rand(int Min, int Max)
    {
        return UnityEngine.Random.Range(Min, Max);
    }

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        UIManager = FindObjectOfType<UIManager>();
        image = GetComponent<SpriteRenderer>().sprite;
        if (gameObject.GetComponent<Orbit>() != null)
        {
            oldspeed = gameObject.GetComponent<Orbit>().OrbitSpeed;
        }

        Name = Names[rand(0, Names.Length)];
        name = Name;
        Reasource = rand(70, 700);
        Life =  rand(0, 300);
        
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
        if (Life <= 0 ) {
            Life = 0;
        }

        CalculateMass();
        if (Cost == 0)
        {
            Cost = Reasource / 2 + rand(0, 20) + Life/20 ;
        }
        if (player.Timed) { //this is needed or things break
            if (Life >= 2)
            {
                int mod = (int)Life / 6; //breeding
                if ((Life / 100) >= Farm) // 100 people per farm 
                {
                    if ((Life / 100) != 0) {
                        Life -= (int)Life / 20; //death
                    }
                }
                else
                {
                    Life += mod + (Farm*5);
                }
            }
        }
        if (gameObject.GetComponent<Planet>() == UIManager.CurrentPlanet) {
            if (!gameObject.GetComponent<Renderer>().isVisible) {
                Selected = false;
                UIManager.CurrentPlanet = null;
            }
        }
        if (Reasource <= 0)
        {
            die();
        }
    }
    private void die() {
        GameObject.Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        // on UI elements 
        if (!Selected && !EventSystem.current.IsPointerOverGameObject())
        {
            playsound(0);
            //pass to UI
            UIManager.CurrentPlanet = gameObject.GetComponent<Planet>();
            Selected = true;
        }
        else if (!EventSystem.current.IsPointerOverGameObject()) {

            playsound(1);
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
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "Planet")
        {
            if (col.gameObject.GetComponent<Planet>().Reasource>=Reasource) {
                Destroy(gameObject);
            }
        }
        else if(col.gameObject.tag == "Sun") {
            //   col.gameObject.GetComponent<Planet>().Reasource+=Reasource;

            die();
        }
    }
}