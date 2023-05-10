using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<GunScriptableObject> instancedGuns;

/*        [SerializeField]
        private PlayerIK InverseKinematics;*/

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
                instancedGuns.Add(instantatedGun);
                instantatedGun.Spawn(GunParent, this, Camera);
                instantatedGun.RecursiveMeshControl(false);
            }
        }

 /*       private void RecursiveMeshControl(GunScriptableObject instantatedGun, bool enable)
        {
            var meshrenderersgun = instantatedGun.ModelPrefab.GetComponentsInChildren<Renderer>();
            foreach (var mesh in meshrenderersgun)
            {
                
                mesh.enabled = enable;
            }
        }*/

        private void IKMagic()
        {
            // some magic for IK
            Transform[] allChildren = GunParent.GetComponentsInChildren<Transform>();
/*            InverseKinematics.LeftElbowIKTarget = allChildren.FirstOrDefault(child => child.name == "LeftElbow");
            InverseKinematics.RightElbowIKTarget = allChildren.FirstOrDefault(child => child.name == "RightElbow");
            InverseKinematics.LeftHandIKTarget = allChildren.FirstOrDefault(child => child.name == "LeftHand");
            InverseKinematics.RightHandIKTarget = allChildren.FirstOrDefault(child => child.name == "RightHand");*/
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

            // ActiveGun = gun.Clone() as GunScriptableObject;
            //Spawn(GunParent, this, Camera);
        }

        private void Update()
        {
              if (Keyboard.current.tKey.wasReleasedThisFrame)
              {
                    EquipWeapon(instancedGuns[1]);

              }
            if (Keyboard.current.yKey.wasReleasedThisFrame)
            {
                EquipWeapon(instancedGuns[0]);

            }
        }


    }
}
