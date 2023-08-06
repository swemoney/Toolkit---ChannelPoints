using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TwitchLib.Client.Models;
using TwitchLib.Client.Models.Interfaces;
using ToolkitCore;
using TwitchToolkit;
using TwitchToolkit.Store;
using Verse;

namespace Toolkit___ChannelPoints
{
    public class ChannelPointsComponent : TwitchInterfaceBase
    {
        public ChannelPointsComponent(Game game) { }

        public override void ParseMessage(ITwitchMessage msg)
        {
            if (msg.ChatMessage == null)
            {
                return;
            }

            if (msg.ChatMessage.CustomRewardId != null)
            {
                string rewardId = msg.ChatMessage.CustomRewardId;
                ChannelPoints_RewardSettings reward = ChannelPoints_Settings.RewardSettings.FirstOrDefault(r => r.RewardUUID == rewardId);

                if (reward != null)
                {
                    ChannelPoints.AwardCoinsToUser(msg.Username, reward.CoinsToAward);
                }
                else
                {
                    if (ChannelPoints_Settings.ShowDebugMessages)
                    {
                        Log.Message($"<color=#6441A4>[Toolkit - ChannelPoints]</color> Detected a custom reward that wasn't configured: {rewardId}");
                    }

                    ChannelPoints_RewardSettings autoReward = ChannelPoints_Settings.RewardSettings.FirstOrDefault(r => r.AutomaticallyCaptureUUID == true);
                    if (autoReward != null)
                    {
                        if (ChannelPoints_Settings.ShowDebugMessages)
                        {
                            Log.Message($"<color=#6441A4>[Toolkit - ChannelPoints]</color> A reward with Automatic UUID capture enabled was found. Configuring this reward to use {rewardId}.");
                        }

                        autoReward.AutomaticallyCaptureUUID = false;
                        autoReward.RewardUUID = rewardId;
                    }
                    else
                    {
                        if (ChannelPoints_Settings.ShowDebugMessages)
                        {
                            Log.Message("<color=#6441A4>[Toolkit - ChannelPoints]</color> If this is the reward you would like to use, add this UUID to the mod settings.");
                        }
                    }
                }
            }
        }
    }
}
