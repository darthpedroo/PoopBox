using UnityEngine;

public static class ObjectInstantiator
{
    public static GameObject InstantiatePrefab(string resourcePath, Vector3 position, Quaternion rotation)
    {

        return (GameObject)Object.Instantiate(Resources.Load(resourcePath), position, rotation);
    }
}
