using System;
using System.Collections.Generic;

// Interface for all meal plans
public interface IMealPlan
{
    string MealName { get; }
    int Calories { get; }
    void DisplayMeal();
}

// Vegetarian Meal
public class VegetarianMeal : IMealPlan
{
    public string MealName { get; private set; }
    public int Calories { get; private set; }

    public VegetarianMeal(string name, int calories)
    {
        MealName = name;
        Calories = calories;
    }

    public void DisplayMeal()
    {
        Console.WriteLine($"Vegetarian Meal: {MealName}, Calories: {Calories}");
    }
}

// Vegan Meal
public class VeganMeal : IMealPlan
{
    public string MealName { get; private set; }
    public int Calories { get; private set; }

    public VeganMeal(string name, int calories)
    {
        MealName = name;
        Calories = calories;
    }

    public void DisplayMeal()
    {
        Console.WriteLine($"Vegan Meal: {MealName}, Calories: {Calories}");
    }
}

// Generic Meal Class
public class Meal<T>
    where T : IMealPlan
{
    private List<T> meals = new List<T>();

    public void AddMeal(T meal)
    {
        meals.Add(meal);
        Console.WriteLine($"{meal.MealName} added to plan");
    }

    public void DisplayMeals()
    {
        Console.WriteLine("\n--- Meal Plan ---");
        foreach (var meal in meals)
        {
            meal.DisplayMeal();
        }
    }
}

// Generic Utility Class
public static class MealGenerator
{
    // Generic Method
    public static void ValidateMeal<T>(T meal)
        where T : IMealPlan
    {
        if (meal.Calories < 100)
        {
            Console.WriteLine("Meal calories too low!");
        }
        else
        {
            Console.WriteLine("Meal validated successfully");
        }
    }
}

// Main Program
class MeanPlanSystem
{
    static void Main()
    {
        Meal<VegetarianMeal> vegPlan = new Meal<VegetarianMeal>();
        Meal<VeganMeal> veganPlan = new Meal<VeganMeal>();

        VegetarianMeal vegMeal = new VegetarianMeal("Paneer Bowl", 350);
        VeganMeal veganMeal = new VeganMeal("Quinoa Salad", 280);

        MealGenerator.ValidateMeal(vegMeal);
        MealGenerator.ValidateMeal(veganMeal);

        vegPlan.AddMeal(vegMeal);
        veganPlan.AddMeal(veganMeal);

        vegPlan.DisplayMeals();
        veganPlan.DisplayMeals();
    }
}
