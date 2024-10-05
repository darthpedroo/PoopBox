using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntityBuilderComponent))]
public class EntityBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {

        EntityBuilderComponent builderComponent = (EntityBuilderComponent)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Spawn Entity"))
        {
            builderComponent.SpawnEntity();
        }
    }
}
