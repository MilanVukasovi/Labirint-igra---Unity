using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pobjeda : MonoBehaviour
{
    public GameObject pobjedaObj;
    public Text vrijeme;
    public timer timer;
    public Button btn;
    public void Start()
    {
        pobjedaObj.SetActive(false);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Kraj")
        {
            pobjedaObj.SetActive(true);
            float yourFloat = Mathf.Round(timer.vrijeme * 100f) / 100f;
            vrijeme.text = "Vrijeme: " + yourFloat.ToString();
            Time.timeScale = 0;
            Cursor.visible = true;
            this.GetComponent<FirstPersonController>().enabled = false;
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
