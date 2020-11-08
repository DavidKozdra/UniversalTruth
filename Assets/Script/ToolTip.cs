using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public Text NameText, TypeText;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        IsTooltipVisable(false);

    }

    public void IsTooltipVisable(bool a)
    {
        if (a) {
            canvasGroup.alpha = 1;
        }
        else {
            canvasGroup.alpha = 0;
        }
    }


    // Update is called once per frame
}
