using NUnit.Framework;
using System;
using SwinGameSDK;

namespace BattleShips
{
	[TestFixture ()]
	public class BattleshipUnitTesting
	{
		[Test ()]
		public void TestPauseButtonClicked ()
		{

			int PAUSE_BUTTON_TOP_Y = 80;
			int PAUSE_BUTTON_RIGHT_X1 = 430;
			int PAUSE_BUTTON_LEFT_X2 = 350;


			Point2D mouse = default(Point2D);

			mouse.Y = PAUSE_BUTTON_TOP_Y;
			mouse.X = PAUSE_BUTTON_LEFT_X2;

			int row = 0;
			int col = 0;
			row = Convert.ToInt32(Math.Floor((mouse.Y - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
			col = Convert.ToInt32(Math.Floor((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));


			Assert.AreEqual (-1,row);
			Assert.AreEqual (0,col);

			mouse.X = PAUSE_BUTTON_RIGHT_X1;

			row = Convert.ToInt32(Math.Floor((mouse.Y - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
			col = Convert.ToInt32(Math.Floor((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));

			Assert.AreEqual (-1,row);
			Assert.AreEqual (1,col);



			SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);
			Assert.AreEqual (GameController.CurrentState, GameState.ViewingMainMenu);

			GameResources.LoadResources ();
			GameController.StartGame();


			GameController.HumanPlayer.RandomizeDeployment();
			GameController.EndDeployment();


			UtilityFunctions.DrawBackground();
			DiscoveryController.DrawDiscovery ();

			Assert.AreEqual (GameController.CurrentState, GameState.Discovering);

			//Do Attack on pause button
			GameController.Attack(row, col);


			Assert.AreEqual (GameController.CurrentState, GameState.ViewingGameMenu);
		}
	}
}

