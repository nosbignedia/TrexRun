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
        bool hasTouchedGround = true;
        //This is the name of the sound effect and where to find it (I dont trust where it will find the code that will prob cause an error)
        //Sound Jump = LoadSound("GitHub\TrexRun\T-rexTest\JumpSFX.mp3");
        public gravity(float x, float y, float forceofgravity)
        {
            position = new Vector2(20, 500);
            jumps = new Vector2(0, forceofgravity);
        }
        public void update()
        {
            Applygravity();

            //Seems this can't be inside a while loop or the program will start and never load. How odd. - Neil
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && hasTouchedGround == true)
            {
                DoJump();
                hasTouchedGround = false;
            }
            position += velocity;

            // The "hasTouchedGround" Allows it to jump again on impact with the ground. - Neil
            // constrain  each frame
            float dynoY = position.Y;
            if (dynoY > 520)
            {
                position.Y = 520;
                velocity.Y = 0;
                hasTouchedGround = true;
            }


        }
        public void DrawDyno()
        {
            Raylib.DrawRectangleV(position, size, Color.DARKPURPLE);
        }
        public void DoJump()
        {
            //should play the sound every time we jump
            //PlaySound(Jump);
            Vector2 Jumpforce = new Vector2(0, -5);
            velocity = Jumpforce;
        }
        public void Applygravity()
        {
            velocity += jumps * Raylib.GetFrameTime();
        }
    }
}
