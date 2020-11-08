using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    Player player => FindObjectOfType<Player>();
    public GameObject indicater;
    public int Reasource = 10,life;
    // Use this for initialization

    void Start()
    {
        if (Reasource != 0) {
            Reasource = rand(1, Reasource);
        }

        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x + (Reasource/5), gameObject.transform.localScale.y + (Reasource / 5));
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
            player.Currency += Reasource;
            GameObject.Instantiate(indicater,new Vector2(transform.position.x +.1f,transform.position.y),Quaternion.identity);
            gameObject.SetActive(false);
        }
         else if (col.gameObject.tag == "Sun" || col.gameObject.tag == "Astroid" ) {

            gameObject.SetActive(false);
        }

    }
}
