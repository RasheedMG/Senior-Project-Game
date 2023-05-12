using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LlamAcademy.Guns.Demo
{
    [DisallowMultipleComponent]
    public class PlayerGunSelector : MonoBehaviour
    {
        public Camera Camera;
        [SerializeField]
        private GunType Gun;
        [SerializeField]
        private Transform GunParent;
        [SerializeField]
        private List<GunScriptableObject> Guns;
        
        [SerializeField]
        public List<GunScriptableObject> instancedGuns;

        private int index = 0;


        [Space]
        [Header("Runtime Filled")]
        public GunScriptableObject ActiveGun;

        public void EquipWeapon(GunScriptableObject gun)
        {

            if (gun == null)
            {
                Debug.LogError($"No GunScriptableObject found for GunType: {gun}");
                return;
            }
            if (ActiveGun != null)
            {
                ActiveGun.RecursiveMeshControl(false);
            }
            ActiveGun = gun;
            ActiveGun.RecursiveMeshControl(true);

        }

        public void OnSwitchWeapon(InputAction.CallbackContext context)
        {
            float input = context.ReadValue<float>();

            if (context.performed) 
            {
                if (input > 0)
                {

                    index++;
                    if (index > instancedGuns.Count - 1)
                        index = 0;
                }
                else if (input < 0)
                {
                    index--;
                    if (index < 0)
                        index = instancedGuns.Count - 1;
                }
                EquipWeapon(instancedGuns[index]);
            }
        

        }


    }
}
