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
        [SerializeField] private bool AutoReload = false;
        //[SerializeField] private PlayerIK InverseKinematics;
        //[SerializeField] private Animator PlayerAnimator;
        //[SerializeField] private Image Crosshair;
        //private bool IsReloading;

        private void Update()
        {
            GunSelector.ActiveGun.Tick(
                Application.isFocused && Mouse.current.leftButton.isPressed
                && GunSelector.ActiveGun != null
            );

       

            //UpdateCrosshair();
        }

        /*
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

                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
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
                }
            }
        }
        */
    }
}