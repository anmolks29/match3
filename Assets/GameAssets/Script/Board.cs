using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
//using Unity.Mathematics;
using System;
using System.Security.Cryptography;

public class Board : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject tilePrefabA;
    public GameObject tilePrefabB;
    
    public GameObject[] gameSymbolPrefab;
    
   
    
    MyTile[,] Alltiles;
    GameSymbol[,] allGamesymbols; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Alltiles = new MyTile[width, height];
        allGamesymbols = new GameSymbol[width, height];
        TilesSetup();
        
        FillRandom();
        


    }

    void TilesSetup() 
    {
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject prefabToUse; 
                if ((i + j) % 2 == 0)
                {
                    prefabToUse = tilePrefabA;
                }
                else
                {
                    prefabToUse = tilePrefabB;
                }
                GameObject tile = Instantiate(prefabToUse, new Vector3(i, j, 0), Quaternion.identity);
                tile.transform.parent = transform;

                tile.transform.localPosition = new Vector3(i, j, 0);
                tile.name = "(" + i + "," + j + ") Tile ";
                
                MyTile tileComp = tile.GetComponent<MyTile>();
                
                if (tileComp != null)
                {
                    Alltiles[i, j] = tileComp;
                    tileComp.x = i;
                    tileComp.y = j;
                }
                else
                {
                    Debug.LogWarning($"Missing MyTile component on prefab at ({i}, {j})");
                }
            }
        }
    }
    

   
    
   

     void FillRandom()
     {
         for (int i = 0; i < width; i++)
         {
             for (int j = 0; j < height; j++)
             {
                 int symbolIndex = UnityEngine.Random.Range(0, gameSymbolPrefab.Length);

                 
                 GameObject symbolGO = Instantiate(gameSymbolPrefab[symbolIndex]);
                 string originalName = gameSymbolPrefab[symbolIndex].name;
                 symbolGO.name = $"{originalName}_({i},{j})";

                
                symbolGO.transform.SetParent(transform, false);

                 
                 symbolGO.transform.localPosition = new Vector3(i, j, 0);

                 
                 GameSymbol symbolComp = symbolGO.GetComponent<GameSymbol>();
                 if (symbolComp != null)
                 {
                     symbolComp.SetCordinate(i, j);
                     allGamesymbols[i, j] = symbolComp;
                 }
             }
         }
     }

   





}


