using System.Collections.Generic;
using UnityEngine;

public class EntityBuilder
{
    private readonly List<System.Action<GameObject>> _modifications = new();
    private readonly List<GameObject> _entityPrefab;

    public EntityBuilder(List<GameObject> prefab)
    {
        _entityPrefab = prefab;
        _modifications.Add(entity =>
        {
            EntityStateManager stateManager = entity.AddComponent<EntityStateManager>();
        });
    }
    public EntityBuilder AddDropTable(DropTable drops)
    {
        _modifications.Add(entity => entity.GetComponent<EntityStateManager>().SetDropTable(drops));
        return this;
    }
    public EntityBuilder AddChopable()
    {
        _modifications.Add(entity => entity.AddComponent<ChopChop>());
        return this;
    }
    public EntityBuilder SetSpeed(float newSpeed){
        _modifications.Add(entity => entity.GetComponent<EntityStateManager>().Speed = newSpeed);
        return this;
    }
    public Entity GetEntity()
    {
        return new Entity(_modifications, _entityPrefab);
    }
}
