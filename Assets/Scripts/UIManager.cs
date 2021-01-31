using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public GameObject mapPanel;
    public GameObject pausePanel;
    bool pauseIsOn = false;
    bool mapIsOn = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePause()
    {
        pauseIsOn = !pauseIsOn;
        pausePanel.SetActive(pauseIsOn);
    }

    public void ToggleMap()
    {
        mapIsOn = !mapIsOn;
        mapPanel.SetActive(mapIsOn);
    }

    public void LoadScene(int value)
    {
        SceneManager.LoadScene(value);
    }
}
