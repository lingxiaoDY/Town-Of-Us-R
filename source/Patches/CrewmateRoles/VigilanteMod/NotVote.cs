using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.VigilanteMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))] // BBFDNCCEJHI
    public static class VotingComplete
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.侠客))
            {
                var retributionist = Role.GetRole<Vigilante>(PlayerControl.LocalPlayer);
                ShowHideButtonsVigi.HideButtonsVigi(retributionist);
            }
        }
    }
}