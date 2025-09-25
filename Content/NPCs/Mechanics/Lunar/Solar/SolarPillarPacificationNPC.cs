using System.IO;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace BossForgiveness.Content.NPCs.Mechanics.Lunar.Solar;

internal class SolarPillarPacificationNPC : GlobalNPC
{
    public const int MaxPacification = 15;

    public override bool InstancePerEntity => true;

    public bool Invalid = false;
    public int Count = 0;

    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.LunarTowerSolar;

    public override void SaveData(NPC npc, TagCompound tag)
    {
        tag.Add("invalid", Invalid);
        tag.Add("count", Count);
    }

    public override void LoadData(NPC npc, TagCompound tag)
    {
        Invalid = tag.GetBool("invalid");
        Count = tag.GetByte("count");
    }

    public override void SendExtraAI(NPC npc, BitWriter bitWriter, BinaryWriter binaryWriter)
    {
        bitWriter.WriteBit(Invalid);
        binaryWriter.Write((byte)Count);
    }

    public override void ReceiveExtraAI(NPC npc, BitReader bitReader, BinaryReader binaryReader)
    {
        Invalid = bitReader.ReadBit();
        Count = binaryReader.ReadByte();
    }
}
