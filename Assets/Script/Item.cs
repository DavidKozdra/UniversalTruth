using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private ToolTip ToolTip;
    public string type;

    void Awake()
    {
        ToolTip = FindObjectOfType<ToolTip>();
    }

    private void OnMouseEnter()
    {
        //doesnt work at all or for stars 
        ToolTip.NameText.text = gameObject.name; //says not defined
        ToolTip.TypeText.text = type;
        ToolTip.IsTooltipVisable(true);  
    }

    private void OnMouseExit()
    {
        ToolTip.IsTooltipVisable(false);
    }
    // Start is called before the first frame update

    private void Update()
    {
        
        //if (gameObject.GetComponent<Renderer>().isVisible)
        //{
        //    gameObject.GetComponent<SpriteRenderer>().enabled = false;

        ////switch to turn other objects off
        //}
        //else {
        //    gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //}
        
    }


}
