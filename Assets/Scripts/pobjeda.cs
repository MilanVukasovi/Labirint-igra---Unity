using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pobjeda : MonoBehaviour
{
    public GameObject pobjedaObj;
    public Text vrijeme;
    public Timer timer;
    public Button btn;
    public void Start()
    {
        pobjedaObj.SetActive(false);
    }
    void OnCollisionEnter(Collision kraj)
    {
        if (kraj.gameObject.name == "Kraj")
        {
            float v = Mathf.Round(timer.vrijeme * 100f) / 100f;
            vrijeme.text = "Vrijeme: " + v.ToString();
            Time.timeScale = 0;
            pobjedaObj.SetActive(true);
            this.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            btn.GetComponent<Button>();
            btn.onClick.AddListener(NatragUMeni);
        }     
    }
    public void NatragUMeni()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
