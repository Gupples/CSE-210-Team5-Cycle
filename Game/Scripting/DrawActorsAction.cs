using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("cycles");
            List<Actor> segments = cycle.GetSegments();

            Cycle cycle_two = (Cycle)cast.GetSecondActor("cycles");
            List<Actor> segments_two = cycle_two.GetSegments();

            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActors(segments_two);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}