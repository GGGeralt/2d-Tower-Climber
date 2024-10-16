using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Attack/ManaBolt")]
public class ManaBolt : AttackSkill
{
    protected override void ActivateSkill(GameObject caster)
    {
        Debug.Log("MANABOLT LAUNCHED");
    }
    protected override void HoldActiveSkill(GameObject caster)
    {
        Debug.Log("MANABOLT IS LAUNCHING");
    }

    protected override void DeactivateSkill(GameObject caster)
    {
        Debug.Log("MANABOLT DELAUNCHED");
    }


}
