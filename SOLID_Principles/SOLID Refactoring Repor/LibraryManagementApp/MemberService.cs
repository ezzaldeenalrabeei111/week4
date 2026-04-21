using System;
using System.Collections.Generic;
using LibraryManagementApp.Model;

namespace LibraryManagementApp.Services
{
    public class MemberService
    {
        private List<Member> _members;

        public MemberService()
        {
            _members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            if (member != null && !_members.Exists(m => m.MemberId == member.MemberId))
            {
                _members.Add(member);
                Console.WriteLine("Member Service: Member '{0}' added successfully.", member.Name);
            }
            else
            {
                Console.WriteLine("Member Service Error: Cannot add member. It might be null or the ID already exists.");
            }
        }

        public Member FindMemberById(int memberId)
        {
            return _members.Find(m => m.MemberId == memberId);
        }

        public List<Member> GetAllMembers()
        {
            return new List<Member>(_members);
        }
    }
}
