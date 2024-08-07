using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapHeight = 10;
    public int mapWidth = 10;
    public int seed;
    public Vector2 offset;
    public float noiseScale;
    public int octaves = 4;
    public float persistance = 0.5f;
    public float lacunarity = 2;
    
    public bool autoUpdate;
    public void GenerateMap(){
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth,mapHeight,seed,noiseScale,octaves,persistance,lacunarity,offset);

        MapDisplay display = FindObjectOfType<MapDisplay> ();
        display.DrawNoiseMap(noiseMap);
    }
}
