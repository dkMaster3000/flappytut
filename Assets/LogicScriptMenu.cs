using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScriptMenu : MonoBehaviour
{

    public AudioSource mainMusik;


    // Start is called before the first frame update
    void Start()
    {
        if (mainMusik)
        {
            mainMusik = GetComponent<AudioSource>();
            DontDestroyOnLoad(mainMusik);
            mainMusik.Play();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);   
        
    }

    public void stopGame()
    {
        Application.Quit();
    }

}
