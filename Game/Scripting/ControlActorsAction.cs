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
         private Point direction_two = new Point(Constants.CELL_SIZE, 0);

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
            // left ----------------------------------------------------------------------------
            if (keyboardService.IsKeyDown("a") || keyboardService.IsKeyDown("left"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            if (keyboardService.IsKeyDown("j"))
            {
                direction_two = new Point(-Constants.CELL_SIZE, 0);
            }

            // right ----------------------------------------------------------------------------
            if (keyboardService.IsKeyDown("d") || keyboardService.IsKeyDown("right"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            if (keyboardService.IsKeyDown("l"))
            {
                direction_two = new Point(Constants.CELL_SIZE, 0);
            }

            // up ----------------------------------------------------------------------------
            if (keyboardService.IsKeyDown("w")|| keyboardService.IsKeyDown("up"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            if (keyboardService.IsKeyDown("i"))
            {
                direction_two = new Point(0, -Constants.CELL_SIZE);
            }

            // down ----------------------------------------------------------------------------
            if (keyboardService.IsKeyDown("s")|| keyboardService.IsKeyDown("down"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            if (keyboardService.IsKeyDown("k"))
            {
                direction_two = new Point(0, Constants.CELL_SIZE);
            }

            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            Cycle_Two cycle_two = (Cycle_Two)cast.GetFirstActor("cycle_two");
            cycle.TurnHead(direction);
            cycle_two.TurnHead(direction_two);

        }
    }
}