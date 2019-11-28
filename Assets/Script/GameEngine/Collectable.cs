using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    Player player => FindObjectOfType<Player>();
    public int Reasource = 10,life;
    // Use this for initialization
    void Start()
    {
        if (Reasource != 0) {
            Reasource = rand(1, 12);
        }
        if (life!=0) {
            life = rand(1, 4);
        }
    }
    int rand(int Min, int Max)
    {
        return Random.Range(Min, Max); ;
    }
    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (Reasource != 0)
            {
                player.AddText.gameObject.SetActive(true);
                player.AddText.text = "+" + Reasource;
                Destroy(gameObject);
            }
            player.Currency += Reasource;
        }
        else if (col.gameObject.tag == "Planet")
        {
            Planet p = col.gameObject.GetComponent<Planet>();
            p.Reasource += Reasource;
            p.Life += life;
            if (p.Owned)
            {
                if (Reasource!=0) {
                    player.AddText.gameObject.SetActive(true);
                    player.AddText.text = "+" + Reasource;
                }
            }
            Destroy(gameObject);
        } else if (col.gameObject.tag == "Sun") {

            Destroy(gameObject);
        }

    }
}
