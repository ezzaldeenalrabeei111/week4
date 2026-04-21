using System;
using BirdHierarchy.Core;

namespace BirdHierarchy.Birds
{
    /// <summary>
    /// كلاس يمثل طائر النعامة. يرث من Bird ولا يطبق واجهة IFlyable.
    /// يوضح كيف يمكن إضافة طيور غير طائرة دون انتهاك LSP.
    /// </summary>
    public class Ostrich : Bird
    {
        /// <summary>
        /// منشئ الكلاس Ostrich.
        /// </summary>
        /// <param name="name">اسم النعامة.</param>
        public Ostrich(string name) : base(name) { }

        /// <summary>
        /// عرض معلومات النعامة.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Type: Ostrich, Name: {Name}");
        }

        /// <summary>
        /// سلوك خاص بالنعامة (مثل الركض).
        /// </summary>
        public void Run()
        {
            Console.WriteLine($"{Name} is running very fast.");
        }
    }
}
