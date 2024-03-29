﻿/* A level has obstacles, and a frequency at which the obstacles are sent */
using System.Collections.Generic;
using UnityEngine;

internal class Level
{
    public Stack<Obstacle> Obstacles; // The obstacle the user will have to avoid
    public double Latency; // The latency between two of the obstacles
    public bool Infinite;

    public Level(Stack<Obstacle> obstacles, double latency = 5)
    {
        if (obstacles != null)
            Obstacles = obstacles;

        Latency = latency;
    }

    public Level(double latency)
    {
        Infinite = true;
        Obstacles = new Stack<Obstacle>();
        Latency = latency;
    }

    public static Level CreateLevel0()
    {
        double latency = 0;
        int levelLength = 1;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel1()
    {
        double latency = 10;
        int levelLength = 1;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            obstacles.Push(new Obstacle(2, 2, 4));
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel2()
    {
        double latency = 9;
        int levelLength = 8;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            int width = UnityEngine.Random.Range(2, 4);
            int height = Random.Range(2, 4);
            int y = 4;

            obstacles.Push(new Obstacle(width, height, y));
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel3()
    {
        double latency = 8;
        int levelLength = 10;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            int width = UnityEngine.Random.Range(2, 4);
            int height = Random.Range(2, 4);
            int y = Random.Range(3, 5); // fkn random

            obstacles.Push(new Obstacle(width, height, y));
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel4()
    {
        double latency = 7;
        int levelLength = 12;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            int width = Random.Range(1, 4);
            int height = Random.Range(1, 4);
            int y = Random.Range(2, 5);

            obstacles.Push(new Obstacle(width, height, y));
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel5()
    {
        double latency = 7;
        int levelLength = 15;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            int width = Random.Range(1, 6);
            int height = Random.Range(1, 4);
            int y = Random.Range(1, 5);

            obstacles.Push(new Obstacle(width, height, y));
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel6()
    {
        double latency = 7;
        int levelLength = 20;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            int width = Random.Range(1, 8);
            int height = Random.Range(1, 5);
            int y = 5 - height;

            obstacles.Push(new Obstacle(width, height, y)); 
        }
        
        return new Level(obstacles, latency);
    }

    public static Level CreateEndlessMode()
    {
        return new Level(10);
    }

    public static Level CreateLevel(int index)
    {
        Game.CurrentLevel = index;

        return index switch
        {   
            0 => CreateLevel0(),
            1 => CreateLevel1(),
            2 => CreateLevel2(),
            3 => CreateLevel3(),
            4 => CreateLevel4(),
            5 => CreateLevel5(),
            6 => CreateLevel6(),
            _ => CreateEndlessMode(),
        };
    }
}
