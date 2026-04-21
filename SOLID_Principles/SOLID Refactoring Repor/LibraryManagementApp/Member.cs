using System;

namespace LibraryManagementApp.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Member(int id, string name, string email)
        {
            MemberId = id;
            Name = name;
            Email = email;
        }
    }
}
