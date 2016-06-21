using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beginning
{
	public class Player : Entity
	{
		Matrix world = Matrix.Identity;

		public void Initialize(Texture3D texture, Vector2 position){
		}

		public override void Update(GameTime gt){
			Matrix trl = Matrix.CreateTranslation(0, 0, 0);

			if(Keyboard.GetState().IsKeyDown(Keys.W))
				trl = Matrix.CreateTranslation (0, 0, 1);
			if(Keyboard.GetState().IsKeyDown(Keys.A))
				trl = Matrix.CreateTranslation (0, 1, 0);
			if(Keyboard.GetState().IsKeyDown(Keys.S))
				trl = Matrix.CreateTranslation (0, 0, -1);
			if(Keyboard.GetState().IsKeyDown(Keys.D))
				trl = Matrix.CreateTranslation (0, -1, 0);
			
			world *= trl;
		}

		public override void Draw(Camera c){
			// apply basic effects
			foreach (var m in Model.Meshes) {
				foreach (BasicEffect effect in m.Effects){
					// enable default lighting & per pixel lighting
					effect.EnableDefaultLighting();
					effect.PreferPerPixelLighting = true;

					effect.World = world;
					effect.View = c.ViewMatrix;
					effect.Projection = c.ProjectionMatrix;

					//effect.World = RotationMatrix * Matrix.CreateWorld(Position, Vector3.UnitX, Vector3.UnitY);
					//effect.View = c.ViewMatrix;
					//effect.Projection = c.ProjectionMatrix;
				}
				m.Draw();
			}
		}
	}
}

