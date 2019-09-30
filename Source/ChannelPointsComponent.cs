using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TwitchToolkit;
using TwitchToolkit.IRC;
using TwitchToolkit.Store;
using Verse;

namespace Toolkit___ChannelPoints
{
    public class ChannelPointsComponent : TwitchInterfaceBase
    {
        public ChannelPointsComponent(Game game) { }

        public override void ParseCommand(IRCMessage msg)
        {
            if (msg.Parameters.ContainsKey("custom-reward-id"))
            {
                string rewardId = msg.Parameters["custom-reward-id"];
                if (rewardId == ChannelPoints_Settings.RewardUUID)
                {
                    ChannelPoints.AwardCoinsToUser(msg.User);
                }
                else
                {
                    if (ChannelPoints_Settings.ShowDebugMessages)
                    {
                        Log.Message($"Detected a custom reward that wasn't configured: {rewardId}");
                    }

                    if (ChannelPoints_Settings.AutomaticRewardUUIDCapture)
                    {
                        if (ChannelPoints_Settings.ShowDebugMessages)
                        {
                            Log.Message($"Automatic reward UUID capture is enabled. Configuring to capture {rewardId} in the future.");
                        }

                        ChannelPoints_Settings.AutomaticRewardUUIDCapture = false;
                        ChannelPoints_Settings.RewardUUID = rewardId;
                    }
                    else
                    {
                        if (ChannelPoints_Settings.ShowDebugMessages)
                        {
                            Log.Message("If this is the reward you would like to use, add this UUID to the mod settings.");
                        }
                    }
                }
            }
        }
    }
}
