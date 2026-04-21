using System;
using BirdHierarchy.Core;

namespace BirdHierarchy.Birds
{
    /// <summary>
    /// كلاس يمثل طائر النسر. يرث من Bird ويطبق واجهة IFlyable.
    /// </summary>
    public class Eagle : Bird, IFlyable
    {
        /// <summary>
        /// منشئ الكلاس Eagle.
        /// </summary>
        /// <param name="name">اسم النسر.</param>
        public Eagle(string name) : base(name) { }

        /// <summary>
        /// تنفيذ دالة الطيران الخاصة بالنسر.
        /// </summary>
        public void Fly()
        {
            Console.WriteLine($"{Name} is soaring high in the sky.");
        }

        /// <summary>
        /// عرض معلومات النسر.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Type: Eagle, Name: {Name}");
        }
    }
}
