using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;


namespace Unit05.Game
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            Color head_1 = new Color(0, 0, 0);
            head_1 = Constants.GREEN;
            Color body_1 = new Color(0, 0, 0);
            body_1 = Constants.GREEN;
            Color head_2 = new Color(0, 0, 0);
            head_2 = Constants.RED;
            Color body_2 = new Color(0, 0, 0);
            body_2 = Constants.RED;

            // create the cast
            Cast cast = new Cast();
            cast.AddActor("cycles", new Cycle(head_1, body_1));
            cast.AddActor("cycles", new Cycle(head_2, body_2));


            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}