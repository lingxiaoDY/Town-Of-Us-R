using HarmonyLib;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.ImpostorRoles.UnderdogMod
{
    [HarmonyPatch(typeof(ExileController), nameof(ExileController.WrapUp))]
    public static class HUDClose
    {
        public static void Postfix()
        {
            var role = Role.GetRole(PlayerControl.LocalPlayer);
            if (role?.RoleType == RoleEnum.潜伏者)
                ((Underdog)role).SetKillTimer();
        }
    }
}
