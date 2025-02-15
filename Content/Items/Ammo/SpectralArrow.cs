using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace threeDS.Content.Items.Ammo
{
	// This example is similar to the Wooden Arrow item
	public class SpectralArrow : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 32;

			Item.damage = 16; // Keep in mind that the arrow's final damage is combined with the bow weapon damage.
			Item.DamageType = DamageClass.Ranged;

			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(copper: 18);
			Item.shoot = ModContent.ProjectileType<Projectiles.SpectralArrowProjectile>(); // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 3f; // The speed of the projectile.
			Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
		}

		// For a more detailed explanation of recipe creation, please go to Content/ExampleRecipes.cs.
		public override void AddRecipes() 
		{
			CreateRecipe(15)
				.AddIngredient(ItemID.WoodenArrow, 15)
				.AddIngredient<Content.Items.SoulofBlight>(1)
				.AddTile(TileID.WorkBenches)
				.Register();
        }
	}
}