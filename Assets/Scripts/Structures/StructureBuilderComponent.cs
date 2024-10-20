using UnityEngine;

public class StructureBuilderComponent : MonoBehaviour
{
    public StructureData StructureCreator;
    public Vector3 SpawnPosition;

    void Start(){
        SpawnStructure();
    }
    public void SpawnStructure()
    {
        StructureCreator.SpawnStructure(SpawnPosition);
    }
}
