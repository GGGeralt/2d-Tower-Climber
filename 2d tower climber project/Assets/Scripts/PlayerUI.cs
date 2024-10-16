using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private Character character;

    [Header("Sliders")]
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Slider staminaSlider;
    [SerializeField] TextMeshProUGUI staminaText;

    [SerializeField] Slider manaSlider;
    [SerializeField] TextMeshProUGUI manaText;

    private void Start()
    {
        character = Character.Instance;

        healthSlider.maxValue = character.GetHealth().maxValue.Value;
        healthSlider.value = character.GetHealth().maxValue.Value;
        healthText.text = $"{character.GetHealth().currentValue}/{character.GetHealth().maxValue.Value}";

        staminaSlider.maxValue = character.GetStamina().maxValue.Value;
        staminaSlider.value = character.GetStamina().maxValue.Value;
        staminaText.text = $"{character.GetStamina().currentValue}/{character.GetStamina().maxValue.Value}";

        manaSlider.maxValue = character.GetMana().maxValue.Value;
        manaSlider.value = character.GetMana().maxValue.Value;
        manaText.text = $"{character.GetMana().currentValue}/{character.GetMana().maxValue.Value}";
    }
}
