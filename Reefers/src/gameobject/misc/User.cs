using CastleGame;
using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class User : GameObject
{

    private List<Reefer> reefers = new List<Reefer>();

    public Reefer CurrentReefer { get; set; }

    public User()
    {
        foreach (KeyValuePair<string, Func<Reefer>> reeferEntry in ReeferRegistry.List)
        {
            reefers.Add(reeferEntry.Value());
        }
        CurrentReefer = reefers[0];
    }

    public override void Load()
    {
        base.Load();    
    }

    public override void Update()
    {
        base.Update();
        if (Input.Mouse.LeftClick()) TryAndPlaceReefer();
        if (Input.Mouse.RightClick()) CycleReefer();

    }

    public void TryAndPlaceReefer()
    {
        Reef reef = SceneManager.CurrentScene.GetGameObject<Reef>();
        Vector2 mousePos = Level.cursor.Position;
        Vector2 mouseGridPos = reef.ReefersTileGrid.ConvertWorldCoordinatesToGridCoordinates(mousePos);

        DebugGui.Log(mouseGridPos.ToString());

        if (mouseGridPos.X >= 0 && mouseGridPos.Y >= 0 && mouseGridPos.X < reef.ReefSize.X && mouseGridPos.Y < reef.ReefSize.Y)
        {
            reef.ReefersTileGrid.PlaceTile(mouseGridPos, CurrentReefer.Name);
        }

    }

    public void CycleReefer()
    {
        if (reefers.IndexOf(CurrentReefer) >= reefers.Count - 1) CurrentReefer = reefers[0];
        else
        CurrentReefer = reefers[reefers.IndexOf(CurrentReefer) + 1];
    }

}
