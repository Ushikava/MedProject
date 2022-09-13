using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestV.Questions.Elements
{
    public delegate void ValueChangedHandler(int index, int value);
    interface Variant
    {
        public int Value { get; set; }
        public event ValueChangedHandler ValueChangedEvent;
    }
}
