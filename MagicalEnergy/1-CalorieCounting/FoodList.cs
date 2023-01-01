namespace _1_CalorieCounting;

public class FoodList : List<Food>
{
    public int TotalCalories => this.Sum(food => food.Calories);
}
