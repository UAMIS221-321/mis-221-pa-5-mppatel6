using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class WorkoutUtility
    {
        private Workout[] workouts;
        public WorkoutUtility(Workout[] workouts){
            this.workouts = workouts;
        }

        public Workout[] availableWorkout = new Workout[100];

        public void GetChest(){
            StreamReader inFile = new StreamReader("chest.txt");

            Workout.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                workouts[Workout.GetCount()] = new Workout(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
                Workout.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void GetBack(){
            StreamReader inFile = new StreamReader("back.txt");

            Workout.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                workouts[Workout.GetCount()] = new Workout(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
                Workout.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void GetLegs(){
            StreamReader inFile = new StreamReader("legs.txt");

            Workout.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                workouts[Workout.GetCount()] = new Workout(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
                Workout.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void GetArms(){
            StreamReader inFile = new StreamReader("arms.txt");

            Workout.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                workouts[Workout.GetCount()] = new Workout(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
                Workout.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void GetShoulder(){
            StreamReader inFile = new StreamReader("shoulders.txt");

            Workout.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                workouts[Workout.GetCount()] = new Workout(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
                Workout.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void ChestCompoundBodyBuilding(){
            GetChest();
            int random = GetOpen(Workout.GetCount(), "Compound");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("4-6");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveChest();

            Console.WriteLine(workouts[found].ToString());
            
        }
        public void BackCompoundBodyBuilding(){
            GetBack();
            int random = GetOpen(Workout.GetCount(), "Compound");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("4-6");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveBack();

            Console.WriteLine(workouts[found].ToString());
            
        }
        public void QuadCompoundBodyBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "QuadComp");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("4-6");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void HamstringCompoundBodyBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "HamstringComp");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("4-6");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void ShoulderCompoundBodyBuilding(){
            GetShoulder();
            int random = GetOpen(Workout.GetCount(), "Compound");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("4-6");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveShoulders();

            Console.WriteLine(workouts[found].ToString());
        }
        public void BicepBodyBuilding(){
            GetArms();
            int random = GetOpen(Workout.GetCount(), "Bicep");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("6-10");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveArms();

            Console.WriteLine(workouts[found].ToString());
        }
        public void TricepBodyBuilding(){
            GetArms();
            int random = GetOpen(Workout.GetCount(), "Tricep");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("6-10");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveArms();

            Console.WriteLine(workouts[found].ToString());
        }
        public void ChestAccessoryBodyBuilding(){
            GetChest();
            int random = GetOpen(Workout.GetCount(), "Accessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("8-12");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveChest();

            Console.WriteLine(workouts[found].ToString());
        }
        public void BackAccessoryBodyBuilding(){
            GetBack();
            int random = GetOpen(Workout.GetCount(), "Accessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("8-12");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveBack();

            Console.WriteLine(workouts[found].ToString());
        }
        public void QuadAccessoryBodyBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "QuadAccessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("8-12");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void HamstringAccessoryBodyBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "HamstringAccessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("8-12");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void ShoulderAccessoryBodyBuilding(){
            GetShoulder();
            int random = GetOpen(Workout.GetCount(), "Accessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("8-12");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveShoulders();

            Console.WriteLine(workouts[found].ToString());
        }
        public void ChestCompoundIntensityBuilding(){
            GetChest();
            int random = GetOpen(Workout.GetCount(), "Compound");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("8-10");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveChest();

            Console.WriteLine(workouts[found].ToString());
        }
        public void BackCompoundIntensityBuilding(){
            GetBack();
            int random = GetOpen(Workout.GetCount(), "Compound");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("8-10");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveBack();

            Console.WriteLine(workouts[found].ToString());
        }
        public void QuadCompoundIntensityBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "QuadComp");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("6-8");   
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void HamstringCompoundIntensityBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "QuadComp");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("6-8");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void ShoulderCompoundIntensityBuilding(){
            GetShoulder();
            int random = GetOpen(Workout.GetCount(), "Compound");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("6-8");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveShoulders();

            Console.WriteLine(workouts[found].ToString());
        }
        public void BicepIntensityBuilding(){
            GetArms();
            int random = GetOpen(Workout.GetCount(), "Bicep");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("6-8");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveArms();

            Console.WriteLine(workouts[found].ToString());
        }
        public void TricepIntensityBuilding(){
            GetArms();
            int random = GetOpen(Workout.GetCount(), "Tricep");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("6-8");
            workouts[found].SetRestTime("1-1:30");
            workouts[found].SetStatus("Used");
            SaveArms();

            Console.WriteLine(workouts[found].ToString());
        }
        public void ChestAccessoryIntensityBuilding(){
            GetChest();
            int random = GetOpen(Workout.GetCount(), "Accessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("12-15");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveChest();

            Console.WriteLine(workouts[found].ToString());
        }
        public void BackAccessoryIntensityBuilding(){
            GetBack();
            int random = GetOpen(Workout.GetCount(), "Accessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("12-15");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveBack();

            Console.WriteLine(workouts[found].ToString());
        }
        public void QuadAccessoryIntensityBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "QuadAccessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("12-15");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void HamstringAccessoryIntensityBuilding(){
            GetLegs();
            int random = GetOpen(Workout.GetCount(), "HamstringAccessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("12-15");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveLegs();

            Console.WriteLine(workouts[found].ToString());
        }
        public void ShoulderAccessoryIntensityBuilding(){
            GetShoulder();
            int random = GetOpen(Workout.GetCount(), "Accessory");
            int found = FindWorkout(availableWorkout[random].GetWorkout());
            workouts[found].SetRepRange("12-15");
            workouts[found].SetRestTime("1 minute");
            workouts[found].SetStatus("Used");
            SaveShoulders();

            Console.WriteLine(workouts[found].ToString());
        }
        public void SaveChest(){
            StreamWriter outFile = new StreamWriter("chest.txt");
            for(int i = 0; i < Workout.GetCount(); i++){
                outFile.WriteLine(workouts[i].ToFile());
            }
            outFile.Close();
        }
        public void SaveBack(){
            StreamWriter outFile = new StreamWriter("back.txt");
            for(int i = 0; i < Workout.GetCount(); i++){
                outFile.WriteLine(workouts[i].ToFile());
            }
            outFile.Close();
        }
        public void SaveLegs(){
            StreamWriter outFile = new StreamWriter("legs.txt");
            for(int i = 0; i < Workout.GetCount(); i++){
                outFile.WriteLine(workouts[i].ToFile());
            }
            outFile.Close();
        }
        public void SaveArms(){
            StreamWriter outFile = new StreamWriter("arms.txt");
            for(int i = 0; i < Workout.GetCount(); i++){
                outFile.WriteLine(workouts[i].ToFile());
            }
            outFile.Close();
        }
        public void SaveShoulders(){
            StreamWriter outFile = new StreamWriter("shoulders.txt");
            for(int i = 0; i < Workout.GetCount(); i++){
                outFile.WriteLine(workouts[i].ToFile());
            }
            outFile.Close();
        }
        public void ResetChest(){
            for(int i = 0; i < Workout.GetCount(); i++){
                workouts[i].SetStatus("Open");
            }
            SaveChest();
        }
        public void ResetBack(){
            for(int i = 0; i < Workout.GetCount(); i++){
                workouts[i].SetStatus("Open");
            }
            SaveBack();
        }
        public void ResetLegs(){
            for(int i = 0; i < Workout.GetCount(); i++){
                workouts[i].SetStatus("Open");
            }
            SaveLegs();
        }
        public void ResetArms(){
            for(int i = 0; i < Workout.GetCount(); i++){
                workouts[i].SetStatus("Open");
            }
            SaveArms();
        }
        public void ResetShoulders(){
            for(int i = 0; i < Workout.GetCount(); i++){
                workouts[i].SetStatus("Open");
            }
            SaveShoulders();
        }
        public int GetOpen(int count, string searchType)
        {
            //Workout[] availableWorkout = new Workout[100];
            int avCount = 0;

            for(int i = 0; i < count; i++)
            {
                if(workouts[i].GetStatus() == "Open"){
                    if(workouts[i].GetWorkoutType() == searchType){
                        availableWorkout[avCount] = workouts[i];
                        avCount++;
                    }
                }
            }

            Random rnd = new Random();
            int random = 0;
            random = rnd.Next(0, avCount);
            return random;
        }
        public int FindWorkout(string searchVal){
            for(int i = 0; i < Workout.GetCount(); i++){
                if(workouts[i].GetWorkout() == searchVal){
                    return i;
                }
            }

            return -1;
        }
    }
}