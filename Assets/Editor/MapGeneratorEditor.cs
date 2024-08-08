using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }
        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}

[InitializeOnLoad]
public static class MapGeneratorInitializer
{
    static MapGeneratorInitializer()
    {
        EditorApplication.delayCall += OnEditorReload;
    }

    private static void OnEditorReload()
    {
        // Find the MapGenerator instance in the scene
        MapGenerator mapGen = GameObject.FindObjectOfType<MapGenerator>();
        mapGen?.GenerateMap();
    }
}
