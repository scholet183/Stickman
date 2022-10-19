﻿using System;
using System.Text;
using System.Threading.Tasks;

namespace Stickman
{
    internal class Stickman
    {
        public String name = "";
        public static String space = " ";
        public static String head = "  0";
        public static String body1 = " !T!";
        public static String body2 = "//J";
        public static String legs1 = "  |";
        public static String legs2 = "  |\\";

        public Stickman(String name)
        {
            this.name = name;
        }
        public enum State
        {
            Chilling,
            Walking,
            Running,
            Exhausted
        }
        public enum Action
        {
            Chill,
            Walk,
            Run,
            Exhaust
        }

        private State state = State.Chilling;
        
        public State CurrentState { get { return state; } }

        public void TakeAction(Action action)
        {
            state = (state, action) switch
            {
                (State.Chilling, Action.Walk) => State.Walking,
                (State.Chilling, Action.Run) => State.Running,
                (State.Walking, Action.Run) => State.Running,
                (State.Walking, Action.Chill) => State.Chilling,
                (State.Walking, Action.Exhaust) => State.Exhausted,
                (State.Running, Action.Walk) => State.Walking,
                (State.Running, Action.Chill) => State.Chilling,
                (State.Running, Action.Exhaust) => State.Exhausted,
                (State.Exhausted, Action.Chill) => State.Chilling,
                _ => state
            };
        }
        public static int handling(int counter,State x)
        {
            String legs;
            String body;
            Console.WriteLine();
            switch (x)
            {
                case State.Chilling:
                    if (counter % 2 == 0) { Console.WriteLine(space + "    zZ"); }
                    else { Console.WriteLine(); }
                    Console.WriteLine(space + head);
                    Console.WriteLine(space + body1);
                    Console.WriteLine(space + legs1);
                    break;
                case State.Walking:
                    if (counter % 2 == 0) { legs = legs1; }
                    else { legs = legs2; }
                    Console.WriteLine();
                    Console.WriteLine(space + head);
                    Console.WriteLine(space + body1);
                    Console.WriteLine(space + legs);
                    space += " ";
                    break;
                case State.Running:
                    if (counter % 2 == 0) { legs = legs1; body = body2; }
                    else { legs = legs2; body = body1; }
                    Console.WriteLine();
                    Console.WriteLine(space + head);
                    Console.WriteLine(space + body);
                    Console.WriteLine(space + legs);
                    space += " ";
                    break;
                case State.Exhausted:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(space + "   zZ");
                    Console.WriteLine(space + ">--o");
                    break;
            }
            return space.Length;
        }
    }
}