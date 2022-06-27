using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the cycle 
    /// collides with itself, or with the other cycle.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }


        /// <summary>
        /// Sets the game over flag if the cycle collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("cycles");
            Actor head = cycle.GetHead();
            List<Actor> body = cycle.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Cycle cycle = (Cycle)cast.GetFirstActor("cycles");
                List<Actor> segments = cycle.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // create object to display who won
                Actor winner = new Actor();
                winner.SetText("The winner is: ");
                cast.AddActor("winner", winner);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
        }
    }
}