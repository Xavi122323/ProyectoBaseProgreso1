using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;
    }

    public event Action aumentar;
    public void aumentarCap() 
    {
        if (aumentar != null) 
        {
            aumentar();
        }
    }

    public event Action disminuir;
    public void disminuirCap() 
    {
        if (disminuir != null) 
        {
            disminuir();
        }
    }

    public event Action votacion;
    public void votacionCap() 
    {
        if (votacion != null) 
        {
            votacion();
        }
    }

    public event Action votacionFallida;
    public void votacionFallidaCap() 
    {
        if (votacionFallida != null) 
        {
            votacionFallida();
        }
    }
}
