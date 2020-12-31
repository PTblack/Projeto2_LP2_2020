using Project2_LP2_2020.GameEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Project2_LP2_2020
{
    public class UIComponent : Component
    {
        private Color color;
        private Color lastColor;
        public override void Start()
        {
            color = Color.Yellow;
            lastColor = Color.None;
            UI.Welcome();
            UI.Options();
        }
        public override void Update()
        {
            UI.ColumnOptions(color);

            if (color == lastColor)
            {
                if (lastColor == Color.Yellow) color = Color.Red;
                else color = Color.Yellow;
            }
            lastColor = color;
        }
    }
}
