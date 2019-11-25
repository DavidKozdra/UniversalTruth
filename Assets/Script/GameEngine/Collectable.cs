using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

    Player player => FindObjectOfType<Player>();
    int value = 10;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Player") {
            player.AddText.gameObject.SetActive(true);
            player.AddText.text = "+" + value;
            player.Currency += value;
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Planatoid")
        {
          Planet p=  col.gameObject.GetComponent<Planet>();
          p.Reasource += 10;
            if (p.Owned) {

                player.AddText.gameObject.SetActive(true);
                player.AddText.text = "+" + value;
            }
          Destroy(gameObject);
        }

    }
}
