using Project2_LP2_2020;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CoreGameEngine;

namespace Project2_LP2_2020
{
    public class UIComponent : Component
    {
        private Color color;
        private Color lastColor;
        private UI ui = new UI();
        public override void Start()
        {
            color = Color.Yellow;
            lastColor = Color.None;
            ui.Welcome();
            ui.Options();
        }
        public override void Update()
        {

            ui.ColumnOptions(color);

            if (color == lastColor)
            {
                if (lastColor == Color.Yellow) color = Color.Red;
                else color = Color.Yellow;
            }
            lastColor = color;
        }
    }
}
