using UnityEngine;

public class StructureBuilderComponent : MonoBehaviour
{
    public StructureCreator StructureCreator;
    public Vector3 SpawnPosition;

    public void SpawnStructure()
    {
        StructureCreator.SpawnStructure(SpawnPosition);
    }
}
