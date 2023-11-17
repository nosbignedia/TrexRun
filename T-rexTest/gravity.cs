using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace T_rexTest
{
    internal class gravity

    {//dyno
        Vector2 size = new Vector2(30);
        Vector2 position;
        Vector2 velocity;
        Vector2 jumps;
        public gravity(float x, float y, float forceofgravity)
        {
            position = new Vector2(20, 500);
            jumps = new Vector2(0, forceofgravity);
        }
        public void update()
        {
            Applygravity();
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                DoJump();
            }
            position += velocity;

            // constrain  each frame
            float dynoY = position.Y;
            if (dynoY > 520)
            {
                position.Y = 520;
                velocity.Y = 0;
            }
        }
        public void DrawDyno()
        {
            Raylib.DrawRectangleV(position, size, Color.DARKPURPLE);
        }
        public void DoJump()
        {
            Vector2 Jumpforce = new Vector2(0, -5);
            velocity = Jumpforce;
        }
        public void Applygravity()
        {
            velocity += jumps * Raylib.GetFrameTime();
        }
    }
}
