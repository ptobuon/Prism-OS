﻿using PrismGL2D;

namespace PrismUI
{
    public class Textbox : Control
    {
        public Textbox(uint Width, uint Height) : base(Width, Height)
		{
            Hint = "";
		}

        public string Hint;

        internal override void OnDraw(Graphics G)
        {
            base.OnDraw(G);

            DrawString((int)(Width / 2), (int)(Height / 2), Text.Length == 0 ? Hint : Text, Config.Font, Config.GetForeground(false, false), true);

            if (HasBorder)
            {
                G.DrawRectangle(X - 1, Y - 1, Width + 2, Height + 2, Config.Radius, Config.GetForeground(false, false));
            }

            G.DrawImage(X, Y, this, Config.ShouldContainAlpha(this));
        }
    }
}