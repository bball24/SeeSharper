using PointClass.LanguageFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.FourSwords
{
    class RandomAsideAboutNamedArguments
    {
        public void HideUI(bool hidden, bool hideChildren)
        {
            //...
        }

        public void UsageOfHideUI()
        {
            // Hard to understand call, what does the true and false mean?
            HideUI(true, false);

            // More clear on what is going on
            HideUI(true, hideChildren: false);

            // A little more verbose, but also possibly useful for other functions.
            HideUI(hidden: true, hideChildren: false);

            // Throws a compiler error. After you name an argument, all arguments after must
            // be named as well.
            HideUI(hidden: true, false);
        }
    }

    class FirstLinqQueries
    {
        // Will be lazy loaded, meaning that the list will only be initialized after
        // a line of code tries to access this variable.
        static readonly List<PlayerData> players = new List<PlayerData>()
        {
            // List initializer syntax. We can add objects to the list here.
            new PlayerData() { name = "Mark", level = 9001, id = 0, role = Role.Admin },
            new PlayerData() { name = "Kyle", level = 40, id = 0, role = Role.Tank },
            new PlayerData() { name = "Logan", level = 36, id = 0, role = Role.Warrior },
            new PlayerData() { name = "Trevor", level = 18, id = 0, role = Role.Mage },
            new PlayerData() { name = "Denton", level = 1, id = 0, role = Role.Unassigned },
        };

        // Will be lazy loaded
        // This expression will not be called until the first time someone
        // accesses maxLevelAssassins.
        //
        // Note: if new PlayerData is added to the players list, maxLevelAssassins will
        // not update to reflect those changes. If you want this, use the getter property
        // below
        static readonly List<string> maxLevelAssassins = (from player in players
                                                          let tuple = new Tuple<int, string>(player.id, player.name)
                                                          where player.level == PlayerData.MAX_LEVEL &&
                                                                player.role == Role.Assassin
                                                          orderby player.name
                                                          select player.name
                                                          ).ToList();

        // C# 6.0+ getter only property
        static List<string> MaxLevelAssassins_SearchesThePlayersListEveryTimeThisIsCalled =>
            (from player in players
             where player.level == PlayerData.MAX_LEVEL &&
                   player.role == Role.Assassin
             orderby player.name
             select player.name
            ).ToList();

        // C# 5.0 and below (Unity is C# 4.0)
        static List<string> MaxLevelAssassins_SameAsAboveButUsingOlderSyntax
        {
            get
            {
                return (from player in players
                        where player.level == PlayerData.MAX_LEVEL &&
                              player.role == Role.Assassin
                        orderby player.name
                        select player.name
                       ).ToList();
            }
        }

        public void MyFirstLinqQuery()
        {
            List<Point> pointList = new List<Point>
            {
                new Point { X = 0, Y = 0 },
                new Point { X = 0, Y = 5 },
                new Point { X = 5, Y = 0 },
                new Point { X = 5, Y = 5 },

                // A single point can technically be constructed many different ways:
                new Point(10, 10),
                new Point(x: 10, y: 10),
                new Point{X = 10, Y = 10},
                new Point(10) {Y = 10},
                new Point(x: 10) {Y = 10},
                new Point() {X = 10, Y = 10},

                // Don't use the ones below, they are only shown as example and will only confuse
                // the person reading your code. Multiple declarations of what X or Y should be is
                // definitely bad practice!
                new Point(10) {X = 10, Y = 10},
                new Point(x: 10) {X = 10, Y = 10},
                new Point(10, y: 10) {X = 10, Y = 10},
                new Point(10, 10) { X = 10, Y = 10 },
                new Point(x: 10, y: 10) { X = 10, Y = 10 },

                // You can also swap the named arguments. This isn't recommended.
                new Point(y: 10, x: 10),
                //        ^      ^

                // You can also skip over the arguments you want to keep as their default values
                new Point(y: 10),
            };

            Point myPosition = new Point(2, 3);

            double shortestDistance = double.MaxValue;
            int closestIndex = 0;
            for (int i = 0; i < pointList.Count; i++)
            {
                double currentDistance = myPosition.DistanceFrom(pointList[i]);
                if (currentDistance < shortestDistance)
                {
                    shortestDistance = currentDistance;
                    closestIndex = i;
                }
            }
            Console.WriteLine($"Closest Point: {pointList[closestIndex]}");

            Point closestPoint = (from point in pointList
                                  let magnitude = point.DistanceFrom(new Point(0, 0))
                                  orderby magnitude
                                  select point).First();

            Console.WriteLine($"Closest Point: {closestPoint}");

            // The different LINQ commands are as follows:
            // From:    Grabs a variable from an IEnumerable (nearly all Collection/Data Structure types: List, Dictionary, LinkedList, etc)
            //          from point in points
            //
            // Let:     Assigns a variable
            //          let magnitude = point.DistanceFrom(myPosition)
            //
            // Join:    This one is a bit more convoluted. I'm just going to leave a linq to the documentation:
            //          https://msdn.microsoft.com/en-us/library/bb311040.aspx
            //
            // Where:   The condition that determines whether or not to include this value in the returned data
            //          where magnitude > 50
            //
            // Orderby: The order to sort the objects in. By default the objects are sorted in ascending order.
            //          orderby magnitude
            //
            // Select:  What you want to select from the object. It could be the object itself, one of it's fields, or even something unrelated
            //          select point


            List<string> namesOfMaxLevelAssassins = (from player in players
                                                     let tuple = new Tuple<int, string>(player.id, player.name)
                                                     where player.level == PlayerData.MAX_LEVEL &&
                                                           player.role == Role.Assassin
                                                     orderby player.name
                                                     select player.name
                                                     ).ToList();
        }
    }

    // [System.Flags] is an attribute that tells the compiler you intend to use
    // this enum as a bit array. When printing out the values of an enum that is
    // (
    [System.Flags]
    public enum Role
    {
        Unassigned = 0,
        Healer = 1 << 0,
        Tank = 1 << 1,
        Warrior = 1 << 2,
        Mage = 1 << 3,
        Assassin = 1 << 4,
        Thief = 1 << 5,
        Warlock = 1 << 6,
        // Again, the trailiing comma after the last item can be ommitted.
        Admin = 1 << 7,
    }

    // Structs are passed by value and stored on the stack (or in place in arrays/data structures).
    // They cannot inherit from other objects and it's recommended they shouldn't be longer than 4 fields.
    public struct PlayerData
    {
        // Constants, Functions, and properties can still exist within structs.
        // Constants can have their value's assigned to, but all other variables cannot have a default value
        public const int MAX_LEVEL = 40;

        // The commented out line below would throw a compiler error. 
        // The name's default value should be assigned within the constructor.
        //public string name = "Unnamed";

        public string name;
        public int id;
        public int level;
        public Role role;
    }
}
