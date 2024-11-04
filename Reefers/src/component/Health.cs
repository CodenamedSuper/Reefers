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
    public float MaxSize { get; set; } = 0;
    public Health(float size) : base(false)
    {
        MaxSize = size;
        Points = MaxSize;
    }


    public void Decrement()
    {
        Points--;

        if (Points <= 0) OnHealthEmptied.Invoke();
    }

    public void Decrement(float amount)
    {
        Points -= amount;

        if (Points <= 0) OnHealthEmptied.Invoke();
    }

    public void Increment()
    {
        Points++;
    }
    public void Increment(float amount)
    {
        Points += amount;
    }

    public void SetFull()
    {
        Points = MaxSize;
    }

    public bool IsEmpty()
    {
        return Points <= 0;
    }
}
