using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Beginning
{
	public class Camera
	{
		public float AspectRatio;
		public float FarClipPlane;
		public float FieldOfView;
		public float NearClipPlane;

		public Vector3 Position;
		public Vector3 Target;
		public Vector3 UpVector;

		public Matrix ViewMatrix {
			get {
				Vector3 target = Vector3.Zero;
				Vector3 upVector = Vector3.UnitZ;

				return Matrix.CreateLookAt (Position, target, upVector);
			}
		}

		public Matrix ProjectionMatrix
		{
			get { return Matrix.CreatePerspectiveFieldOfView(FieldOfView, AspectRatio, NearClipPlane, FarClipPlane); }
		}

		public void Update(GameTime gameTime)
		{
			if (Keyboard.GetState ().IsKeyDown (Keys.I))
				Position = Vector3.Transform(Position, Matrix.Identity * Matrix.CreateRotationX(.05f));
			if (Keyboard.GetState ().IsKeyDown (Keys.K))
				Position = Vector3.Transform(Position, Matrix.Identity * Matrix.CreateRotationX(-.05f));

			if (Keyboard.GetState ().IsKeyDown (Keys.Z))
				Position = Vector3.Transform(Position, Matrix.Identity * Matrix.CreateRotationY(.05f));
			if (Keyboard.GetState ().IsKeyDown (Keys.H))
				Position = Vector3.Transform(Position, Matrix.Identity * Matrix.CreateRotationY(-.05f));

			if (Keyboard.GetState ().IsKeyDown (Keys.U))
				Position = Vector3.Transform(Position, Matrix.Identity * Matrix.CreateRotationZ(.05f));
			if (Keyboard.GetState ().IsKeyDown (Keys.J))
				Position = Vector3.Transform(Position, Matrix.Identity * Matrix.CreateRotationZ(-.05f));
			
			if (Keyboard.GetState().IsKeyDown(Keys.L))
				Position += new Vector3(0, 1, 0);
			if (Keyboard.GetState().IsKeyDown(Keys.O))
				Position -= new Vector3(0, 1, 0);
		}
	}
}