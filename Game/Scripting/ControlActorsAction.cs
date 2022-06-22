using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the cycle.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the cycle's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a") || keyboardService.IsKeyDown("left") || keyboardService.IsKeyDown("j"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d") || keyboardService.IsKeyDown("right") || keyboardService.IsKeyDown("l"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w")|| keyboardService.IsKeyDown("up") || keyboardService.IsKeyDown("i"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s")|| keyboardService.IsKeyDown("down") || keyboardService.IsKeyDown("j"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            Cycle cycle_two = (Cycle)cast.GetFirstActor("cycle_two");
            cycle.TurnHead(direction);
            cycle_two.TurnHead(direction);

        }
    }
}