public interface IDurable 
{
    public int MaxDurability {get;}
    public int DurabilityOnUse {get;}
    public abstract UItemData Construct(); //Si se usa la interfaz retornar DurableItem
}
