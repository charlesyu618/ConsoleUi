﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleUi
{
    public class Game
    {
        private readonly Snake snake = new Snake();
        private readonly Fruit fruit = new Fruit();
        private readonly Canvas canvas = new Canvas();
        private readonly Score score = new Score();
        private readonly Gamer gamer = new Gamer();

        private DateTime fruitTime = DateTime.Now;  // store the fruit time 

        private Point preFruit = new Point();   // store the location of previous fruit

        public bool GameOver { get; set; } = false;


        // Special fruit effects
        public bool OneMoreLife { get; set; } = false;  // One more life
        public bool ConstantSpeed { get; set; } = false;   // Constant speed

        // Whether the game is pause
        public bool GameIsPause { get; set; } = false;    // Press P to pause the game



        public Game() => Initialize();

        public void Initialize()
        {
            canvas.Draw();
            snake.Initialize(canvas);
            fruit.Spawn(canvas, snake, score);
            GameOver = false;
            score.Initialize();
        }

        public int Start()
        {
            while (!GameOver)
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    snake.Direction = Utility.ConvertDirectionFromKey(keyInfo, snake.Direction);

                    // If user press the P to pause game or start
                    if (keyInfo.Key == ConsoleKey.P)
                    {
                        GameIsPause = !GameIsPause;
                    }

                }

                // If the game is pause
                if (GameIsPause)
                {
                    Thread.Sleep(Settings.HeartBeatMilliseconds / 4);
                    continue;     // skip to next loop
                }



                // Snake touch itself --> End game
                if (snake.Tail.Contains(snake.Head))
                {
                    EndGame();
                    return score.Current;
                }
                // Snake touch the fruit --> Score increase
                else if (snake.Head == fruit.Location)
                {
                    preFruit = fruit.Location;
                    snake.Move(canvas, true, preFruit);
                    score.Current += fruit.Value;

                    // For special fruit
                    if (fruit.TypeValue == 8)   // One more life
                    {
                        OneMoreLife = true;
                        Console.Title = "One more live!";
                    }
                    else if (fruit.TypeValue == 9)
                    {
                        ConstantSpeed = true;
                        Console.Title = "Constant Speed";
                    }

                    // Fill that empty
                    preFruit = snake.Tail[0];
                    Utility.Write(" ", preFruit.X, preFruit.Y, Settings.Snake.HeadForeground, Settings.Snake.HeadForeground);

                    fruit.Spawn(canvas, snake, score);
                    fruitTime = DateTime.Now;   // Refresh the fruit time

                    Console.Title = $"Score: {score.Current}. Tail: {snake.Tail.Length}";   // Title shows the score
                }
                // Snake touch the edge --> End game
                else if (snake.ReachEdge == true)
                {
                    if (OneMoreLife != true)    // Check for the special fruit
                    {
                        EndGame();
                        return score.Current;
                    }
                    else
                    {
                        OneMoreLife = false;
                        snake.Move(canvas, false, preFruit);
                    }
                }
                else
                {
                    snake.Move(canvas, false, preFruit);
                }

                // The fruit's location will change
                if (score.Current > 20 && DateTime.Now - fruitTime > TimeSpan.FromSeconds(9 - fruit.Value))
                {
                    canvas.Erase(fruit.Location);
                    fruit.Spawn(canvas, snake, score);
                    fruitTime = DateTime.Now;
                }

                // Control the fresh rate for different stage
                if (score.Current < 20 && score.Current >= 0)
                {
                    Thread.Sleep(Settings.HeartBeatMilliseconds / 2);
                }
                else if (score.Current >= 20 && score.Current <= 40)
                {
                    Thread.Sleep(Settings.HeartBeatMilliseconds / 3);
                }
                else if (score.Current > 40 && score.Current <= 60)
                {
                    Thread.Sleep(Settings.HeartBeatMilliseconds / 5);
                }
                else if (ConstantSpeed == true)
                {
                    Thread.Sleep(Settings.HeartBeatMilliseconds / 3);
                }
                else
                {
                    Thread.Sleep(Settings.HeartBeatMilliseconds / 7);
                }
            }
            return score.Current;
        }

        private void EndGame()
        {
            GameOver = true;

            if (gamer.AskRestart())
            {
                Console.Clear();
                Initialize();
                Start();
            }
        }
    }
}