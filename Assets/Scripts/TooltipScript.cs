using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This script is for tooltip in inventoryUI (when u press tab)
public class TooltipScript : MonoBehaviour
{
    public static TooltipScript instance;
    private TextMeshProUGUI headerField;
    private TextMeshProUGUI statField;
    private TextMeshProUGUI descriptionField;

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        headerField = transform.Find("Header").GetComponent<TextMeshProUGUI>();
        statField = transform.Find("Stat").GetComponent<TextMeshProUGUI>();
        descriptionField = transform.Find("Description").GetComponent<TextMeshProUGUI>();

        gameObject.SetActive(false);
    }

    private void ShowTooltip(string tooltipName, string itemRarity, string tooltipDescription, string statString)
    {
        Cursor.visible = false;
        gameObject.SetActive(true);
        headerField.text = tooltipName + " \n " + itemRarity + " Предмет\n";
        statField.text = statString + "\n";
        if (tooltipDescription.Length != 0)
        {
            descriptionField.text = tooltipDescription;
        }
        else
        {
            descriptionField.text = "";
        }
    }

    public void HideTooltip()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Depend on item type, we will show different stat (damage, protection,..)
    /// </summary>
    /// <param name="item"></param>
    public void ShowTooltipPrep(ItemScript item)
    {
        if (item.type == ItemType.Armour)
        {
            ArmourScript armorItem = (ArmourScript)item;
            string statString = "Броня: " + armorItem.GetProtectionBonus().ToString("F2") + " %";
            ShowTooltip(item.itemName, item.itemRarity.ToString(), item.itemDescription, statString);
        }
        if (item.type == ItemType.Projectile)
        {
            ProjectileScript projectileItem = (ProjectileScript)item;
            string statString = "Урон: " + projectileItem.GetFinalDamage();
            //statString += "\nEnergy cost: " + projectileItem.GetEnergyCost();
            ShowTooltip(item.itemName, item.itemRarity.ToString(), item.itemDescription, statString);
        }
        if (item.type == ItemType.Weapon)
        {
            WeaponScript weaponItem = (WeaponScript)item;
            string statString = "Дополниетельный урон: " + weaponItem.GetDamageBonus();
            statString += "\nСкорость атаки: " + weaponItem.attackSpeed.ToString("F2");
            ShowTooltip(item.itemName, item.itemRarity.ToString(), item.itemDescription, statString);
        }
        if (item.type == ItemType.Consumable)
        {
            ConsumableScript consumableItem = (ConsumableScript)item;
            string statString = "Здоровье: " + consumableItem.GetHealValue();
            ShowTooltip(item.itemName, item.itemRarity.ToString(), item.itemDescription, statString);
        }
    }
}