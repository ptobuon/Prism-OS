﻿using PrismGL2D;

namespace PrismUI
{
    public class Label : Control
    {
        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                string[] S = value.Split('\n');
                for (int I = 0; I < S.Length; I++)
                {
                    uint TW = Config.Font.MeasureString(S[I]);
                    if (TW > Width)
                    {
                        Width = TW;
                    }
                }
                Height = (uint)(Config.Font.Size * value.Split('\n').Length);
                base.Text = value;
            }
        }

        public override void OnDrawEvent(Control C)
        {
            base.OnDrawEvent(this);

            Clear(Color.Transparent);
            DrawString(0, 0, Text, Config.Font, Config.GetForeground(false, false));

            if (HasBorder)
            {
                DrawRectangle(0, 0, Width - 1, Height - 1, Config.Radius, Config.AccentColor);
            }

            C.DrawImage(X, Y, this, true);
        }
    }
}