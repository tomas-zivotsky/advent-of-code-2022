namespace _1_CalorieCounting;

internal class FoodList : List<Food>
{
    public int TotalCalories => this.Sum(food => food.Calories);
}
