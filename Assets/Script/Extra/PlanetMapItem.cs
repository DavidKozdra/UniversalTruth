using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMapItem : MonoBehaviour
{
    public Vector3 SavedPostion;
    private Player player;
    public Image I;
    public TMP_Text NameText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        print("Pressed");
        player.transform.position = SavedPostion;
    }

    public void Pressed() {
        player.transform.position = SavedPostion;
    }
}
