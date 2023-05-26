using Refinator.Models.Base;
using Refinator.Models.Room.Enums;
using Refinator.Models.User;

namespace Refinator.Models.Rooms
{
    public class RoomModel : BaseModel
    {
        public string Label { get; set; }
        public Guid UserId { get; set; }
        public bool IsUse { get; set; }
        public RoomStatusEnum StatusEnum { get; set; } = RoomStatusEnum.WaitingForModerator;
        public CardTypeEnum CardTypeEnum { get; set; } = CardTypeEnum.AgileCardEnum;

        public UserModel User { get; set; }
        public IList<RoomUserModel> RoomUsers { get; set; } = new List<RoomUserModel>();
    }
}
