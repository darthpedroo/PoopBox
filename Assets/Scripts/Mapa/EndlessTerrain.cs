using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    const float scale = 5f;
    const float viewerMoveThresholdForChunkUpdate = 25f;
    const float sqrViewerMoveThresholdForChunkUpdate = viewerMoveThresholdForChunkUpdate*viewerMoveThresholdForChunkUpdate;
    public LODInfo[] detailsLevels;
    public static float maxViewDist = 450;
    public Transform viewer;
    public Material mapMaterial;
    public static Vector2 viewerPosition;
    Vector2 viewerPositionOld;
    static MapGenerator mapGenerator;
    int chunkSize;
    int chunkVisibleInViewDst;
    Dictionary<Vector2,TerrainChunk> TerrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    static List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>(); // Array to store tree prefabs
    public static int maxTreesPerChunk = 200; // Max number of trees per chunk

    void Start(){
        mapGenerator = FindObjectOfType<MapGenerator>(); 
        maxViewDist = detailsLevels[detailsLevels.Length -1].visibleDstThreshold;
        chunkSize = MapGenerator.mapChunkSize -1 ;
        chunkVisibleInViewDst = Mathf.RoundToInt(maxViewDist /chunkSize);
        UpdateVisibleChunks();
        
    }

    void Update(){
        viewerPosition = new Vector2(viewer.position.x,viewer.position.z) / scale;
        if ((viewerPositionOld-viewerPosition).sqrMagnitude > sqrViewerMoveThresholdForChunkUpdate){
            viewerPositionOld = viewerPosition;
            UpdateVisibleChunks();
        }
        
    }
    void UpdateVisibleChunks(){

        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++){
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunksVisibleLastUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunkSize); 
        for (int yOffset = -chunkVisibleInViewDst; yOffset <= chunkVisibleInViewDst; yOffset++){
            for (int xOffset = -chunkVisibleInViewDst; xOffset <= chunkVisibleInViewDst; xOffset++){
                Vector2 viewedChunkCoord = new Vector2 (currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (TerrainChunkDictionary.ContainsKey(viewedChunkCoord)){
                    TerrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
                    
                }else {
                    TerrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord,chunkSize,detailsLevels,transform,mapMaterial));
                }
            }
        };
    }
    public class TerrainChunk {
        GameObject meshObject;
        Vector2 position;
        Bounds bounds;
        MeshRenderer meshRenderer;
        MeshFilter meshFilter;
        MeshCollider meshCollider;
        LODInfo[] detailLevels;
        LODMesh[] lodMeshes;
        MapData mapData;
        bool mapDataReceived;
        int previousLODIndex = -1;
        int chunkSize;
        public TerrainChunk(Vector2 coord, int size,LODInfo[] detailLevels ,Transform parent, Material material){
            this.detailLevels = detailLevels;
            position = coord * size;
            bounds = new Bounds(position,Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x,0,position.y);
            meshObject = new GameObject("Terrain Chunk " + coord.ToString());
            meshObject.layer =  6;
            meshRenderer = meshObject.AddComponent<MeshRenderer>();
            meshFilter = meshObject.AddComponent<MeshFilter>();
            meshCollider = meshObject.AddComponent<MeshCollider>();
            meshRenderer.material = material;
            meshObject.transform.position = positionV3 * scale;
            meshObject.transform.localScale = Vector3.one * scale;
            meshObject.transform.parent = parent;
            chunkSize = size;
            SetVisible(false);
            lodMeshes = new LODMesh[detailLevels.Length];
            for (int i = 0; i < detailLevels.Length; i++){
                lodMeshes[i] = new LODMesh(detailLevels[i].lod,UpdateTerrainChunk);
            }
            mapGenerator.RequestMapData(position,OnMapDataReceived);
        }

        void OnMapDataReceived(MapData mapData){
           this.mapData = mapData;
           mapDataReceived = true;
           Texture2D texture = TextureGenerator.TextureFromColourMap(mapData.colourMap,MapGenerator.mapChunkSize,MapGenerator.mapChunkSize);
           meshRenderer.material.mainTexture = texture;
           UpdateTerrainChunk();
           
        }
    
        public void PlaceTrees(Vector2 position, MapData mapData, Transform parent) {
            int treeCount = UnityEngine.Random.Range(5, maxTreesPerChunk);
            StructureCreator structureCreator = Resources.Load<StructureCreator>("Structures/Tree");
        
            float rayHeight = 1000f; 
           
            for (int i = 0; i < treeCount; i++) {
                // chatgpt me puede comer la verga
                int randomX = UnityEngine.Random.Range(0, chunkSize);
                int randomZ = UnityEngine.Random.Range(0, chunkSize);

                float height = mapData.heightMap[randomX,randomZ];
                
                if (height < 0.05f || height > 0.7f){
                    continue;
                }
                Vector3 rayStart = new Vector3(((position.x) - (chunkSize /2) + randomX) * scale,  rayHeight,  ((position.y) - (chunkSize/2) + randomZ) * scale);
                
                
                RaycastHit hit;
                
                if (Physics.Raycast(rayStart, Vector3.down, out hit, rayHeight, LayerMask.GetMask("Ground"))) {
                    structureCreator.SpawnStructure(hit.point, Vector3.one * 3);
                    
                    
                } 
            }
        }




        
        public void UpdateTerrainChunk() {
            if (mapDataReceived){
                float viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPosition));
                bool visible = viewerDstFromNearestEdge <= maxViewDist;
                if (visible){
                    int lodIndex = 0;
                    for (int i = 0; i < detailLevels.Length -1; i++){
                        if (viewerDstFromNearestEdge > detailLevels[i].visibleDstThreshold){
                            lodIndex = i+1;
                        } else{
                            break;
                        }
                    }
                    if (lodIndex != previousLODIndex){
                        LODMesh lodMesh = lodMeshes[lodIndex];
                        if (lodMesh.hasMesh){
                            previousLODIndex = lodIndex;
                            meshFilter.mesh = lodMesh.mesh;
                            meshCollider.sharedMesh = lodMesh.mesh;
                            PlaceTrees(position,mapData,meshObject.transform);
                        }
                        else if (!lodMesh.hasRequestedMesh){
                            lodMesh.RequestMesh(mapData);
                        }
                    }
                    
                    terrainChunksVisibleLastUpdate.Add(this);
                    
                }
                SetVisible(visible);
            }
        }

        public void SetVisible(bool visible){
            meshObject.SetActive(visible);
        }

        public bool IsVisible(){
            return meshObject.activeSelf;
        }
    }
    class LODMesh{
        public Mesh mesh;
        public bool hasRequestedMesh;
        public bool hasMesh;
        int lod;
        System.Action updateCallBack;
        public LODMesh(int lod, System.Action updateCallBack){
            this.lod = lod;
            this.updateCallBack = updateCallBack;
        }
        void OnMeshDataReceived(MeshData meshData){
            mesh = meshData.CreateMesh();
            hasMesh = true;
            updateCallBack();
        }
        public void RequestMesh(MapData mapData){
            hasRequestedMesh = true;
            mapGenerator.RequestMeshData(mapData,lod, OnMeshDataReceived);
        }
    }
    [System.Serializable]
    public struct LODInfo{
        public int lod;
        public float visibleDstThreshold;
    }
}
