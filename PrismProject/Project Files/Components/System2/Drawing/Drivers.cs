﻿using Cosmos.System.Graphics;
using System;
using System.IO;

namespace PrismProject.System2.Drawing
{
    internal class Drivers
    {
        internal class Video
        {
            public static int SW = 1024;
            public static int SH = 768;
            public static SVGAIICanvas Screen = new SVGAIICanvas();
            public static string Font = "YuGothicUI";

            public static void Init()
            {
                Screen.Mode = new Mode(SW, SH, ColorDepth.ColorDepth32);
                string CustomCharset = "🡬abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()~`\"\':;?/>.<,{[}]\\|+=_-";
                MemoryStream YuGothicUICustomCharset16 = new MemoryStream(Convert.FromBase64String("AAAAAB/8GAwUFBIkEUQQhBCEEUQSJBQUGBwf/AAAAAAAAAAAH/wYDBQUEiQRRBCEEIQRRBIkFBQYHB/8AAAAAAAAAAAAAAAAAAAOABMAAQAPABEAEwAdAAAAAAAAAAAAAAAAABAAEAAQABcAGYAQgBCAEIAZgBcAAAAAAAAAAAAAAAAAAAAAAAAADwAZABAAEAAQABAADgAAAAAAAAAAAAAAAAAAgACAAIAOgBGAEIAQgBGAEYAOgAAAAAAAAAAAAAAAAAAAAAAAAA4AEQARAB8AEAAQAA8AAAAAAAAAAAAAAAAADAAIABAAPAAQABAAEAAQABAAEAAAAAAAAAAAAAAAAAAAAAAAAAAOgBGAEIAQgBGAEYAOgAEAAQAeAAAAAAAAABAAEAAQABcAGQARABEAEQARABEAAAAAAAAAAAAAAAAAEAAAAAAAEAAQABAAEAAQABAAEAAAAAAAAAAAAAAAAAAQAAAAAAAQABAAEAAQABAAEAAQABAAEABgAAAAAAAAABAAEAAQABMAEgAUABgAFAASABEAAAAAAAAAAAAAAAAAEAAQABAAEAAQABAAEAAQABAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAABZwGZAREBEQERAREBEQAAAAAAAAAAAAAAAAAAAAABcAGQARABEAEQARABEAAAAAAAAAAAAAAAAAAAAAAAAADwARgBCAEIAQgBGADwAAAAAAAAAAAAAAAAAAAAAAAAAXABmAEIAQgBCAGYAXABAAEAAQAAAAAAAAAAAAAAAAAA6AEYAQgBCAEYARgA6AAIAAgACAAAAAAAAAAAAAAAAAFAAYABAAEAAQABAAEAAAAAAAAAAAAAAAAAAAAAAAAAAeABAAEAAMAAIAAgAcAAAAAAAAAAAAAAAAAAAAEAAQADwAEAAQABAAEAAYAAwAAAAAAAAAAAAAAAAAAAAAAAAAEQARABEAEQARABEADwAAAAAAAAAAAAAAAAAAAAAAAAAhABEAEgASAAoADAAMAAAAAAAAAAAAAAAAAAAAAAAAACIgEyATIBVAFUAMwAiAAAAAAAAAAAAAAAAAAAAAAAAAEgASAAwADAAMABIAMgAAAAAAAAAAAAAAAAAAAAAAAAAhABEAEgASAAoADAAMAAgACAAwAAAAAAAAAAAAAAAAAB4AAgAEAAgACAAQAD8AAAAAAAAAAAAAAAAAAAAGAAYABQAJAAkAGIAfgBDAMEAAAAAAAAAAAAAAAAAAAB8AEQARABEAHgARgBCAEYAfAAAAAAAAAAAAAAAAAAAAB4AIABAAEAAQABAAEAAIAAeAAAAAAAAAAAAAAAAAAAAfABDAEEAQQBBgEEAQQBCAHwAAAAAAAAAAAAAAAAAAAB8AEAAQABAAHwAQABAAEAAfAAAAAAAAAAAAAAAAAAAAHwAQABAAEAAfABAAEAAQABAAAAAAAAAAAAAAAAAAAAAHwAhAEAAQABHAEEAQQAhAB4AAAAAAAAAAAAAAAAAAABBAEEAQQBBAH8AQQBBAEEAQQAAAAAAAAAAAAAAAAAAAEAAQABAAEAAQABAAEAAQABAAAAAAAAAAAAAAAAAAAAAMAAwADAAMAAwADAAIAAgAMAAAAAAAAAAAAAAAAAAAABGAEQASABQAHAAUABIAEQAQgAAAAAAAAAAAAAAAAAAAEAAQABAAEAAQABAAEAAQAB8AAAAAAAAAAAAAAAAAAAAAABgQGDAUMBQwElASUBKQEZAREAAAAAAAAAAAAAAAABhgHGAUYBJgEmARYBDgEKAQYAAAAAAAAAAAAAAAAAAAB4AIQBAgECAQIBAgECAIQAeAAAAAAAAAAAAAAAAAAAAfABGAEIAQgBEAHgAQABAAEAAAAAAAAAAAAAAAAAAAAAeACEAQIBAgECAQIBAgCEAHwABgAAAAAAAAAAAAAAAAHwARgBCAEQAeABMAEQAQgBCAAAAAAAAAAAAAAAAAAAAPABEAEAAYAA4AAwABAAEAHgAAAAAAAAAAAAAAAAAAAD+ABAAEAAQABAAEAAQABAAEAAAAAAAAAAAAAAAAAAAAEEAQQBBAEEAQQBBAEEAYgA8AAAAAAAAAAAAAAAAAAAAgQBCAEIAYgAkACQAHAAYABgAAAAAAAAAAAAAAAAAAAAAAIIQRjBGIEUgaSApQClAMMAQwAAAAAAAAAAAAAAAAEIAZAAkABgAGAAYACQARgBCAAAAAAAAAAAAAAAAAAAAwgBEAEQAKAAoABAAEAAQABAAAAAAAAAAAAAAAAAAAAB+AAQADAAIABAAMAAgAEAA/gAAAAAAAAAAAAAAAAAAABgAaAAIAAgACAAIAAgACAAIAAAAAAAAAAAAAAAAAAAAOABEAAQABAAIABAAYABAAHwAAAAAAAAAAAAAAAAAAAB4AEwABAAIADAADAAEAAQAeAAAAAAAAAAAAAAAAAAAAAgAGAAYACgASABIAP4ACAAIAAAAAAAAAAAAAAAAAAAAfABAAEAAeAAMAAQABABMAHgAAAAAAAAAAAAAAAAAAAAcACAAQAB4AEQARABEAEQAOAAAAAAAAAAAAAAAAAAAAHwABAAIAAgAEAAQABAAIAAgAAAAAAAAAAAAAAAAAAAAOABEAEQARAA4AEQARABEADgAAAAAAAAAAAAAAAAAAAA4AEQARABEAEQAPAAEAAwAeAAAAAAAAAAAAAAAAAAAADgARABEAEQARABEAEQARAA4AAAAAAAAAAAAAAAAAAAAQABAAEAAQABAAEAAAABAAEAAAAAAAAAAAAAAAAAAAAAAAA+AEEAmIEkgSSBJIEkgLsAwAA+AAAAAAAAAAAAAABQAFAB+ACQAKAD+ACgASAAAAAAAAAAAAAAAAAAAABAAPABUAFAAcAA4ABwAFABUAHgAEAAAAAAAAAAAAAAAAABxAEkASgBMAHWACkASQBJAIYAAAAAAAAAAAAAAAAAAAAgAGAAUACIAIgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHAAkACSAOIAsgEKAQwBDADzAAAAAAAAAAAAAAAAAAAAgAHgAIABQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAIABAAEAAQABAAEAAQABAACAAIAAAAAAAAAAAAAAAgABAACAAIAAgACAAIAAgACAAQABAAAAAAAAAAAAAAAAAAAAAAAAAADkATgAAAAAAAAAAAAAAAAAAAAAAAABAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUABQAFAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAEAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAEAAAAAAAAAAQABAAAAAAAAAAAAAAAAAAAAAAAAAAEAAQAAAAAAAAAAAAEAAQACAAAAAAAAAAAAAAAB4AAgACAAQACAAIAAAACAAIAAAAAAAAAAAAAAAAAAAAAgACAAQABAAIAAgACAAQABAAIAAgAAAAAAAAAAAAAAAAAAAACAAGAAEAAYAGAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAAQAAAAAAAAAAAAAAAAAAAAAAAAAACAAwAEAAwAAwAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAAQACAAAAAAAAAAAAAAAAwACAAIAAgAEAAQABAACAAIAAgADAAAAAAAAAAAAAAAHAAQABAAEAAQABAAEAAQABAAEAAcAAAAAAAAAAAAAAAwABAAEAAQABgACAAYABAAEAAQADAAAAAAAAAAAAAAADgACAAIAAgACAAIAAgACAAIAAgAOAAAAAAAAAAAAAAAEQARAAoACgAfAAQAHwAEAAQAAAAAAAAAAAAAAAAAEAAQABAAEAAQABAAEAAQABAAEAAQABAAEAAAAAAAAAAAAAAAAgACAAIAH4ACAAIAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH4AAAAAAH4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD4AAAAAAAAAAAAAAAAAAAAAAAAAHAAAAAAAAAAAAAAAAAAAAAAA"));
                proprietary.BitFont.RegisterBitFont("YuGothicUI", new proprietary.BitFont.BitFontDescriptor(CustomCharset, YuGothicUICustomCharset16, 16));
            }
        }
    }
}