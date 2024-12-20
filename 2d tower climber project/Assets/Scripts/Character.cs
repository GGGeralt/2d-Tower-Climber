using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    #region Main Bar Stats
    [Space]
    [Header("Changeable Stats")]
    [SerializeField] ChangeableStat health = new ChangeableStat(100);
    [SerializeField] ChangeableStat stamina = new ChangeableStat(100);
    [SerializeField] ChangeableStat mana = new ChangeableStat(100);
    #endregion
    /*
    #region Main Stats
    [Space]
    [Header("Main Stats")]
    [SerializeField] Stat Strength;
    [SerializeField] Stat Dexterity;
    [SerializeField] Stat Constitution;
    [SerializeField] Stat Mind;
    [SerializeField] Stat Soul;
    #endregion
    */
    #region Sub Stats
    [Space]
    [Header("Sub Stats")]
    [SerializeField] Stat speed;
    [SerializeField] Stat healthRegen;
    [SerializeField] Stat staminaRegen;
    [SerializeField] Stat manaRegen;
    #endregion

    #region Skills
    [Space]
    [Header("Skills")]
    [SerializeField] AttackSkill attackSkill;
    [SerializeField] MovementSkill movementSkill;
    [SerializeField] AirSkill airSkill;
    #endregion


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        health.currentValue = health.maxValue.Value;
        stamina.currentValue = stamina.maxValue.Value;
        mana.currentValue = mana.maxValue.Value;
    }

    private void Update()
    {
        if (health.isRegenerating)
        {
            health.Increase(healthRegen.Value * Time.deltaTime);
        }
        if (stamina.isRegenerating)
        {
            stamina.Increase(staminaRegen.Value * Time.deltaTime);
        }
        if (mana.isRegenerating)
        {
            mana.Increase(manaRegen.Value * Time.deltaTime);
        }
    }
    public void DecreaseStatValue(SkillCost cost)
    {
        float value = cost.value;
        if (cost.inTime == true)
        {
            value *= Time.deltaTime;
        }
        switch (cost.stat)
        {
            case StatEnum.Health:
                health.Decrease(value);
                break;
            case StatEnum.Stamina:
                stamina.Decrease(value);
                break;
            case StatEnum.Mana:
                mana.Decrease(value);
                break;
        }
    }

    #region get
    public Stat GetSpeed()
    {
        return speed;
    }

    public AttackSkill GetAttackSkill()
    {
        return attackSkill;
    }

    public MovementSkill GetMovementSkill()
    {
        return movementSkill;
    }

    public AirSkill GetAirSkill()
    {
        return airSkill;
    }

    public ChangeableStat GetHealth()
    {
        return health;
    }
    public ChangeableStat GetStamina()
    {
        return stamina;
    }
    public ChangeableStat GetMana()
    {
        return mana;
    }


    #endregion
}
