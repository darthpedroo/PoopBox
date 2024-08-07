using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapHeight = 10;
    public int mapWidth = 10;
    public int seed;
    public Vector2 offset;
    
    public int octaves = 4;
    [Range(0,1)]
    public float persistance = 0.5f;
    public float lacunarity = 2;
    public float noiseScale;
    
    public bool autoUpdate;
    public void GenerateMap(){
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth,mapHeight,seed,noiseScale,octaves,persistance,lacunarity,offset);

        MapDisplay display = FindObjectOfType<MapDisplay> ();
        display.DrawNoiseMap(noiseMap);
    }
    void onValidate(){
        if (mapWidth < 1){
            mapWidth = 1;
        } 
        if (mapHeight < 1){
            mapHeight = 1;
        }
    }
}
