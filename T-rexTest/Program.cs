using Raylib_cs;
using System.Data;
using System.Numerics;

namespace T_rexTest
{
    internal class Program
    {
        //obstacles1 
        static Rectangle[] obstacle1 = new Rectangle[1];
        static Color obtaclecolor = Color.DARKGREEN;
        //obstacles 2
        static Rectangle[] obstacles2 = new Rectangle[1];
        static Color obtacle2color = Color.DARKGRAY;
        //obstacle 3
        static Rectangle[] birds = new Rectangle[5];
        static Color birdscolor = Color.BLACK;
        //map
        static Rectangle[] sky = new Rectangle[5];
        static Color skycolor = Color.WHITE;
        static Rectangle Base = new Rectangle(0, 545, 800, 55);
        static Color basecolor = Color.BROWN;
        static Rectangle[] baserandom = new Rectangle[8];
        static Color baserandomcolor = Color.DARKBROWN;
        //Public Void Gravity
        static gravity jumps;
        static Font FontDyno;

        static void Main(string[] args)
        { 
            Setup();
            while (!Raylib.WindowShouldClose())
            {
                Update();
            }
            Raylib.CloseWindow();
        }
        static void Setup()
        {
            float x = Raylib.GetScreenWidth();
            float y = Raylib.GetScreenHeight();
            float gravity = 6;
            jumps = new gravity(x,y , gravity);
            Raylib.InitWindow(800, 600, "T-rex");
            Raylib.SetTargetFPS(60);
            FontDyno = Raylib.LoadFont("../../../DynoFont.ttf");

        }
        static void Update()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SKYBLUE);
            
            DrawObstacles();
            speed();
            Drawmap();
            Font();
            collide();
            jumps.update();
            jumps.DrawDyno();
           
            Raylib.DrawFPS(700, 0);//POSITION DRAW FPS
            Raylib.EndDrawing();
        }

        static void Font()
        {
            //Console.WriteLine(Directory.GetCurrentDirectory());
            Raylib.DrawTextEx(FontDyno, "DYNO", new Vector2(10, 30), 40, 2, Color.DARKBLUE);
        }

        static void Drawmap()
        {
            //DrawBase
            Raylib.DrawRectangleRec(Base, basecolor);
            //DrawBase Texture
            for (int i = 0; i < baserandom.Length; i++)
            {
                Raylib.DrawRectangleRec(baserandom[i], baserandomcolor);
            }
            //Draw sky
            for (int i = 0; i < sky.Length; i++)
            {
                Raylib.DrawRectangleRec(sky[i], skycolor);
            }
        }
        static void DrawObstacles()
        {
            //DrawObstacle1
            for (int i = 0; i < obstacle1.Length; i++)
            {
                Raylib.DrawRectangleRec(obstacle1[i], obtaclecolor);
            }
            //DrawObstacle2
            for (int i = 0; i < obstacles2.Length; i++)
            {
                Raylib.DrawRectangleRec(obstacles2[i], obtacle2color);
            }
            //draw birds
            for (int i = 0; i < birds.Length; i++)
            {
                Raylib.DrawRectangleRec(birds[i], birdscolor);
            }
        }
        //set movement of objects
        static void speed()
        {
            Random random = new Random(2);
            int obstaclespeed = 4;
            int obtspeed2 = 3;
            for (int i = 0; i < obstacle1.Length; i++)
            {
                obstacle1[i].X -= obstaclespeed;

                if (obstacle1[i].X <= -obstacle1[i].Width)
                {
                    obstacle1[i] = new Rectangle(random.Next(860), 500, 30, 45);
                }
            }

            for (int i = 0; i < obstacles2.Length; i++)
            {
                obstacles2[i].X -= obtspeed2;
                if (obstacles2[i].X <= -obstacles2[i].Width)
                {
                    obstacles2[i] = new Rectangle(random.Next(860), 450, 35, 35);
                }
            }
            
            for (int i = 0; i < birds.Length ;i++)
            {
                birds[i].X -= obtspeed2;
                if (birds[i].X <= -birds[i].Width)
                {
                    birds[i] = new Rectangle(random.Next(850), i * 80, 20, 10);
                }
            }
            for (int i = 0; i < sky.Length; i++)
            {
                sky[i].X -= obtspeed2;
                if (sky[i].X <= -sky[i].Width)
                {
                    sky[i] = new Rectangle(random.Next(850), i * 60, 35, 25);
                }
            }

            for (int i = 0; i < baserandom.Length; i++)
            {
                baserandom[i].X -= obstaclespeed;
                if (baserandom[i].X <= -baserandom[i].Width)
                {
                    baserandom[i] = new Rectangle(random.Next(850), 550, 15, 15);
                }
            }
        }
        static void collide()
        {
            int obstaclespeed = 4;
            int obtspeed2 = 3;
            float obstacle1LeftEdge;
            float obstacle2LeftEdge;

            Vector2 position;
            position = new Vector2(20, 500);
            float playerX;
            float playerY;
            float playerRightEdge;
            bool doesTouchRight1;
            bool doesTouchRight2;

            //getting the x coordinate for obstacle 1
            for (int i = 0; i < obstacle1.Length; i++)
            {
                obstacle1LeftEdge = obstacle1[i].X;
                obstacle1LeftEdge -= obstaclespeed;
                playerX = position.X;
                playerY = position.Y;
                playerRightEdge = playerX + 30;
                //comparing the two coords
                doesTouchRight1 = playerRightEdge >= obstacle1LeftEdge;

                if (doesTouchRight1 == true)
                {
                    Raylib.DrawTextEx(FontDyno, "Woo!", new Vector2(100, 100), 40, 2, Color.DARKBLUE);
                }
            }

            //the x coordinate for obstacle 2
            for (int i = 0; i < obstacles2.Length; i++)
            {
                obstacle2LeftEdge = obstacles2[i].X;
                obstacle2LeftEdge -= obtspeed2;
                playerX = position.X;
                playerRightEdge = playerX + 30;
                //comparing the two coords
                doesTouchRight2 = playerRightEdge >= obstacle2LeftEdge;

                if (doesTouchRight2 == true)
                {
                    Raylib.DrawTextEx(FontDyno, "Keep Going!", new Vector2(400, 100), 40, 2, Color.DARKBLUE);
                }
                //the collision doesnt fully work, even when you jump over an obstacle it still says you hit it, since it doesnt make sense for it to say you hit something when you didnt, i put encouraging messages - Logan
            }
        }
    }
}