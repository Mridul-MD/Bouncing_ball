using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreens : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sc2()
    {
        SceneManager.LoadScene("Scene 2");
    }
    public void sc3()
    {
        SceneManager.LoadScene("Scene 3");
    }
    public void sc1()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
