using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Button igrajButton;
    public Button izadiButton;

    public InputField sirina;
    public InputField duzina;
    void Start()
    {
        Button btnIgraj = igrajButton.GetComponent<Button>();
        btnIgraj.onClick.AddListener(PokreniIgru);
        Button btnIzadi = izadiButton.GetComponent<Button>();
        btnIzadi.onClick.AddListener(IzadiIzIgre);
    }

    void PokreniIgru()
    {
        string s = sirina.GetComponent<InputField>().text;
        PlayerPrefs.SetString("sirina", s);
        var d = duzina.GetComponent<InputField>().text;
        PlayerPrefs.SetString("duzina", d);
        SceneManager.LoadScene("Igra", LoadSceneMode.Single);
    }

    void IzadiIzIgre()
    {
        Application.Quit();
    }

}
