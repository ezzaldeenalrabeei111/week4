using System;
using BirdHierarchy.Core;

namespace BirdHierarchy.Birds
{
    /// <summary>
    /// كلاس يمثل طائر العصفور. يرث من Bird ويطبق واجهة IFlyable.
    /// </summary>
    public class Sparrow : Bird, IFlyable
    {
        /// <summary>
        /// منشئ الكلاس Sparrow.
        /// </summary>
        /// <param name="name">اسم العصفور.</param>
        public Sparrow(string name) : base(name) { }

        /// <summary>
        /// تنفيذ دالة الطيران الخاصة بالعصفور.
        /// </summary>
        public void Fly()
        {
            Console.WriteLine($"{Name} is chirping and flying short distances.");
        }

        /// <summary>
        /// عرض معلومات العصفور.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Type: Sparrow, Name: {Name}");
        }
    }
}
