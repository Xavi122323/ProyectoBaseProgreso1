using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManejoCapital : MonoBehaviour, IDataPersistence
{
    private int capital = 0;

    public void LoadData(GameData data)
    {
        this.capital = data.capitalPolitico;
    }

    public void SaveData(GameData data)
    {
        data.capitalPolitico=this.capital;
    }

    public Slider CapitalP;

    void Start()
    {
        CapitalP.minValue=0;
        CapitalP.maxValue=100;
        GameEventsManager.instance.aumentar += aumentar;
        GameEventsManager.instance.disminuir += disminuir;
        GameEventsManager.instance.votacion += votacion;
    }


    void Update()
    {
        CapitalP.value=capital;
        Valores.capitalPol=capital;
    }

    public void aumentar()
    {
        capital += 25;
    }

    public void disminuir()
    {
        capital -= 25;
    }

    public void votacion()
    {
        capital -= 50;
    }


}
