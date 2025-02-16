using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace threeDS.Content.Projectiles
{
	// This example is similar to the Wooden Arrow projectile
	public class RomanCandleProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// If this arrow would have strong effects (like Holy Arrow pierce), we can make it fire fewer projectiles from Daedalus Stormbow for game balance considerations like this:
			//ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
		}

		public override void SetDefaults() {
			Projectile.width = 10; // The width of projectile hitbox
			Projectile.height = 10; // The height of projectile hitbox

			Projectile.arrow = true;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 1200;
            Projectile.rotation = Projectile.velocity.ToRotation(); // Makes the projectile point in the direction it's moving
            Projectile.spriteDirection = Projectile.direction;
		}

		public override void AI() {
			// Add a timer for explosion
			Projectile.ai[1] += 1f;
			if (Projectile.ai[1] >= 60f) {
				Projectile.Kill();
                SoundEngine.PlaySound(SoundID.Item8);
				return;
			}

            Projectile.rotation = Projectile.velocity.ToRotation();

			// The code below was adapted from the ProjAIStyleID.Arrow behavior. Rather than copy an existing aiStyle using Projectile.aiStyle and AIType,
			// like some examples do, this example has custom AI code that is better suited for modifying directly.
			// See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#what-is-ai for more information on custom projectile AI.
		}

		public override void OnKill(int timeLeft) {
			// Make the explosion effect more dramatic
			SoundEngine.PlaySound(SoundID.Item8, Projectile.position); // Explosion sound
			for (int i = 0; i < 20; i++) // Increased particle count
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				dust.noGravity = true;
				dust.velocity *= 2.5f;
				dust.scale *= 1.5f;
			} 
		}
	}
}