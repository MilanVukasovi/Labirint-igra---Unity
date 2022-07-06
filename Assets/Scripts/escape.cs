using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class escape : MonoBehaviour
{
    public GameObject EscapeObj;
    public GameObject Player;
    public bool esc = false;

    public Button btnMeni;
    public Button btnIzadi;
    void Start()
    {
        EscapeObj.SetActive(false);

        btnMeni.GetComponent<Button>();
        btnMeni.onClick.AddListener(NatragUMeni);
        btnIzadi.GetComponent<Button>();
        btnIzadi.onClick.AddListener(IzadiIzIgre);

        Time.timeScale = 1;
        Cursor.visible = false;
        Player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (esc == false)
            {
                EscapeObj.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                
                esc = true;
            } else
            {
                EscapeObj.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Player.GetComponent<FirstPersonController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                esc = false;
            }
            
        }
    }

    public void NatragUMeni()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    void IzadiIzIgre()
    {
        Application.Quit();
    }
}
