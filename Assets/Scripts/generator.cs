using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Celija
{
    public Celija roditelj;
    public static Celija DohvatiRoditelja(Celija celija)
    {
        if (celija.roditelj == null)
        {
            return celija;
        }

        else
        {
            return DohvatiRoditelja(celija.roditelj);
        }
    }
}

public class Generator : MonoBehaviour
{
    public GameObject Zid;
    public GameObject Pocetak;
    public GameObject Kraj;
    public GameObject Player;

    public int sirina; // x
    public int duzina; // z

    public Celija[] celije;
    public List<Zid> zidovi = new List<Zid>();

    public void Start()
    {
        Player.SetActive(false);
        sirina = int.Parse(PlayerPrefs.GetString("sirina", "20"));
        duzina = int.Parse(PlayerPrefs.GetString("duzina", "20"));
        celije = new Celija[sirina * duzina];

        for (int i = 0; i < sirina * duzina; i++)
        {
            celije[i] = new Celija();
        }

        GenerirajGranice();
        GenerirajHorizontalnoUnutarnji();
        GenerirajVertikalnoUnutarnji();
        int brojZidova = zidovi.Count;
        for (int i = 0; i < brojZidova; i++)
        {
            Obrisi();
        }
        GenerirajPocetakICilj();
    }

    public void GenerirajGranice()
    {
        int ZidIndex = 0;
        for (int x = 0; x <= sirina; x++)
        {
            if (x == 0 || x == sirina)
            {
                for (int z = 1; z <= duzina; z++)
                {
                    GameObject zid = (GameObject)Instantiate(Zid, new Vector3((x * 4), 0, (z * 4)), Quaternion.Euler(0, 90, 0));
                    zid.name = "ZidHorizontal " + ZidIndex;
                    ZidIndex++;
                }
            }
        }
        ZidIndex = 0;
        for (int z = 0; z <= duzina; z++)
        {
            if (z == 0 || z == duzina)
            {
                for (int x = 0; x < sirina; x++)
                {
                    GameObject zid = (GameObject)Instantiate(Zid, new Vector3((x * 4) + 2f, 0, (z * 4) + 2f), Quaternion.Euler(0, 0, 0));
                    zid.name = "ZidVertical " + ZidIndex;
                    ZidIndex++;
                }
            }
        }
    }
    public void GenerirajHorizontalnoUnutarnji()
    {
        int ZidIndex = 0;

        for (int z = 1; z <= duzina; z++)
        {
            for (int x = 1; x < sirina; x++)
            {
                GameObject instanca = (GameObject)Instantiate(Zid, new Vector3((x * 4), 0, (z * 4)), Quaternion.Euler(0, 90, 0));
                instanca.AddComponent<Zid>();

                instanca.GetComponent<Zid>().celije = new Celija[2];
                instanca.GetComponent<Zid>().celije[0] = celije[ZidIndex];
                instanca.GetComponent<Zid>().celije[1] = celije[ZidIndex + 1];

                zidovi.Add(instanca.GetComponent<Zid>());
                ZidIndex++;
            }
            ZidIndex++;
        }
    }

    public void GenerirajVertikalnoUnutarnji()
    {
        int ZidIndex = 0;

        for (int z = 1; z < duzina; z++)
        {
            for (int x = 0; x < sirina; x++)
            {
                GameObject instanca = (GameObject)Instantiate(Zid, new Vector3((x * 4) + 2f, 0, (z * 4) + 2f), Quaternion.Euler(0, 0, 0));
                instanca.AddComponent<Zid>();

                instanca.GetComponent<Zid>().celije = new Celija[2];
                instanca.GetComponent<Zid>().celije[0] = celije[ZidIndex];
                instanca.GetComponent<Zid>().celije[1] = celije[ZidIndex + 1];

                zidovi.Add(instanca.GetComponent<Zid>());
                ZidIndex++;
            }
        }
    }
    public void Obrisi()
    {
        int random = UnityEngine.Random.Range(0, zidovi.Count);
        Zid nasumicanZid = zidovi[random];
        zidovi.RemoveAt(random);

        if (Celija.DohvatiRoditelja(nasumicanZid.celije[0]) != Celija.DohvatiRoditelja(nasumicanZid.celije[1]))
        {
            Celija.DohvatiRoditelja(nasumicanZid.celije[1]).roditelj = nasumicanZid.celije[0];
            nasumicanZid.ObrisiZid();
        }
    }

    public void GenerirajPocetakICilj()
    {
        int random1 = UnityEngine.Random.Range(0, duzina * 2);
        int random2 = UnityEngine.Random.Range(0, sirina * 2);

        GameObject horizontal = GameObject.Find("ZidHorizontal " + random1);
        if(random1 < duzina)
        {
            Pocetak.transform.position = new Vector3(horizontal.transform.position.x - 2.55f, Pocetak.transform.position.y, horizontal.transform.position.z);
            Pocetak.transform.Rotate(Pocetak.transform.rotation.x, Pocetak.transform.rotation.y + 90, Pocetak.transform.rotation.z);
        }
        else
        {
            Pocetak.transform.position = new Vector3(horizontal.transform.position.x + 2.55f, Pocetak.transform.position.y , horizontal.transform.position.z);
            Pocetak.transform.Rotate(Pocetak.transform.rotation.x, Pocetak.transform.rotation.y + 270, Pocetak.transform.rotation.z);
        }
        Destroy(horizontal);

        GameObject vertical = GameObject.Find("ZidVertical " + random2);
        if (random2 < sirina)
        {
            Kraj.transform.position = new Vector3(vertical.transform.position.x, Pocetak.transform.position.y, vertical.transform.position.z - 2.55f);
            Kraj.transform.Rotate(Pocetak.transform.rotation.x, Pocetak.transform.rotation.y, Pocetak.transform.rotation.z);
        }
        else
        {
            Kraj.transform.position = new Vector3(vertical.transform.position.x, Pocetak.transform.position.y, vertical.transform.position.z + 2.55f);
            Kraj.transform.Rotate(Pocetak.transform.rotation.x, Pocetak.transform.rotation.y + 180, Pocetak.transform.rotation.z);
        }
        Destroy(vertical);
        Player.transform.SetPositionAndRotation(Pocetak.transform.position, Pocetak.transform.rotation);
        Player.SetActive(true);        
    }
}

