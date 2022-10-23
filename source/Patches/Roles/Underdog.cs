using TownOfUs.ImpostorRoles.UnderdogMod;

namespace TownOfUs.Roles
{
    public class Underdog : Role
    {
        public Underdog(PlayerControl player) : base(player)
        {
            Name = "潜伏者";
            ImpostorText = () => "伪装者的王牌";
            TaskText = () => PerformKill.LastImp() ? "你的击杀冷却时间大幅缩短!" : "在你的队友全部死亡前你的击杀冷却时间增加!";
            Color = Patches.Colors.Impostor;
            RoleType = RoleEnum.潜伏者;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }

        public float MaxTimer() => PerformKill.LastImp() ? PlayerControl.GameOptions.KillCooldown - CustomGameOptions.UnderdogKillBonus : (PerformKill.IncreasedKC() ? PlayerControl.GameOptions.KillCooldown : PlayerControl.GameOptions.KillCooldown + CustomGameOptions.UnderdogKillBonus);

        public void SetKillTimer()
        {
            Player.SetKillTimer(MaxTimer());
        }
    }
}
