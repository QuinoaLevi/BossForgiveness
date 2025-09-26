using BossForgiveness.Content.NPCs.Mechanics.Lunar.Solar;
using NetEasy;
using System;
using Terraria.ID;

namespace BossForgiveness.Content.Systems.Syncing;

[Serializable]
public class SyncSolarPacifyModule(byte npcWho, bool fail) : Module
{
    protected override void Receive()
    {
        NPC npc = Main.npc[npcWho];

        if (!fail)
            SolarPlayer.Pacify(npc, true);
        else if (Main.netMode != NetmodeID.MultiplayerClient)
            SolarPlayer.UpdateNearbySolarPillar(true, npc);

        if (Main.dedServ)
            Send(-1, -1, false);
    }
}
