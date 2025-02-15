using Terraria;
using Terraria.ModLoader;

namespace threeDS.Content.Buffs
{
    public class Stunned : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; // Makes it so the buff can't be canceled
            Main.pvpBuff[Type] = true; // Players can give other players the buff in PvP
            Main.buffNoSave[Type] = true; // Doesn't save when you exit the world
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity *= 0f; // Stops the NPC from moving
        }
    }
}