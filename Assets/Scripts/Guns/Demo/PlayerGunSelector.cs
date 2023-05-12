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


        [Space]
        [Header("Runtime Filled")]
        public GunScriptableObject ActiveGun;
        
        private void Awake()
        {
           GunScriptableObject gun = Guns.Find(gun => gun.Type == Gun);

            IKMagic();
            InitilizeGuns();

            EquipWeapon(instancedGuns[0]);
        }

        private void InitilizeGuns()
        {
            foreach (GunScriptableObject gun in Guns)
            {
                var instantatedGun = gun.Clone() as GunScriptableObject;
                //instantatedGun.AmmoConfig.CurrentClipAmmo = PlayerDataManager.currentProf.getWeapon(instantatedGun.Name).currentAmmo;
                instancedGuns.Add(instantatedGun);
                instantatedGun.Spawn(GunParent, this, Camera);
                instantatedGun.RecursiveMeshControl(false);
            }
        }

        private void IKMagic()
        {
            Transform[] allChildren = GunParent.GetComponentsInChildren<Transform>();

        }

        private void EquipWeapon(GunScriptableObject gun)
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

        private void Update()
        {
              if (Keyboard.current.digit1Key.wasReleasedThisFrame)
              {
                    EquipWeapon(instancedGuns[0]);

              }
             if (Keyboard.current.digit2Key.wasReleasedThisFrame)
                {
                EquipWeapon(instancedGuns[1]);

                }
            if (Keyboard.current.digit3Key.wasReleasedThisFrame)
            {
                EquipWeapon(instancedGuns[2]);

            }
            if (Keyboard.current.digit4Key.wasReleasedThisFrame)
            {
                EquipWeapon(instancedGuns[3]);

            }
            if (Keyboard.current.digit5Key.wasReleasedThisFrame)
            {
                EquipWeapon(instancedGuns[4]);

            }
        }


    }
}
