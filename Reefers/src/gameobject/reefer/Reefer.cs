using CastleGame;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Reefer : Tile
{

    public Settings SETTINGS;
    public Reefer(string name, Settings settings) : base(name)
    {
        SETTINGS = new Settings();
    }

    public override void Load()
    {

        Sprite sprite = new Sprite(ReeferRegistry.GetPath(AssetTypes.Image, Name));

        base.Load();
    }

    public class Settings
    {
       
    }
}
