using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StructureBuilderComponent))]
public class StructureBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {

        StructureBuilderComponent builderComponent = (StructureBuilderComponent)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Get Structure"))
        {
            builderComponent.SpawnStructure();
        }
    }
}
