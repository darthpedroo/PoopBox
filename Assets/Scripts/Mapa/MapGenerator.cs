using UnityEngine;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine.XR;

public class MapGenerator : MonoBehaviour {

	public enum DrawMode {NoiseMap, ColourMap,Mesh};
	public DrawMode drawMode;
	public const int mapChunkSize = 241;
	[Range(0,6)]
	public int editorPreviewLOD;
	public float noiseScale;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;
	public float meshHeightMultiplier;
	public AnimationCurve meshHeightCurve;

	public bool autoUpdate;

	public TerrainType[] regions;

	Queue<MapThreadInfo<MapData>> mapDataThreadInfoQueue = new Queue<MapThreadInfo<MapData>>();
	Queue<MapThreadInfo<MeshData>> meshDataThreadInfoQueue = new Queue<MapThreadInfo<MeshData>>();
	public void DrawMapInEditor(){
		MapData mapData =  GenerateMapData(Vector2.zero);
		MapDisplay display = FindObjectOfType<MapDisplay> ();
		if (drawMode == DrawMode.NoiseMap) {
			display.DrawTexture (TextureGenerator.TextureFromHeightMap(mapData.heightMap));
		} else if (drawMode == DrawMode.ColourMap) {
			display.DrawTexture (TextureGenerator.TextureFromColourMap(mapData.colourMap, mapChunkSize, mapChunkSize));
		} else if (drawMode == DrawMode.Mesh){
			display.DrawMesh(MeshGenerator.GenerateTerrainMesh(mapData.heightMap,meshHeightMultiplier,meshHeightCurve,editorPreviewLOD), TextureGenerator.TextureFromColourMap(mapData.colourMap, mapChunkSize, mapChunkSize));
		}
	}

	public void RequestMapData(Vector2 centre,Action<MapData> callback){
		ThreadStart threadStart = delegate{
			MapDataThread(centre,callback);
		};

		new Thread(threadStart).Start();
	}
	void MapDataThread(Vector2 centre,Action<MapData> callback){
		MapData mapData = GenerateMapData(centre);
		lock (mapDataThreadInfoQueue){
			mapDataThreadInfoQueue.Enqueue(new MapThreadInfo<MapData>(callback,mapData));
		}
	}

	public void RequestMeshData(MapData mapData,int lod ,Action<MeshData> callback) {
    ThreadStart threadStart = delegate {
        MeshDataThread(mapData,lod, callback);
    };
    new Thread(threadStart).Start();
	}

	void MeshDataThread(MapData mapData,int lod, Action<MeshData> callback){
		MeshData meshData = MeshGenerator.GenerateTerrainMesh(mapData.heightMap,meshHeightMultiplier,meshHeightCurve,lod);
		lock (meshDataThreadInfoQueue){
			meshDataThreadInfoQueue.Enqueue(new MapThreadInfo<MeshData>(callback,meshData));
		}
	}

	void Update(){
		if (mapDataThreadInfoQueue.Count > 0){
			for (int i = 0; i < mapDataThreadInfoQueue.Count; i++){
				MapThreadInfo<MapData> threadInfo = mapDataThreadInfoQueue.Dequeue();
				threadInfo.callback(threadInfo.parameter);
			}
		}
		if (meshDataThreadInfoQueue.Count > 0){
			for (int i = 0; i < meshDataThreadInfoQueue.Count; i++){
				MapThreadInfo<MeshData> threadInfo = meshDataThreadInfoQueue.Dequeue();
				threadInfo.callback(threadInfo.parameter);
			}
		}
	}
	MapData GenerateMapData(Vector2 centre) {
		float[,] noiseMap = Noise.GenerateNoiseMap (mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, centre + offset);

		Color[] colourMap = new Color[mapChunkSize * mapChunkSize];
		for (int y = 0; y < mapChunkSize; y++) {
			for (int x = 0; x < mapChunkSize; x++) {
				float currentHeight = noiseMap [x, y];
				for (int i = 0; i < regions.Length; i++) {
					if (currentHeight <= regions [i].height) {
						colourMap [y * mapChunkSize + x] = regions [i].colour;
						break;
					}
				}
			}
		}

		return new MapData(noiseMap,colourMap);
	}

	void OnValidate() {
		if (lacunarity < 1) {
			lacunarity = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}
        GenerateTerrains();
	}

	struct MapThreadInfo<T>{
		public readonly Action<T> callback;
		public readonly T parameter;
		public MapThreadInfo (Action<T> callback, T parameter){
			this.callback = callback;
			this.parameter = parameter;
		}
	}

    
    void GenerateTerrains()
        {
            

         //   regions[0] = new TerrainType("Shallow Water", 0f, new Color32(0x33, 0x61, 0xbf, 0xff)); // Blue
        	// regions[1] = new TerrainType("Light Beach", 0.3f, new Color32(0x38, 0x65, 0xbf, 0xff)); // Lighter Blue
            //regions[2] = new TerrainType("Beach", 0.40f, new Color32(0xd0, 0xd1, 0x80, 0xff)); // Sand color
            //regions[3] = new TerrainType("Grass", 0.55f, new Color32(0x58, 0x98, 0x18, 0xff)); // Green
            //regions[4] = new TerrainType("Forest", 0.6f, new Color32(0x3f, 0x6a, 0x12, 0xff)); // Dark Green
            //regions[5] = new TerrainType("Rock", 0.7f, new Color32(0x57, 0x40, 0x39, 0xff)); // Brown
            //regions[6] = new TerrainType("Mountain", 0.9f, new Color32(0x42, 0x34, 0x32, 0xff)); // Darker Brown
            //regions[7] = new TerrainType("Snow", 1.0f, Color.white); // White

            
        }
}



[System.Serializable]
public struct TerrainType {
	public string name;
	public float height;
	public Color colour;
    public TerrainType(string name, float height, Color colour)
        {
            this.name = name;
            this.height = height;
            this.colour = colour;
    }
}

public struct MapData{
	public readonly float[,] heightMap;
	public readonly Color[] colourMap;

	public MapData(float[,] heightMap,Color[] colourMap){
		this.heightMap = heightMap;
		this.colourMap = colourMap;
	}
}
