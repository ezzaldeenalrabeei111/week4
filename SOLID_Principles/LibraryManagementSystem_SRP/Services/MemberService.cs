using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Core;

namespace LibraryManagementSystem.Services
{
    /// <summary>
    /// كلاس مسؤول عن إدارة أعضاء المكتبة (إضافة، بحث).
    /// يتبع مبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class MemberService
    {
        private readonly List<Member> _members;

        /// <summary>
        /// منشئ الكلاس MemberService.
        /// </summary>
        public MemberService()
        {
            _members = new List<Member>();
        }

        /// <summary>
        /// إضافة عضو جديد إلى قائمة الأعضاء.
        /// </summary>
        /// <param name="member">العضو المراد إضافته.</param>
        public void AddMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member", "Cannot add a null member.");
            }
            // التحقق من عدم وجود عضو بنفس الرقم التعريفي لتجنب التكرار.
            if (_members.Any(m => m.MemberId == member.MemberId))
            {
                Console.WriteLine($"Error: Member with ID {member.MemberId} already exists.");
                return;
            }
            _members.Add(member);
            Console.WriteLine($"Member \'{member.Name}\' (ID: {member.MemberId}) added.");
        }

        /// <summary>
        /// البحث عن عضو باستخدام رقمه التعريفي.
        /// </summary>
        /// <param name="memberId">الرقم التعريفي للعضو المراد البحث عنه.</param>
        /// <returns>العضو إذا وجد، وإلا يعيد null.</returns>
        public Member FindMemberById(int memberId)
        {
            return _members.FirstOrDefault(m => m.MemberId == memberId);
        }

        /// <summary>
        /// الحصول على جميع الأعضاء المسجلين.
        /// </summary>
        /// <returns>قائمة بجميع أعضاء المكتبة.</returns>
        public List<Member> GetAllMembers()
        {
            return new List<Member>(_members);
        }
    }
}
