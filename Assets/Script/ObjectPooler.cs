using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    //public static ObjectPooler Current;
    public GameObject Pooledobject;
    public int Poolamount;
    public bool willgrow;
    public List<GameObject> Objects;
    public float Timer, YRange, XRange;
    public bool Planet;
    float o;
    // Start is called before the first frame update
    void Start()
    {
        if (Planet) {
            Poolamount = (int)gameObject.transform.localScale.x * 5;
        }
        o = Timer;
        Objects = new List<GameObject>();
        //Current = this;
        for (int i = 0; i < Poolamount; i++)
        {
            GameObject ob = Instantiate(Pooledobject);
            ob.SetActive(false);
            Objects.Add(ob);
        }
    }
    int rand(int Min, int Max)
    {
        return Random.Range(Min, Max); ;
    }
    float rand(float Min, float Max)
    {
        return Random.Range(Min, Max); ;
    }
    private void Update()
    {
        if (Planet) {
            XRange = gameObject.transform.localScale.x - .7f;
            YRange = gameObject.transform.localScale.y - .7f;
        }
        if (Timer <= 0)
        {
            GameObject G = GetPooled();
            if (G != null) {
                if (Planet)
                {
                    G.transform.position = new Vector2(rand(gameObject.transform.position.x + -XRange, gameObject.transform.position.x + XRange), rand(gameObject.transform.position.y + -YRange, gameObject.transform.position.y + YRange));
                }
                else {
                    G.transform.position = new Vector2(rand(-XRange, XRange), rand(-YRange, YRange));
                }
                    G.gameObject.SetActive(true);
            }
            Timer = o;
        }
        else {
            Timer -= Time.deltaTime;
        }
    }

    public GameObject GetPooled() {

        for (int i = 0; i < Objects.Count; i++)
        {
            if (!Objects[i].activeInHierarchy) {
                return Objects[i];
            }
        }
        if (willgrow) {
            GameObject ob = Instantiate(Pooledobject);
            Objects.Add(ob);
            return ob;

        }
        return null;
    }
}
