namespace Refinator.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; } = true; // Allow to prevent displayment in customer app
        public bool IsDelete { get; set; } // Allow restoration and analytics

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}