using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace threeDS.Content.Items.Weapons
{
	public class Tonbogiri : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
			ItemID.Sets.Spears[Item.type] = true; // This allows the game to recognize our new item as a spear.
		}

		public override void SetDefaults() {
			// Common Properties
			Item.rare = ItemRarityID.Pink; // Assign this item a rarity level of Pink
			Item.value = Item.sellPrice(gold: 40); // The number and type of coins item can be sold for to an NPC

            
            Item.width = 116;
            Item.height = 116;

			// Use Properties
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.useAnimation = 15; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useTime = 15; // The length of the item's use time in ticks (60 ticks == 1 second.)
			Item.UseSound = SoundID.Item71; // The sound that this item plays when used.
			Item.autoReuse = true; // Allows the player to hold click to automatically use the item again. Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()
			Item.useTurn = false; // Changed to false since spears shouldn't turn while in use
            
			// Weapon Properties
			Item.damage = 50;
			Item.knockBack = 6.5f;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; // Allows the item's animation to do damage. This is important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.

			// Add these properties for spear functionality
			Item.shoot = ModContent.ProjectileType<Projectiles.TonbogiriProjectile>();
			Item.shootSpeed = 3.7f; // Standard spear thrust speed
			Item.noUseGraphic = true; // The item should not be visible when used
		}

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) 
		{
            target.AddBuff(BuffID.Poisoned, 60 * 12);
        }

		public override bool CanUseItem(Player player) {
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override bool? UseItem(Player player) {
			// Because we're skipping sound playback on use animation start, we have to play it ourselves whenever the item is actually used.
			if (!Main.dedServ && Item.UseSound.HasValue) {
				SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
			}

			return null;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gungnir)
				// TODO: CHANGE TO SOUL OF BLIGHT
				.AddIngredient(ItemID.SoulofNight, 15)
				.AddIngredient(ItemID.AdamantiteBar, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.Gungnir)
				// TODO: CHANGE TO SOUL OF BLIGHT
				.AddIngredient(ItemID.SoulofNight, 15)
				.AddIngredient(ItemID.TitaniumBar, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}