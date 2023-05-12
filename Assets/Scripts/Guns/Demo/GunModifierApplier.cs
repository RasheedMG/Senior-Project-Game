using LlamAcademy.Guns.Modifiers;
using UnityEngine;



namespace LlamAcademy.Guns.Demo
{
    public class GunModifierApplier : MonoBehaviour
    {
        [SerializeField]
        private PlayerGunSelector GunSelector;
        [SerializeField] float damageMod = 1.2f;
        [SerializeField] float spreadMod = 1f;

        private void Start()
        {
            UpdateDamageModifier(damageMod);

            UpdateSpreadModifier(spreadMod);



        }

        private void UpdateSpreadModifier(float spreadMod)
        {
            Vector3Modifier spreadModifier = new()
            {
                Amount = new Vector3(spreadMod, spreadMod, spreadMod),
                AttributeName = "ShootConfig/Spread"
            };
            foreach (GunScriptableObject gun in GunSelector.instancedGuns)
            {
                spreadModifier.Apply(gun);
            }
        }

        private void UpdateDamageModifier(float damageMod)
        {
            DamageModifier damageModifier = new()
            {
                Amount = damageMod,
                AttributeName = "DamageConfig/DamageCurve"
            };
            foreach(GunScriptableObject gun in GunSelector.instancedGuns)
            {
                damageModifier.Apply(gun);
            }
            
        }
    }
}