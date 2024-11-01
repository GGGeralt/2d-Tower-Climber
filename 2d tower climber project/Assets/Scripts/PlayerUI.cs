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
        staminaSlider.maxValue = character.GetStamina().maxValue.Value;
        manaSlider.maxValue = character.GetMana().maxValue.Value;


        character.GetHealth().OnValueChanged.AddListener(UpdateBars);
        character.GetStamina().OnValueChanged.AddListener(UpdateBars);
        character.GetMana().OnValueChanged.AddListener(UpdateBars);
    }

    private void UpdateBars()
    {
        healthSlider.value = character.GetHealth().currentValue;
        staminaSlider.value = character.GetStamina().currentValue;
        manaSlider.value = character.GetMana().currentValue;

        healthText.text = $"{Mathf.Round(character.GetHealth().currentValue)}/{character.GetHealth().maxValue.Value}";
        staminaText.text = $"{Mathf.Round(character.GetStamina().currentValue)}/{character.GetStamina().maxValue.Value}";
        manaText.text = $"{Mathf.Round(character.GetMana().currentValue)}/{character.GetMana().maxValue.Value}";

    }
}
