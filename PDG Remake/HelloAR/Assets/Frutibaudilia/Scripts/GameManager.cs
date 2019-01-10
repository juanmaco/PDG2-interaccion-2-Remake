using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public GameObject mCanvas;
    public GameObject mVictoria;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameOver()
    {
        mCanvas.SetActive(true);
        Invoke("Restart", 5f);
    }
    void Restart()
    {
        SceneManager.LoadScene("frutibau");
    }
    public void Win()
    {
        mVictoria.SetActive(true);
        Invoke("Restart", 10f);
    }
}
