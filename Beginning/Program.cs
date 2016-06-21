#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Beginning
{
	static class Program
    {
		private static Game1 game;

		internal static void RunGame (){
			game = new Game1 ();
			game.Run ();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
        [STAThread]
		static void Main (string[] args){
			RunGame ();
		}
	}
}

