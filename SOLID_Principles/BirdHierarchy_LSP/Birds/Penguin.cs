using System;
using BirdHierarchy.Core;

namespace BirdHierarchy.Birds
{
    /// <summary>
    /// كلاس يمثل طائر البطريق. يرث من Bird ولا يطبق واجهة IFlyable.
    /// يوضح كيف يمكن إضافة طيور غير طائرة دون انتهاك LSP.
    /// </summary>
    public class Penguin : Bird
    {
        /// <summary>
        /// منشئ الكلاس Penguin.
        /// </summary>
        /// <param name="name">اسم البطريق.</param>
        public Penguin(string name) : base(name) { }

        /// <summary>
        /// عرض معلومات البطريق.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Type: Penguin, Name: {Name}");
        }

        /// <summary>
        /// سلوك خاص بالبطريق (مثل السباحة).
        /// </summary>
        public void Swim()
        {
            Console.WriteLine($"{Name} is swimming gracefully.");
        }
    }
}
