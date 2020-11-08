using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class Candidate
    {
        public float spawnWeight;
        public GameObject gameObject;
    }

    public List<Candidate> candidates = new List<Candidate>(); //define in the inspector. feel free to put this elsewhere if you like
    private float totalChance;
    public int Count, SpawnedMax;
    public float Timer = 2f,YRange, XRange;
    float OB;
    public bool Planet;

    public GameObject PickRandom()
    {
        float generated = UnityEngine.Random.Range(0, totalChance);
        foreach (Candidate candidate in candidates)
        {
            generated -= candidate.spawnWeight;

            if (generated <= 0)
            {
                return candidate.gameObject;
            }
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        OB = Timer;
        foreach (Candidate candidate in candidates)
        {
            totalChance += candidate.spawnWeight;
        }
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool stop = false;
        if (SpawnedMax != 0)
        {
            if (Count >= SpawnedMax)
            {
                stop = true;
            }
            else
            {
                stop = false;
            }
        }
        if (Timer <= 0)
        {
            if (!stop)
            {

                Count++;
                Instantiate(PickRandom(), new Vector3(gameObject.transform.position.x + rand(-XRange, XRange), gameObject.transform.position.y + rand(-YRange, YRange), -1), Quaternion.identity);
                //if (!Planet)
                //{
                //    Instantiate(PickRandom(), new Vector3(gameObject.transform.position.x + rand(-XRange, XRange), gameObject.transform.position.y + rand(-YRange, YRange), -1), Quaternion.identity);
                //}
                //else {
                //    Instantiate(PickRandom(), new Vector3( rand(XRange,YRange), rand(XRange, YRange), -1), Quaternion.identity);
                //}
            }
            Timer = OB;
        }
        else
        {
            Timer -= Time.deltaTime;
        }

        if (Planet) {
           XRange = gameObject.transform.localScale.x - .5f;
            YRange = gameObject.transform.localScale.y -.5f;
        }
    }
    float rand2(float Min, float Max)
    {
        return Random.Range(Min, Max);
    }
    int rand(int Min, int Max)
    {
        return Random.Range(Min, Max); ;
    }
    float rand(float Min, float Max)
    {
        return Random.Range(Min, Max); ;
    }
}

