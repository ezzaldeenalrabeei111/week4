using System;

namespace LibraryManagementSystem.Core
{
    /// <summary>
    /// كلاس يمثل عضواً في المكتبة.
    /// </summary>
    public class Member
    {
        public int MemberId { get; private set; }
        public string Name { get; private set; }
        public string ContactInfo { get; private set; }

        /// <summary>
        /// منشئ الكلاس Member.
        /// </summary>
        /// <param name="memberId">الرقم التعريفي للعضو.</param>
        /// <param name="name">اسم العضو.</param>
        /// <param name="contactInfo">معلومات الاتصال بالعضو (بريد إلكتروني أو هاتف).</param>
        public Member(int memberId, string name, string contactInfo)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("Member ID must be positive.");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Member name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(contactInfo))
            {
                throw new ArgumentException("Contact info cannot be null or empty.");
            }

            MemberId = memberId;
            Name = name;
            ContactInfo = contactInfo;
        }

        /// <summary>
        /// عرض معلومات العضو.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Member ID: {MemberId}, Name: {Name}, Contact: {ContactInfo}");
        }
    }
}
