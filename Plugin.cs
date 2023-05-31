using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace Keycarded_Nuke
{
	public class Plugin
	{
		public static Plugin Instance { get; private set; }

		[PluginConfig("configs/Keycarded-Nuke.yml")]
		public Config Config;

		[PluginPriority(LoadPriority.Medium)]
		[PluginEntryPoint("Keycarded Nuke", "1.0.0", "Keycarded Nuke.", "4Site Dev Team")]
		void LoadPlugin()
		{
			Instance = this;
			Log.Info("&3Loaded plugin...");
			Log.Info("&3Loaded plugin, registering events...");
			EventManager.RegisterEvents(this);
			EventManager.RegisterEvents<EventHandlers>(this);
			Log.Info("&2Succesfully Loaded Keycarded Nuke by 4Site Dev Team!");
		}
	}
}