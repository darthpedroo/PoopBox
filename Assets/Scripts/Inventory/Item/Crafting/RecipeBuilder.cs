using System.Collections.Generic;
public class RecipeBuilder 
{
    private readonly List<Item> _recipe;
    private Item _craftable;

    public RecipeBuilder(){
        _recipe = new();
    }
    public RecipeBuilder Add(Item item){
        _recipe.Add(item);
        return this;
    }
    public RecipeBuilder SetCraftableItem(Item item){
        _craftable = item;
        return this;
    }
    public Item Craft(){
        return _craftable;
    }
    public List<Item> Recipe(){
        return _recipe;
    }
}
