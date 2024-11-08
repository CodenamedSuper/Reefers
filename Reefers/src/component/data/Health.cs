using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public delegate void HealthEmptyEvent();

public class Health : Component
{
    public event HealthEmptyEvent OnHealthEmptied;
    public float Points { get; set; } = 0;
    // The current amount of the health.
    public float MaxPoints { get; set; } = 0;
    // The maximum amount of the health
    public Health(float size) : base(false)
    {
        MaxPoints = size;
        Points = MaxPoints;

        OnHealthEmptied += Die;
    }


    public void Decrement()
    {
        Decrement(1);
    }
    //Decrements the health by 1.

    public void Decrement(float amount)
    {
        Points -= amount;

        if (IsEmpty()) OnHealthEmptied.Invoke();
    }
    //Decrements the health by a specified amount.
    public void Increment()
    {
        Increment(1);
    }
    //Increments the health by 1

    public void Increment(float amount)
    {
        Points += amount;
    }
    //Increments the health by a specified amount.


    public void SetFull()
    {
        Points = MaxPoints;
    }
    //Fills up the health to It's maximum amount.

    public bool IsEmpty()
    {
        return Points <= 0;
    }
    //Checks if the current health amount is below or equals to 0.

    public void Die()
    {

        if(GameObject is Reefer)
        {
            Reef reef = SceneManager.CurrentScene.GetGameObject<Reef>();

            Vector2 coords = reef.ReefersTileGrid.ConvertWorldCoordinatesToGridCoordinates(GameObject.Position);
            reef.ReefersTileGrid.RemoveTile(coords);
        }

        GameObject.Remove();
    }
    // Kills the parent GameObject.
}
