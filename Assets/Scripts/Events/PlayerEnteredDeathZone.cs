using Simple2D.Mechanics;

namespace Simple2D.Events
{
    /// <summary>
    /// Fired when a player enters a trigger with a DeathZone component.
    /// </summary>
    public class PlayerEnteredDeathZone
    {
        public DeathZone deathzone;
        public PlayerController player;

        public PlayerEnteredDeathZone(DeathZone deathzone, PlayerController player) {
            this.deathzone = deathzone;
            this.player = player;
        }

        public void Execute()
        {
            player.controlEnabled = false;
            player.Respawn();
        }
    }
}