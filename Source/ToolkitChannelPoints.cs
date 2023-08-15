using System;
using System.Linq;
using System.Text;
using TwitchToolkit.Settings;
using TwitchToolkit.Windows;
using UnityEngine;
using Verse;

namespace Toolkit___ChannelPoints
{
    public class ToolkitChannelPoints : Mod
    {
        public ToolkitChannelPoints(ModContentPack content) : base(content)
        {
            Helper.LogMessage("Loading Channel Points Mod");
            GetSettings<ChannelPoints_Settings>();
            Settings_ToolkitExtensions.RegisterExtension(new ToolkitExtension(this, typeof(ChannelPointsPatchSettings)));
        }

        public override string SettingsCategory() => "Toolkit - Channel Points";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GetSettings<ChannelPoints_Settings>().DoWindowContents(inRect);
        }
    }

    public class ChannelPointsPatchSettings : ToolkitWindow
    {
        public ChannelPointsPatchSettings(Mod mod) : base(mod)
        {
            this.Mod = mod;
        }

        public override void DoWindowContents(Rect inRect)
        {
            Mod.GetSettings<ChannelPoints_Settings>().DoWindowContents(inRect);
        }
    }
    
}
