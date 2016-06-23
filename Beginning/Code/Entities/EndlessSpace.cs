using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Beginning
{
	public class EndlessSpace: Entity
	{
		GraphicsDeviceManager graphics;
		GraphicsDevice graphicsDevice;
		private VertexPositionTexture[] floorVerts;
		BasicEffect effect;
		Texture2D checkerboardTexture;

		public EndlessSpace(GraphicsDeviceManager g, GraphicsDevice g2){
			graphics = g;
			graphicsDevice = g2;
		}

		public void Initialize(){
			floorVerts = new VertexPositionTexture[6];
			floorVerts [0].Position = new Vector3 (-20, -20, 0);
			floorVerts [1].Position = new Vector3 (-20,  20, 0);
			floorVerts [2].Position = new Vector3 ( 20, -20, 0);
			floorVerts [3].Position = floorVerts[1].Position;
			floorVerts [4].Position = new Vector3 ( 20,  20, 0);
			floorVerts [5].Position = floorVerts[2].Position;

			floorVerts [0].TextureCoordinate = new Vector2 (0, 0);
			floorVerts [1].TextureCoordinate = new Vector2 (0, 1);
			floorVerts [2].TextureCoordinate = new Vector2 (1, 0);
			floorVerts [3].TextureCoordinate = floorVerts[1].TextureCoordinate;
			floorVerts [4].TextureCoordinate = new Vector2 (1, 1);
			floorVerts [5].TextureCoordinate = floorVerts[2].TextureCoordinate;

			// We’ll be assigning texture values later
			effect = new BasicEffect (graphics.GraphicsDevice);
		}

		public void LoadContent(){
			using (var stream = TitleContainer.OpenStream ("Content/checkerboard.png")){
				checkerboardTexture = Texture2D.FromStream (graphicsDevice, stream);
			}
		}

		public override void Update(GameTime gt){
		}

		public override void Draw(Camera c){
			// The assignment of effect.View and effect.Projection
			// are nearly identical to the code in the Model drawing code.
			effect.View = c.ViewMatrix;

			effect.Projection = c.ProjectionMatrix;

			effect.TextureEnabled = true;
			effect.Texture = checkerboardTexture;


			foreach (var pass in effect.CurrentTechnique.Passes){
				pass.Apply ();

				graphics.GraphicsDevice.DrawUserPrimitives (
					PrimitiveType.TriangleList, // this is a list of triangles
					floorVerts,// data
					0,// offset
					2);// The number of triangles to draw
			}
		}
	}
}