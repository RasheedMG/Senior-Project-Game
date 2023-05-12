using LlamAcademy.Guns.Modifiers;
using UnityEngine;



namespace LlamAcademy.Guns.Demo
{
    public class GunModifierApplier : MonoBehaviour
    {
        [SerializeField]
        private PlayerGunSelector GunSelector;
        [SerializeField] float damage = 10f;

        private void Start()
        {
            UpdateDamageModifier();

            UpdateSpreedModifier();
        }

        private void UpdateSpreedModifier()
        {
            Vector3Modifier spreadModifier = new()
            {
                Amount = new Vector3(1.2f, 1.2f, 1.2f),
                AttributeName = "ShootConfig/Spread"
            };
            spreadModifier.Apply(GunSelector.ActiveGun);
        }

        private void UpdateDamageModifier()
        {
            DamageModifier damageModifier = new()
            {
                Amount = 1.5f,
                AttributeName = "DamageConfig/DamageCurve"
            };
            damageModifier.Apply(GunSelector.ActiveGun);
        }
    }
}