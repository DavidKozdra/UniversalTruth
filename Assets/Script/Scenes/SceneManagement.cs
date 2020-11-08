using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Q()
    {
        Application.Quit();
    }
    public void TransferTo(string scene) {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
