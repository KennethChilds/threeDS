using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace threeDS.Content.Items.Weapons
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class Tizona : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.threeDS.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(gold: 6);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) 
		{
            target.AddBuff(BuffID.OnFire, 60 * 12);
        }

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.Excalibur)
				// TODO: CHANGE TO SOUL OF BLIGHT
				.AddIngredient<Content.Items.SoulofBlight>(15)
				.AddIngredient(ItemID.AdamantiteBar, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.Excalibur)
				// TODO: CHANGE TO SOUL OF BLIGHT
				.AddIngredient<Content.Items.SoulofBlight>(15)
				.AddIngredient(ItemID.TitaniumBar, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
