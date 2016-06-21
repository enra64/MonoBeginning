using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beginning
{
	public abstract class Entity
	{
		public Model Model { get; set; }
		public Matrix RotationMatrix = Matrix.Identity;
		public Vector3 Position = Vector3.Zero;

		public void LoadContent(ContentManager manager, string path){
			Model = manager.Load<Model> (path);
		}

		public abstract void Update(GameTime time);

		public virtual void Draw(Camera c){
			// apply basic effects
			foreach (var m in Model.Meshes) {
				foreach (BasicEffect effect in m.Effects){
					effect.EnableDefaultLighting();
					effect.PreferPerPixelLighting = true;
					effect.World = RotationMatrix * Matrix.CreateWorld(Position, Vector3.UnitX, Vector3.UnitY);
					effect.View = c.ViewMatrix;
					effect.Projection = c.ProjectionMatrix;
				}
				m.Draw();
			}
		}
	}
}

