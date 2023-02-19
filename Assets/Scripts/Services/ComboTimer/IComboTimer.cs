using System;

namespace Services
{
    public interface IComboTimer
    {
        public Action<int, int> OnComboIncrease { get; set; }
        public int GetCombo();
    }
}