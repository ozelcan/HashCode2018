﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class GlobalObjects
    {
        public static int gridX;
        public static int gridY;
        public static int totalVehicles;
        public static int totalRides;
        public static int bonus;
        public static int totalSteps;
        public static int currentStep = 0;


        public static List<Ride> ride = new List<Ride>();
        public static List<Vehicle> vehicle = new List<Vehicle>();

        public static List<Ride> GetSortedRides(int x, int y)
        {
            int reachDistance = 0;
            int waitTurn = 0;

            foreach (var item in ride)
            {
                reachDistance = CalculateDistance(x, y, item.startX, item.startY);
                waitTurn = CalculateWaitTurn(item.earliestStart, reachDistance);

                item.score = reachDistance + waitTurn + item.distance;
            }

            List<Ride> sortedRides = ride.OrderBy(o=>o.score).ToList();

            return sortedRides;
        }

        private static int CalculateDistance(int x1, int y1, int x2, int y2)
        {
            return (Math.Abs(y2 - y1) + Math.Abs(x2 - x1));
        }

        private static int CalculateWaitTurn(int earliestStep, int ReachDist)
        {
            return (earliestStep - (ReachDist + currentStep));
        }

    }

    public class Ride
    {
        public int Id;
        public int startX;
        public int startY;
        public int destX;
        public int destY;
        public int earliestStart;
        public int latestFinish;
        public bool isAssigned = false;
        public int distance;
        public int score;

        public void CalculateDistance()
        {
            distance = (Math.Abs(startX - destX) + Math.Abs(startY - destY));
        }
    }
    public class Vehicle
    {
        public int currentX = 0;
        public int currentY = 0;
        public bool isBusy = false;
        public List<int> completedRides = new List<int>();
        public int totalTurnLeftToTarget = 0;
        public Ride currentRide;

        public void AssignRide(Ride ride) { }

        public void CompleteRide(Ride ride) { }

        public bool IsRideAvailable(Ride ride) { return false; }

        public void Move()
        {
            totalTurnLeftToTarget--;
        }
    }

}
