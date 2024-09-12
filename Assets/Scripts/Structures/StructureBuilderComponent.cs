using UnityEngine;

public class StructureBuilderComponent : MonoBehaviour
{
    public StructureCreator StructureCreator;
    public Vector3 Pos;
    public Vector3 Scale;
    public void SpawnStructure()
    {
        StructureCreator.SpawnStructure(Pos,Scale);
    }
}
