using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.EntitySystem.Persistence;
using UnityModManagerNet;

namespace GameOver
{
	public class Main
	{
		public static bool Enabled;
		static bool Load(UnityModManager.ModEntry modEntry)
		{
			try
			{
				logger = modEntry.Logger;
				modEntry.OnToggle = OnToggle;
				var harmony = new Harmony(modEntry.Info.Id);

				harmony.PatchAll(Assembly.GetExecutingAssembly());
				return true;
			}
			catch (Exception ex)
			{
				Main.Error(ex);
			}
			return true;
		}

		static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
		{
			Enabled = value;
			return true;
		}

		public static void Error(Exception ex)
		{
			if (Main.logger != null)
			{
				Main.logger.Error(ex.ToString());
			}
		}
		internal static Exception Error(string message)
		{
			UnityModManager.ModEntry.ModLogger modLogger = Main.logger;
			if (modLogger != null)
			{
				modLogger.Log(message);
			}
			return new InvalidOperationException(message);
		}

		internal static UnityModManager.ModEntry.ModLogger logger;
		internal static bool enabled;
		[HarmonyLib.HarmonyPatch(typeof(Game), "LoadNewGame", new[] { typeof(BlueprintAreaPreset), typeof(SaveInfo) })]
		class LevelUpController_SetupNewCharacter_Patch
		{
			static void Postfix(ref Game __instance)
			{
				__instance.State.PlayerState.MainCharacter.Value.Descriptor.IsEssentialForGame = false;

			}
		}



	}



}
