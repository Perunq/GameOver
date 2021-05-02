using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using CallOfTheWild;
using CallOfTheWild.NewMechanics;
using System;

namespace GameOver
{
	public class RemoveSlumberHD
	{
		private static LibraryScriptableObject library
		{
			get
			{
				return Main.Library;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002918 File Offset: 0x00000B18
		public static void modSlumber()
		{
			try
			{
				foreach (string assetId in RemoveSlumberHD.guids)
				{
					BlueprintAbility blueprintAbility = RemoveSlumberHD.library.Get<BlueprintAbility>(assetId);
					if (blueprintAbility != null)
					{
						blueprintAbility.RemoveComponents<AbilityTargetCasterHDDifference>();
					}
				}
			}
			catch (Exception ex)
			{
				return;
			}
			
		}


		public static string[] guids = new string[]
		{
			"31f0fa4235ad435e95ebc89d8549c2ce",
			"b03f4347c1974e38acff99a2af092461",
			"15d3a2eef8ac43dd886d2bae83be35eb",
			"c04cde18e91e4f84898de92a372bc1e0",
			"6535cf6ab2c143079468edb7e1cd2b86",
			"e845d92965544e2ba9ca7ab5b1b246ca",
			"656b4f5990f14f29b0e2c262a39d274f"
		};
	}
}