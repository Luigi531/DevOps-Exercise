using System.Collections.Generic;

namespace GildedRoseKata;

public class RefactorTest
{
    IList<Item> Items;

    public RefactorTest(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            switch (Items[i].Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    break;
                case "Aged Brie":
                    UpdateBrie(Items[i]);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdatePass(Items[i]);
                    break;
                case "Conjured Mana Cake":
                    UpdateConjured(Items[i]);
                    break;
                default:
                    UpdateBrie(Items[i]);
                    break;
            }
        }
    }
    
    //This method implements the base logic for items handling
    private void BaseItemUpdate(Item item)
    {
        //If the quality of an item was to be negative at the next increment, do not execute the logic
        if (item.Quality > 0)
        {
            //If the Sell Date has passed the quality is reduced by 2, otherwise it's reduce by one at the end of the day
            item.Quality = item.SellIn < 0 ? item.Quality -= 2 : item.Quality--;
        }
    }
    
    //This method Updates the Brie Specifically.
    //The Brie Increments in Quality each day until it reaches fifty
    private void UpdateBrie(Item item)
    {
        if (item.Quality <= 50) item.Quality++;
    }
    
    //This method Update the concert passes Specifically
    //If the quality is not yet maxed out, the method checks the time left before the concert and updates it's quality according to it
    private void UpdatePass(Item item)
    {
        if (item.Quality <= 50)
        {
            switch (item.SellIn)
            {
                case var _ when (item.SellIn <= 10 && item.SellIn > 5):
                    item.Quality += 2;
                    break;
                case var _ when (item.SellIn <= 5):
                    item.Quality += 3;
                    break;
                default:
                    item.Quality++;
                    break;
            }
        }
    }
    
    //This method handles the conjured items behaviour
    private void UpdateConjured(Item item)
    {
        if (item.Quality > 0)
        {
            //If the Sell Date has passed the quality is reduced by 2, otherwise it's reduce by one at the end of the day
            item.Quality = item.SellIn < 0 ? item.Quality -= 4 : item.Quality -= 2;
        }
    }
}