using PdnLesson09.Models.DataModels;

namespace PdnLesson09.Models.DataModels
{
    public class PdnMember
    {
        public int PdnMemberId { get; set; }
        public string PdnUserName { get; set; }
        public string PdnPassword { get; set; }
        public string PdnEmail { get; set; }
        public string PdnPhoneNumber { get; set; }
        public string PdnFullName { get; set; }
        public DateTime PdnBirthday  { get; set; }
    }
}
