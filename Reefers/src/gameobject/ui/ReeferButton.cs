using CastleGame;
using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class ReeferButton : GameObject
{
    public Reefer Reefer { get; set; }

    public ReeferButton(Reefer reefer)
    {
        Reefer = reefer;
    }

    public override void Load()
    {
        Button button = new Button(new Vector2(28, 28));
        AddComponent(button);


        AnimationTree animationTree = CreateAndAddComponent<AnimationTree>();
        animationTree.AddAnimation(ReeferRegistry.GetPath(Reefer.Name + "_idle", AssetTypes.Animation), _ => true);


        button.OnClick += OnClick;

        base.Load();
    }

    public void OnClick()
    {
        User user = SceneManager.CurrentScene.GetGameObject<User>();
        UserStats userStats = user.GetComponent<UserStats>();

        if(userStats.SandDollars >= Reefer.SETTINGS.Price)
        {
            Buy();
            userStats.SandDollars -= Reefer.SETTINGS.Price;
        }
    }

    public void Buy()
    {

        SceneManager.CurrentScene.GetGameObject<User>().CurrentReefer = Reefer;
        SceneManager.CurrentScene.GetGameObject<User>().GetComponent<AnimationTree>().CurrentAnimation.SpriteSheet.CurrentSprite.ChangePath(ReeferRegistry.GetPath(Reefer.Name + "_idle", AssetTypes.Image));

    }

    public override void Update()
    {

        if (GetComponent<AnimationTree>().CurrentAnimation != null)
        {

            Sprite sprite = GetComponent<AnimationTree>().CurrentAnimation.SpriteSheet.CurrentSprite;
            User user = SceneManager.CurrentScene.GetGameObject<User>();
            UserStats userStats = user.GetComponent<UserStats>();

            int alphaModifier = 150;

            if (userStats.SandDollars < Reefer.SETTINGS.Price) sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, alphaModifier);
            else sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, 255f);

        }
        base.Update();

    }


}
