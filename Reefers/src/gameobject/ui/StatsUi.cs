using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class StatsUi : GameObject
{
    public override void Load()
    {
        Position = new Vector2(2, 16);
        Text text = new Text("assets/font/peaberry", "sand dollars"); AddComponent(text);
        text.Scale = 0.8f;
        base.Load();
    }

    public override void Update()
    {
        UserStats userStats = SceneManager.CurrentScene.GetGameObject<User>().GetComponent<UserStats>();
        GetComponent<Text>().ChangeText(userStats.SandDollars.ToString() + " Sand Dollars");

        base.Update();
    }
}
