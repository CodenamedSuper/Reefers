using CastleGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class User : GameObject
{
    public Reefer CurrentReefer { get; set; } = ReeferRegistry.Brain();

    public override void Load()
    {
        Layer = Level.Cursor.Layer;
        AnimationTree animationTree = CreateAndAddComponent<AnimationTree>();
        animationTree.AddAnimation(ReeferRegistry.GetPath(CurrentReefer.Name, AssetTypes.Animation), _ => true);

        Direction direction = CreateAndAddComponent<Direction>(); direction.Set(Direction.East().Facing);

        base.Load();    
    }

    public override void Update()
    {
        if(GetComponent<AnimationTree>().CurrentAnimation != null)
        GetComponent<AnimationTree>().CurrentAnimation.SpriteSheet.CurrentSprite.Color = new Color(0, 0, 0, 50);


        Position = VectorHelper.Snap(Level.Cursor.Position, 28);

        base.Update();
        if (Input.Mouse.LeftClick()) TryAndPlaceReefer();

    }

    public void TryAndPlaceReefer()
    {
        Reef reef = SceneManager.CurrentScene.GetGameObject<Reef>();
        Vector2 mousePos = VectorHelper.Snap(Level.Cursor.Position, 28);
        Vector2 mouseGridPos = reef.ReefersTileGrid.ConvertWorldCoordinatesToGridCoordinates(mousePos);

        if ((mouseGridPos.X >= 0 && mouseGridPos.Y >= 0 && mouseGridPos.X < reef.ReefSize.X && mouseGridPos.Y < reef.ReefSize.Y) && !reef.ReefersTileGrid.Tiles.ContainsKey(mouseGridPos))
        {
            reef.ReefersTileGrid.PlaceTile(mouseGridPos, CurrentReefer.Name);
            reef.ReefersTileGrid.Tiles[mouseGridPos].GetComponent<Direction>().Set(GetComponent<Direction>().Facing);
        }

    }


}
