using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace LlamAcademy.Guns.Demo
{
    [DisallowMultipleComponent]
    public class PlayerAction : MonoBehaviour
    {
        // public for editor
        public PlayerGunSelector GunSelector;
        [SerializeField]
        private bool AutoReload = false;
/*        [SerializeField]
        private PlayerIK InverseKinematics;
        [SerializeField]
        private Animator PlayerAnimator;
        [SerializeField]
        private Image Crosshair;*/
        private bool IsReloading;
        public bool wantsToShoot = false;

        private void Update()
        {
            GunSelector.ActiveGun.Tick(
                !IsReloading
                && wantsToShoot
                && GunSelector.ActiveGun != null
            );

            if (ShouldManualReload() || ShouldAutoReload())
            {
                GunSelector.ActiveGun.StartReloading();
                IsReloading = true;
/*                PlayerAnimator.SetTrigger("Reload");
                InverseKinematics.HandIKAmount = 0.25f;
                InverseKinematics.ElbowIKAmount = 0.25f;*/
            }

            UpdateCrosshair();
        }

        private void UpdateCrosshair()
        {
            if (GunSelector.ActiveGun.ShootConfig.ShootType == ShootType.FromGun)
            {
                Vector3 gunTipPoint = GunSelector.ActiveGun.GetRaycastOrigin();
                Vector3 forward = GunSelector.ActiveGun.GetGunForward();

                Vector3 hitPoint = gunTipPoint + forward * 10;
                if (Physics.Raycast(gunTipPoint, forward, out RaycastHit hit, float.MaxValue, GunSelector.ActiveGun.ShootConfig.HitMask))
                {
                    hitPoint = hit.point;
                }
                Vector3 screenSpaceLocation = GunSelector.Camera.WorldToScreenPoint(hitPoint);

/*                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    (RectTransform)Crosshair.transform.parent,
                    screenSpaceLocation,
                    null,
                    out Vector2 localPosition))
                {
                    Crosshair.rectTransform.anchoredPosition = localPosition;
                }
                else
                {
                    Crosshair.rectTransform.anchoredPosition = Vector2.zero;
                }*/
            }
        }

        private bool ShouldManualReload()
        {
            return !IsReloading
                && Keyboard.current.rKey.wasReleasedThisFrame
                && GunSelector.ActiveGun.CanReload();
        }

        private bool ShouldAutoReload()
        {
            return !IsReloading
                && AutoReload
                && GunSelector.ActiveGun.AmmoConfig.CurrentClipAmmo == 0
                && GunSelector.ActiveGun.CanReload();
        }

        private void EndReload()
        {
            GunSelector.ActiveGun.EndReload();
/*            InverseKinematics.HandIKAmount = 1f;
            InverseKinematics.ElbowIKAmount = 1f;
            IsReloading = false;*/
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                wantsToShoot = true;
            }
            else if (context.canceled)
            {
                wantsToShoot = false;
            }
        }
    }
}