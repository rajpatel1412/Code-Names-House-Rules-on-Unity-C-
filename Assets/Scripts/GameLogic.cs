using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;
using TMPro;

public class GameLogic : MonoBehaviour
{
    private string[] sampleWords = {"Acne", "Acre", "Addendum", "Advertise", "Aircraft", "Aisle", "Alligator", "Alphabetize", "America", "Ankle", "Apathy", "Applause", "Applesauce", "Application", "Archaeologist", 
    "Aristocrat", "Arm", "Armada", "Asleep", "Astronaut", "Athlete", "Atlantis", "Aunt", "Avocado", "Baby-Sitter", "Backbone", "Bag", "Baguette", "Bald", "Balloon", "Banana", "Banister", "Baseball", "Baseboards", 
    "Basketball", "Bat", "Battery", "Beach", "Beanstalk", "Bedbug", "Beer", "Beethoven", "Belt", "Bib", "Bicycle", "Big", "Bike", "Billboard", "Bird", "Birthday", "Bite", "Blacksmith", "Blanket", "Bleach", "Blimp", 
    "Blossom", "Blueprint", "Blunt", "Blur", "Boa", "Boat", "Bob", "Bobsled", "Body", "Bomb", "Bonnet", "Book", "Booth", "Bowtie", "Box", "Boy", "Brainstorm", "Brand", "Brave", "Bride", "Bridge", "Broccoli", "Broken", 
    "Broom", "Bruise", "Brunette", "Bubble", "Buddy", "Buffalo", "Bulb", "Bunny", "Bus", "Buy", "Cabin", "Cafeteria", "Cake", "Calculator", "Campsite", "Can", "Canada", "Candle", "Candy", "Cape", "Capitalism", "Car", 
    "Cardboard", "Cartography", "Cat", "Cd", "Ceiling", "Cell", "Century", "Chair", "Chalk", "Champion", "Charger", "Cheerleader", "Chef", "Chess", "Chew", "Chicken", "Chime", "China", "Chocolate", "Church", "Circus", 
    "Clay", "Cliff", "Cloak", "Clockwork", "Clown", "Clue", "Coach", "Coal", "Coaster", "Cog", "Cold", "College", "Comfort", "Computer", "Cone", "Constrictor", "Continuum", "Conversation", "Cook", "Coop", "Cord", 
    "Corduroy", "Cot", "Cough", "Cow", "Cowboy", "Crayon", "Cream", "Crisp", "Criticize", "Crow", "Cruise", "Crumb", "Crust", "Cuff", "Curtain", "Cuticle", "Czar","Dad", "Dart", "Dawn", "Day", "Deep", "Defect", "Dent", 
    "Dentist", "Desk", "Dictionary", "Dimple", "Dirty", "Dismantle", "Ditch", "Diver", "Doctor", "Dog", "Doghouse", "Doll", "Dominoes", "Door", "Dot", "Drain", "Draw", "Dream", "Dress", "Drink", "Drip", "Drums", "Dryer", 
    "Duck", "Dump","Dunk", "Dust", "Ear", "Eat", "Ebony", "Elbow", "Electricity", "Elephant", "Elevator", "Elf", "Elm", "Engine", "England", "Ergonomic", "Escalator", "Eureka", "Europe", "Evolution", "Extension", "Eyebrow", 
    "Fan", "Fancy", "Fast", "Feast", "Fence", "Feudalism", "Fiddle", "Figment", "Finger", "Fire", "First", "Fishing", "Fix", "Fizz", "Flagpole", "Flannel", "Flashlight", "Flock", "Flotsam", "Flower", "Flu", "Flush", "Flutter",
    "Fog", "Foil", "Football", "Forehead", "Forever", "Fortnight", "France", "Freckle", "Freight", "Fringe", "Frog", "Frown", "Gallop", "Game", "Garbage", "Garden", "Gasoline", "Gem", "Ginger", "Gingerbread", "Girl", "Glasses",
    "Goblin", "Gold", "Goodbye", "Grandpa", "Grape", "Grass", "Gratitude", "Gray", "Green", "Guitar", "Gum", "Gumball", "Hair", "Half", "Handle", "Handwriting", "Hang", "Happy", "Hat", "Hatch", "Headache", "Heart", "Hedge", 
    "Helicopter","Hem", "Hide", "Hill", "Hockey", "Homework", "Honk", "Hopscotch","Horse", "Hose", "Hot", "House", "Houseboat", "Hug", "Humidifier", "Hungry", "Hurdle", "Hurt", "Hut", "Ice", "Implode", "Inn", "Inquisition", 
    "Intern", "Internet", "Invitation", "Ironic", "Ivory", "Ivy", "Jade", "Japan", "Jeans", "Jelly", "Jet", "Jig", "Jog", "Journal", "Jump", "Key", "Killer", "Kilogram", "King", "Kitchen", "Kite", "Knee", "Kneel", "Knife", 
    "Knight", "Koala", "Lace", "Ladder", "Ladybug", "Lag", "Landfill", "Lap", "Laugh", "Laundry", "Law", "Lawn", "Lawnmower", "Leak", "Leg", "Letter", "Level", "Lifestyle", "Ligament", "Light", "Lightsaber", "Lime", "Lion", 
    "Lizard", "Log", "Loiterer", "Lollipop", "Loveseat", "Loyalty", "Lunch", "Lunchbox", "Lyrics", "Machine", "Macho", "Mailbox", "Mammoth", "Mark", "Mars", "Mascot", "Mast", "Matchstick", "Mate", "Mattress", "Mess", "Mexico", 
    "Midsummer", "Mine", "Mistake", "Modern", "Mold", "Mom", "Monday", "Money", "Monitor", "Monster", "Mooch", "Moon", "Mop", "Moth", "Motorcycle", "Mountain", "Mouse", "Mower", "Mud", "Music", "Mute", "Nature", "Negotiate", 
    "Neighbor", "Nest","Neutron", "Niece", "Night", "Nightmare", "Nose", "Oar", "Observatory", "Office", "Oil", "Old", "Olympian", "Opaque", "Opener", "Orbit", "Organ", "Organize", "Outer", "Outside", "Ovation", "Overture", 
    "Pail", "Paint", "Pajamas", "Palace", "Pants", "Paper", "Park", "Parody", "Party", "Password", "Pastry", "Pawn", "Pear", "Pen", "Pencil", "Pendulum", "Penis", "Penny", "Pepper", "Personal", "Philosopher", "Phone", 
    "Photograph", "Piano", "Picnic", "Pigpen", "Pillow", "Pilot", "Pinch", "Ping", "Pinwheel", "Pirate", "Plaid", "Plan", "Plank", "Plate", "Platypus", "Playground", "Plow", "Plumber", "Pocket", "Poem", "Point", "Pole", "Pomp", 
    "Pong", "Pool", "Popsicle", "Population", "Portfolio", "Positive", "Post", "Princess", "Procrastinate", "Protestant", "Psychologist", "Publisher", "Punk", "Puppet", "Puppy", "Push", "Puzzle", "Quarantine", "Queen", 
    "Quicksand", "Quiet", "Race", "Radio", "Raft", "Rag", "Rainbow", "Rainwater", "Random", "Ray", "Recycle", "Red", "Regret", "Reimbursement", "Retaliate", "Rib", "Riddle", "Rim", "Rink", "Roller", "Room", "Rose", "Round", 
    "Roundabout", "Rung", "Runt", "Rut", "Sad", "Safe", "Salmon", "Salt", "Sandbox", "Sandcastle", "Sandwich", "Sash", "Satellite", "Scar", "Scared", "School", "Scoundrel", "Scramble", "Scuff", "Seashell", "Season", "Sentence", 
    "Sequins", "Set", "Shaft", "Shallow", "Shampoo", "Shark", "Sheep", "Sheets", "Sheriff", "Shipwreck", "Shirt", "Shoelace", "Short", "Shower", "Shrink", "Sick", "Siesta", "Silhouette", "Singer", "Sip", "Skate", "Skating", 
    "Ski", "Slam", "Sleep", "Sling", "Slow", "Slump", "Smith", "Sneeze", "Snow", "Snuggle", "Song", "Space", "Spare", "Speakers", "Spider", "Spit", "Sponge", "Spool", "Spoon", "Spring", "Sprinkler", "Spy", "Square", "Squint", 
    "Stairs", "Standing", "Star", "State", "Stick", "Stockholder", "Stoplight", "Stout", "Stove", "Stowaway", "Straw", "Stream", "Streamline", "Stripe", "Student", "Sun", "Sunburn", "Sushi", "Swamp", "Swarm", "Sweater", 
    "Swimming", "Swing", "Tachometer", "Talk", "Taxi", "Teacher", "Teapot", "Teenager", "Telephone", "Ten", "Tennis", "Thief", "Think", "Throne", "Through", "Thunder", "Tide", "Tiger", "Time", "Tinting", "Tiptoe", "Tiptop", 
    "Tired", "Tissue", "Toast", "Toilet", "Tool", "Toothbrush", "Tornado", "Tournament", "Tractor", "Train", "Trash", "Treasure", "Tree", "Triangle", "Trip", "Truck", "Tub", "Tuba", "Tutor", "Television", "Twang", "Twig", 
    "Twitterpated", "Type", "Unemployed", "Upgrade", "Vest", "Vision", "Wag", "Water", "Watermelon", "Wax", "Wedding", "Weed", "Welder", "Whatever", "Wheelchair", "Whiplash", "Whisk", "Whistle", "White", "Wig", "Will", 
    "Windmill", "Winter", "Wish", "Wolf", "Wool", "World", "Worm", "Wristwatch", "Yardstick", "Zamboni", "Zen", "Zero", "Zipper", "Zone", "Zoo"};

    private string[] gameWords = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
    /*private string[]
    private string[]
    private string[]*/

    public TextMeshProUGUI[] cardText;
    public TextMeshProUGUI redTurn;
    public TextMeshProUGUI blueTurn;
    public TextMeshProUGUI redWin;
    public TextMeshProUGUI blueWin;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI redCardsLeft;
    public TextMeshProUGUI blueCardsLeft;
    public GameObject[] cards;
    public GameObject[] SpyMasterCard;
    public GameObject redTurnBackground;
    public GameObject blueTurnBackground;
    private int[] cardColour = {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
    public Button play;
    public Button quit;

    private int toss;
  
    // Start is called before the first frame update
    void Start()
    {
        blueWin.enabled = false;
        redWin.enabled = false;
        gameOver.enabled = false;
        toss = Random.Range(0, 2);
        //Debug.Log(toss);
        if(toss == 1) 
        {
            //blueTurn.enabled = true;
            blueTurnBackground.SetActive(true);
            redTurnBackground.SetActive(false);
            redTurn.enabled = false;
            blueCardsLeft.SetText("9");
            redCardsLeft.SetText("8");
            for(int i = 0; i < 9; i ++)
            {
                bool k = true;
                while(k)
                {
                    int rand = Random.Range(0, 25);
                    if(cardColour[rand] == -1)
                    {
                        cardColour[rand] = 1; //blue
                        k = false;
                    }
                }
                
            }
            for(int i = 0; i < 8; i ++)
            {
                bool k = true;
                while(k)
                {
                    int rand = Random.Range(0, 25);
                    if(cardColour[rand] == -1)
                    {
                        cardColour[rand] = 0; // red
                        k = false;
                    }
                }
                
            }
            for(int i = 0; i < 7; i ++)
            {
                bool k = true;
                while(k)
                {
                    int rand = Random.Range(0, 25);
                    if(cardColour[rand] == -1)
                    {
                        cardColour[rand] = 2; // green
                        k = false;
                    }
                }
                
            }
            for(int i = 0; i < 25; i++)
            {
                if(cardColour[i] == -1)
                {
                    cardColour[i] = 4;
                    break;
                }
                    
            }
                
        }
        else
        {
            blueTurn.enabled = false;
            //redTurn.enabled = true;
            blueTurnBackground.SetActive(false);
            redTurnBackground.SetActive(true);
            blueCardsLeft.SetText("8");
            redCardsLeft.SetText("9");
            for(int i = 0; i < 9; i ++)
            {
                bool k = true;
                while(k)
                {
                    int rand = Random.Range(0, 25);
                    if(cardColour[rand] == -1)
                    {
                        cardColour[rand] = 0; //red
                        k = false;
                    }
                }
                
            }
            for(int i = 0; i < 8; i ++)
            {
                bool k = true;
                while(k)
                {
                    int rand = Random.Range(0, 25);
                    if(cardColour[rand] == -1)
                    {
                        cardColour[rand] = 1; // blue
                        k = false;
                    }
                }
                
            }
            for(int i = 0; i < 7; i ++)
            {
                bool k = true;
                while(k)
                {
                    int rand = Random.Range(0, 25);
                    if(cardColour[rand] == -1)
                    {
                        cardColour[rand] = 2; // green
                        k = false;
                    }
                }
                
            }
            for(int i = 0; i < 25; i++)
            {
                if(cardColour[i] == -1)
                {
                    cardColour[i] = 4;
                    break;
                }
                    
            }
        }
        for(int i = 0; i < 25; i++)
        { 
            bool k = true;
            while(k) 
            {
                int rand = Random.Range(0, sampleWords.Length);
                if(System.Array.IndexOf(gameWords, sampleWords[rand]) == -1) 
                {
                    gameWords[i] = sampleWords[rand];
                    k = false;
                }
            }
            cardText[i].SetText(gameWords[i]);
            if(cardColour[i] == 0) //red
            {
                SpyMasterCard[i].transform.GetChild(3).gameObject.SetActive(true);
            }
            else if(cardColour[i] == 1) // blue
            {
                SpyMasterCard[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else if(cardColour[i] == 2) //green
            {
                SpyMasterCard[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            else // black
            {
                SpyMasterCard[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            //Debug.Log(gameWords[i]); 
            //Debug.Log(cardColour[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
         
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.name);
                int x = System.Array.IndexOf(cards, hit.transform.gameObject);
                Debug.Log(x);
                if( x != -1) 
                {
                    if(cardColour[x] == 0) // red
                    {
                        cards[x].transform.GetChild(3).gameObject.SetActive(true);
                        redCardsLeft.SetText((int.Parse(redCardsLeft.GetParsedText()) - 1).ToString());
                        
                    }
                    else if(cardColour[x] == 1) // blue
                    {
                        cards[x].transform.GetChild(1).gameObject.SetActive(true);
                        blueCardsLeft.SetText((int.Parse(blueCardsLeft.GetParsedText()) - 1).ToString());
                        
                    }
                    else if(cardColour[x] == 2) // green
                    {
                        cards[x].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else // black
                    {
                        cards[x].transform.GetChild(2).gameObject.SetActive(true);
                        gameOver.enabled = true;   
                    }
                }
            }
        }
        if(redCardsLeft.GetParsedText() == "0")
        {
            redWin.enabled = true;
        }    
        if(blueCardsLeft.GetParsedText() == "0")
        {
            blueWin.enabled = true;
        } 
    }
}
///usr/local/share/dotnet/dotnet