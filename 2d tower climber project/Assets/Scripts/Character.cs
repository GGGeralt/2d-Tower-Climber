using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    #region Main Stats
    [Space]
    [Header("Main Stats")]
    [SerializeField] Stat Strength;
    [SerializeField] Stat Dexterity;
    [SerializeField] Stat Constitution;
    [SerializeField] Stat Mind;
    [SerializeField] Stat Soul;
    #endregion

    #region Sub Stats
    [Space]
    [Header("Sub Stats")]
    [SerializeField] public Stat Speed;
    #endregion

    #region Skills
    [Space]
    [Header("Skills")]
    [SerializeField] public MovementSkill movementSkill;
    [SerializeField] public AirSkill airSkill;
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
    }

}
