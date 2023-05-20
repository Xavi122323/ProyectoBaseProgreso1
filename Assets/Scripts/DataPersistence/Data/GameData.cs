using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int capitalPolitico;
    public int votacionesFallidas;

    public GameData()
    {
        this.capitalPolitico = 0;
        this.votacionesFallidas = 0;
    }
}
