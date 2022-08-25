using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button igrajButton;
    public Button izadiButton;

    public InputField sirina;
    public InputField duzina;
    void Start()
    {
        igrajButton.onClick.AddListener(PokreniIgru);
        izadiButton.onClick.AddListener(IzadiIzIgre);
    }

    void PokreniIgru()
    {
        string s = sirina.GetComponent<InputField>().text;
        PlayerPrefs.SetString("sirina", s);
        string d = duzina.GetComponent<InputField>().text;
        PlayerPrefs.SetString("duzina", d);
        SceneManager.LoadScene("Igra", LoadSceneMode.Single);
    }

    void IzadiIzIgre()
    {
        Application.Quit();
    }

}
