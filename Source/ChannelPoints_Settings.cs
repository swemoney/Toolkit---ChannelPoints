using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchToolkit.Settings;
using TwitchToolkit.Windows;
using UnityEngine;
using Verse;

namespace Toolkit___ChannelPoints
{
    public class ChannelPoints_Settings : ModSettings
    {
        public static int CoinsToAward = 300;
        public static string RewardUUID = "";
        public static string ChannelPointsName = "Channel Points";
        public static bool AutomaticRewardUUIDCapture = false;
        public static bool ShowDebugMessages = false;

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(inRect);

            string CoinsToAwardStr = CoinsToAward.ToString();
            ls.Label("Important Note: There is no official API from Twitch for redeeming Channel Points. For that reason, this mod will rely on chat to determine when someone redeems their points for your reward. YOU NEED TO SET YOUR REWARD TO REQUIRE A MESSAGE or the chat bot will never see it. I'm also sure that there may be hiccups that cause the bot to miss a redemption as well. You'll need to verify and award coins manually in these cases.");
            ls.Gap();
            ls.Gap();

            ls.Label("How many Twitch Toolkit coins should be given when this is purchased?");
            ls.TextFieldNumeric(ref CoinsToAward, ref CoinsToAwardStr);
            ls.Gap();
            ls.Gap();

            ls.Label("To make sure we are only finding the reward you set up, we'll match the UUID for the reward before handing out Toolkit coins.");
            ls.Gap();

            ls.Label("If you already know the UUID, just paste it here. If not, enable automatic UUID capture below and purchase the reward. We'll capture the first reward UUID that comes through and use that one from now on. You'll need to be loaded into a game with Twitch Toolkit connected to your chat for this to work.");
            RewardUUID = ls.TextEntry(RewardUUID);
            ls.Gap();

            ls.CheckboxLabeled("Automatic Reward UUID Capture", ref AutomaticRewardUUIDCapture);
            ls.Gap();
            ls.Gap();

            ls.Label("While Twitch calls them Channel Points, they allow you to define a custom name for your Channel Points. You can set that here so things don't feel so generic.");
            ChannelPointsName = ls.TextEntry(ChannelPointsName);
            ls.Gap();
            ls.Gap();
            ls.Gap();
            ls.Gap();

            ls.CheckboxLabeled("Show Debug Messages", ref ShowDebugMessages);

            ls.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref CoinsToAward, "CoinsToAward", 300);
            Scribe_Values.Look(ref RewardUUID, "RewardUUID", "");
            Scribe_Values.Look(ref ChannelPointsName, "ChannelPointsName", "Channel Points");
            Scribe_Values.Look(ref AutomaticRewardUUIDCapture, "AutomaticRewardUUIDCapture", false);
            Scribe_Values.Look(ref ShowDebugMessages, "ShowDebugMessages", false);
        }
    }
}
