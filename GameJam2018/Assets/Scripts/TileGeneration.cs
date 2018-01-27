using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour {

    //Actualmente los tiles del juego son de 30*30 pixeles y el espacio del juego es de 600*600 pixeles
    //Por lo cual nos caben 20 tiles horizontal y verticalmente de ser modificado hay que tener el siguiente codigo en mente
    private int maxTiles = 20;
    private float tileSize = 120;


    public GameObject wall;
    public GameObject empty;
    //                           1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
    private int[] map= new int[]{1,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,0,0 //1
                                ,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0 //2
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0 //3
                                ,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0 //4
                                ,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 //5
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //6
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //7
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //8
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //9
                                ,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0 //0
                                ,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0 //1
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //2
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //3
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //4
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //5
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //6
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //7
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //8
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 //9
                                ,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};//0
    void Awake()
    {
        int k = 0;
        //x     y   z
        Vector3 coordenadas = new Vector3(-1150,1150, 0);
        for (int i = 0; i < maxTiles; i++)
        {
            for(int j = 0; j < maxTiles; j++)
            {
                if (map[k] == 0)
                {

                    Instantiate<GameObject>(wall, coordenadas, Quaternion.identity);
                }
                else if(map[k] == 1)
                {
                    Instantiate<GameObject>(empty, coordenadas, Quaternion.identity);
                }
                coordenadas.x += tileSize;
                k++;
            }
            coordenadas.y -= tileSize;
            coordenadas.x = -1150;
        } 
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
