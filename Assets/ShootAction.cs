using SGoap;
using UnityEngine;

// Every SGoap Action inherits from either BasicAction or Action
public class ShootAction : BasicAction
{
    public override float CooldownTime => 1;

    public override EActionStatus Perform()
    {
        var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.localScale = Vector3.one * 0.2f;
        bullet.transform.position = AgentData.Position;
        bullet.transform.GoTo(AgentData.Target.position, 1);

        Destroy(bullet.gameObject, 1.2f);

        return EActionStatus.Success;
    }
}