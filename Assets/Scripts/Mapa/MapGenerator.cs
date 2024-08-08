using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public enum DrawMode {NoiseMap, ColourMap,Mesh};
	public DrawMode drawMode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public bool autoUpdate;

	public TerrainType[] regions;

	public void GenerateMap() {
		float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

		Color[] colourMap = new Color[mapWidth * mapHeight];
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				float currentHeight = noiseMap [x, y];
				for (int i = 0; i < regions.Length; i++) {
					if (currentHeight <= regions [i].height) {
						colourMap [y * mapWidth + x] = regions [i].colour;
						break;
					}
				}
			}
		}

		MapDisplay display = FindObjectOfType<MapDisplay> ();
		if (drawMode == DrawMode.NoiseMap) {
			display.DrawTexture (TextureGenerator.TextureFromHeightMap(noiseMap));
		} else if (drawMode == DrawMode.ColourMap) {
			display.DrawTexture (TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
		} else if (drawMode == DrawMode.Mesh){
			display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap), TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
		}
	}

	void OnValidate() {
		if (mapWidth < 1) {
			mapWidth = 1;
		}
		if (mapHeight < 1) {
			mapHeight = 1;
		}
		if (lacunarity < 1) {
			lacunarity = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}
        GenerateTerrains();
	}

    void Start(){
        GenerateMap();
        
    }
    void GenerateTerrains()
        {
            

            regions[0] = new TerrainType("Shallow Water", 0.2f, new Color32(0x33, 0x61, 0xbf, 0xff)); // Blue
            regions[1] = new TerrainType("Light Beach", 0.3f, new Color32(0x38, 0x65, 0xbf, 0xff)); // Lighter Blue
            regions[2] = new TerrainType("Beach", 0.40f, new Color32(0xd0, 0xd1, 0x80, 0xff)); // Sand color
            regions[3] = new TerrainType("Grass", 0.55f, new Color32(0x58, 0x98, 0x18, 0xff)); // Green
            regions[4] = new TerrainType("Forest", 0.6f, new Color32(0x3f, 0x6a, 0x12, 0xff)); // Dark Green
            regions[5] = new TerrainType("Rock", 0.7f, new Color32(0x57, 0x40, 0x39, 0xff)); // Brown
            regions[6] = new TerrainType("Mountain", 0.9f, new Color32(0x42, 0x34, 0x32, 0xff)); // Darker Brown
            regions[7] = new TerrainType("Snow", 1.0f, Color.white); // White

            
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
