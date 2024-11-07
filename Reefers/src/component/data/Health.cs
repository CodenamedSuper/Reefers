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
    public float MaxPoints { get; set; } = 0;
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

    public void Decrement(float amount)
    {
        Points -= amount;

        if (Points <= 0) OnHealthEmptied.Invoke();
    }

    public void Increment()
    {
        Increment(1);
    }
    public void Increment(float amount)
    {
        Points += amount;
    }

    public void SetFull()
    {
        Points = MaxPoints;
    }

    public bool IsEmpty()
    {
        return Points <= 0;
    }

    public void Die()
    {

        if(GameObject is Reefer)
        {
            Reef reef = SceneManager.CurrentScene.GetGameObject<Reef>();

            Vector2 coords = reef.ReefersTileGrid.ConvertWorldCoordinatesToGridCoordinates(GameObject.Position);
            reef.ReefersTileGrid.RemoveTile(coords);
        }
    }
}
