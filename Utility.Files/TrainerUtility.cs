using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }
        public void GetAllTrainersFromFile(){
            StreamReader inFile = new StreamReader("trainer.txt");
            
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], bool.Parse(temp[4]));
                Trainer.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void AddTrainer(){
            Trainer myTrainer = new Trainer();
            myTrainer.SetID();
            System.Console.WriteLine("Please enter the trainers name:");
            myTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainers mailing address:");
            myTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainers email address:");
            myTrainer.SetEmailAddress(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();

            Save();
        }
        public int Find(int searchVal){
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainers[i].GetID() == searchVal){
                    return i;
                }
            }

            return -1;
        }
        public void Save(){
            StreamWriter outFile = new StreamWriter("trainer.txt");
            for(int i = 0; i < Trainer.GetCount(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }

        public void UpdateTrainer(){
            System.Console.WriteLine("What's the ID of the trainer you would like to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Which Section of the line would you like to edit?\n1:  Name\n2:  Mailing Address\n3:  Email Address");
                string temp = Console.ReadLine();
                if(temp == "1"){
                    System.Console.WriteLine("Please enter the trainers name: ");
                    trainers[foundIndex].SetTrainerName(Console.ReadLine());
                }
                else if(temp == "2"){
                    System.Console.WriteLine("Please enter the trainers mailing address: ");
                    trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                }
                else if(temp == "3"){
                    System.Console.WriteLine("Please enter the trainers email address: ");
                    trainers[foundIndex].SetEmailAddress(Console.ReadLine());
                }
                Save();
            }
            else{
                System.Console.WriteLine("Trainer not found.");
                Console.ReadKey();
            }
        }

        public void DeleteTrainer(){
            System.Console.WriteLine("What is the ID of the trainer you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                trainers[foundIndex].Delete();
                Save();
            }
            else{
                System.Console.WriteLine("Trainer not found.");
                Console.ReadKey();
            }
        }
    }
}