using UnityEngine;

public class StructureBuilderComponent : MonoBehaviour
{
    public StructureCreator StructureCreator;
    public Vector3 Pos;
    public void SpawnStructure()
    {
        StructureCreator.SpawnStructure(Pos);
    }
}
