using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that cycles like to eat.</para>
    /// <para>
    /// The responsibility of Score is...? (Before it said Food?)
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of Score
        /// </summary>
        public Score()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Score: {this.points}");
        }
    }
}