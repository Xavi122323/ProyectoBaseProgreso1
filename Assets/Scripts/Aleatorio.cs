using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aleatorio : MonoBehaviour , IDataPersistence
{
    public GameObject jugador;
    public GameObject botonFavor;
    public GameObject botonContra;
    [SerializeField] private GameObject votosFavor;
    [SerializeField] private GameObject votosContra;
    [SerializeField] private int[] votos;
    private Vector3 vectorFavor, vectorContra;
    private int ale;
    private int fav;
    private int con;
    private int votF = 0;

    public void LoadData(GameData data)
    {
        this.votF = data.votacionesFallidas;
    }

    public void SaveData(GameData data)
    {
        data.votacionesFallidas = this.votF;
    }

    void Start()
    {
        votos=new int[22];
        GameEventsManager.instance.votacionFallida += votacionFallida;
    }


    void Update()
    {
        Valores.votFallidas=votF;
    }

    private void OnCollisionEnter(Collision other) 
    {
        ale=-1;
        vectorFavor = new(-12,8,14);
        vectorContra = new(-12,6,14);
        fav=0;
        con=0;
        if(gameObject.name==("Favor")){
            Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),3);
            vectorFavor.x += 2;
            votos[0]=1;
            for(int i = 0; i <= 20; i++){
                if(i<4 && Valores.capitalPol>=50){
                    Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),3);
                    vectorFavor.x += 2;
                    votos[i+1]=1;
                    if(i==3){
                        GameEventsManager.instance.votacionCap();
                    }
                }else{
                    ale=Random.Range(0, 2);
                    if(ale==1){
                        Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),3);
                        vectorFavor.x += 2;
                        votos[i+1]=1;
                    }else if(ale==0){
                        Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),3);
                        vectorContra.x += 2;
                        votos[i+1]=0;
                    }
                }
            }
        }else if(gameObject.name==("Contra")){
            Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),3);
            vectorContra.x += 2;
            votos[0]=0;
            for(int i = 0; i <= 20; i++){
                if(i<4 && Valores.capitalPol>=50){
                    Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),3);
                    vectorContra.x += 2;
                    votos[i+1]=0;
                    if(i==3){
                        GameEventsManager.instance.votacionCap();
                    }
                }else{
                    ale=Random.Range(0, 2);
                    if(ale==0){
                        Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),3);
                        vectorContra.x += 2;
                        votos[i+1]=0;
                    }else if(ale==1){
                        Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),3);
                        vectorFavor.x += 2;
                        votos[i+1]=1;
                    }
                }
            }
        }
        foreach( var vot in votos)
        {
            if(vot == 1)
            {
                fav += 1;
            }else if(vot == 0){
                con += 1;
            }
        }

        Debug.Log("votos a favor " + fav);
        Debug.Log("votos en contra " + con);

        if(fav>con)
        {
            Debug.Log("La ley pasa");
        }else if(con>fav || con==fav)
        {
            Debug.Log("La ley se niega");
            GameEventsManager.instance.votacionFallidaCap();
            if(Valores.votFallidas>=2)
            {
                DataPersistenceManager.instance.NewGame();
                SceneManager.LoadSceneAsync(0);
            }
        }

    }

    public void votacionFallida()
    {
        votF ++;
    }
}
