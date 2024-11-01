using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Attack/ManaBolt/ManaBolt")]
public class ManaBolt : AttackSkill
{
    [SerializeField] GameObject projectileGO;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float maxDistance;
    protected override void ActivateSkill(GameObject caster)
    {
        if (StatCheck())
        {
            Vector2 direction = (Vector2)((Camera.main.ScreenToWorldPoint(Input.mousePosition) - Character.Instance.transform.position)).normalized;

            GameObject projectile = Instantiate(projectileGO, (Vector2)Character.Instance.gameObject.transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().Damage = damage;
            projectile.GetComponent<Projectile>().MaxDistance = maxDistance;
            projectile.GetComponent<Rigidbody2D>().AddForce(speed * direction, ForceMode2D.Impulse);
            Character.Instance.DecreaseStatValue(cost);
        }
    }
    protected override void HoldActiveSkill(GameObject caster)
    {
    }

    protected override void DeactivateSkill(GameObject caster)
    {
    }
}
