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
        public static List<ChannelPoints_RewardSettings> RewardSettings;
        public static string ChannelPointsName = "Channel Points";
        public static bool ShowDebugMessages = false;

        public void DoWindowContents(Rect inRect)
        {
            if (RewardSettings == null)
            {
                RewardSettings = new List<ChannelPoints_RewardSettings>();
            }

            if (RewardSettings.Count < 1)
            {
                RewardSettings.Add(new ChannelPoints_RewardSettings());
            }

            // Define our starting positions
            float x = 10f;
            float y = 20f;
            float w = inRect.width - 20f;
            float lineHeight = 40f;
            float iconWidth = 20f;

            // Start the listing_standard
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(inRect);

            // Information label
            Rect infoRect = ls.Label("Important Note: This mod uses the built in chat bot from ToolkitCore to see if a Channel Points reward was redeemed. For that reason, YOU NEED TO SET YOUR REWARD ON TWITCH TO REQUIRE A MESSAGE or the chat bot will never see it. The user's Channel Points will be deducted immediately so if the chat bot doesn't pick up the redemption, you'll need to manually award Toolkit Coins to the user.");
            y += infoRect.height;

            // Reward Field Widths
            float nameWidth = w / 3;
            float uuidWidth = w / 3;
            float coinWidth = (w / 3) / 4;
            float autoWidth = (w / 3) / 4;
            float enableWidth = (w / 3) / 4;
            float deleteWidth = (w / 3) / 4;

            // Rewards table labels
            Rect rowRect = ls.GetRect(GenUI.ListSpacing);
            WidgetRow labelsRow = new WidgetRow(rowRect.x, rowRect.y, UIDirection.RightThenDown);
            labelsRow.Label("Name", nameWidth);
            labelsRow.Label("UUID", uuidWidth);
            labelsRow.Label("Amount", coinWidth);
            labelsRow.Label("Auto", autoWidth);
            labelsRow.Label("Enable", enableWidth);
            labelsRow.Label("Delete", deleteWidth);
            y += lineHeight;

            // Icons for reward options
            Texture2D autoIcon = ContentFinder<Texture2D>.Get("ui/commands/CopySettings");
            Texture2D enabledIcon = ContentFinder<Texture2D>.Get("ui/commands/DesirePower");
            Texture2D deleteIcon = ContentFinder<Texture2D>.Get("ui/buttons/Delete");

            for (int i = 0; i < RewardSettings.Count; i++)
            {
                ChannelPoints_RewardSettings reward = RewardSettings[i];
                WidgetRow rewardRow = new WidgetRow(rowRect.x, y, UIDirection.RightThenDown);

                Rect nameRect = rewardRow.Label("", nameWidth);
                Rect uuidRect = rewardRow.Label("", uuidWidth);
                Rect coinRect = rewardRow.Label("", coinWidth);

                rewardRow.Gap(4);
                rewardRow.ToggleableIcon(ref reward.AutomaticallyCaptureUUID, autoIcon, "Automatically Capture UUID?\n(Only works for one reward at a time)");
                rewardRow.Gap(autoWidth - iconWidth);
                rewardRow.ToggleableIcon(ref reward.Enabled, enabledIcon, "Reward Enabled?");
                rewardRow.Gap(enableWidth - iconWidth);
                if (rewardRow.ButtonIcon(deleteIcon, "Delete Reward?"))
                    RewardSettings.RemoveAt(i--);

                reward.RewardName = Widgets.TextField(nameRect, reward.RewardName);
                reward.RewardUUID = Widgets.TextField(uuidRect, reward.RewardUUID);
                reward.CoinsToAward = Widgets.TextField(coinRect, reward.CoinsToAward);
                y += lineHeight;
            }

            if (Widgets.ButtonText(new Rect(w - 100, y, 100, lineHeight), "Add Reward"))
            {
                RewardSettings.Add(new ChannelPoints_RewardSettings());
            }
            y += lineHeight * 2;

            Widgets.Label(new Rect(x, y, w, 25f), "What do you call your Channel Points?");
            y += 25f;

            ChannelPointsName = Widgets.TextField(new Rect(x, y, w, 25f), ChannelPointsName);
            y += lineHeight;

            Widgets.CheckboxLabeled(new Rect(x, y, w, lineHeight), "Show Debug Messages: ", ref ShowDebugMessages);

            ls.End();
        }

        public override void ExposeData()
        {
            Scribe_Collections.Look(ref RewardSettings, "RewardSettings", LookMode.Deep);
            Scribe_Values.Look(ref ChannelPointsName, "ChannelPointsName", "Channel Points");
            Scribe_Values.Look(ref ShowDebugMessages, "ShowDebugMessages", false);
        }
    }
}
