using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Beginning
{
	public class Camera
	{
		private float AspectRatio, FieldOfView = MathHelper.PiOver2, FarClipPlane = 10000f, NearClipPlane = .1f;
		public Vector3 Target = Vector3.Zero, UpVector = Vector3.UnitZ;
		private Vector3 _position;

		public Matrix ViewMatrix { get { return Matrix.CreateLookAt (_position, Target, UpVector); } }
		public Matrix ProjectionMatrix { get { return Matrix.CreatePerspectiveFieldOfView(FieldOfView, AspectRatio, NearClipPlane, FarClipPlane); }	}

		public Camera(float aspectRatio) {
			AspectRatio = aspectRatio;
			_position = new Vector3 (0, 100, 0);
		}

		public void Update(GameTime gameTime)
		{
			if (Keyboard.GetState ().IsKeyDown (Keys.I))
				_position = Vector3.Transform(_position, Matrix.CreateRotationX(.05f));
			if (Keyboard.GetState ().IsKeyDown (Keys.K))
				_position = Vector3.Transform(_position, Matrix.CreateRotationX(-.05f));
			
			if (Keyboard.GetState ().IsKeyDown (Keys.U))
				_position = Vector3.Transform(_position, Matrix.CreateRotationZ(.05f));
			if (Keyboard.GetState ().IsKeyDown (Keys.J))
				_position = Vector3.Transform(_position, Matrix.CreateRotationZ(-.05f));

			if (Keyboard.GetState ().IsKeyDown (Keys.L))
				_position = Vector3.Transform(_position, Matrix.CreateScale(1.02f));
			if (Keyboard.GetState ().IsKeyDown (Keys.O))
				_position = Vector3.Transform(_position, Matrix.CreateScale(.98f));
		}
	}
}