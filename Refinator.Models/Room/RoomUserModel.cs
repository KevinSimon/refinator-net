using Refinator.Models.User;

namespace Refinator.Models.Rooms
{
    public class RoomUserModel
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public bool IsOwner { get; set; }
        public bool IsConnected { get; set; }
        public bool IsModerator { get; set; }
        public bool IsPlayer { get; set; }
        public int? CurrentVote { get; set; }

        public RoomModel Room { get; set; }
        public UserModel User { get; set; }
    }
}
