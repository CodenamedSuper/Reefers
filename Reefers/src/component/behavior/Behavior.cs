using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public abstract class Behavior : Component
{
    public string StateName { get; set; } = "";
    public Behavior() : base(false)
    {
    }

    public override void Initialize()
    {
        base.Initialize();

        if(GameObject.HasComponent<StateMachine>())
        {
            GetSibling<StateMachine>().AddState(new GameObjectState(StateName));
        }
    }

    public void ChangeState()
    {
        if (GetSibling<StateMachine>() != null)
        {
            StateMachine stateMachine = GetSibling<StateMachine>();
            stateMachine.SetState(StateName);
        }
    }
}
